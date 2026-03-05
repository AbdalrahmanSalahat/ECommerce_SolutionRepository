using BLL.Services.Interfaces;
using DAL.DTO.DTORequsts;
using DAL.DTO.DTOResponses;
using DAL.Models;
using Microsoft.AspNetCore.Identity.UI;

using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.UI.Services;


namespace BLL.Services.Classes
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<ApplicationUser> _usermanager;
        private readonly IEmailSender email;

        public AuthenticationService(UserManager<ApplicationUser> usermanager, IEmailSender email)
        {
            _usermanager = usermanager;
            this.email = email;
        }
        public async Task<UserResponse> LoginAsync(LoginRequest loginRequest)
        {
            var findEmail = await _usermanager.FindByEmailAsync(loginRequest.Email);
            if (findEmail == null)
            {
                throw new Exception("not found");
            }
            var checkPass = await _usermanager.CheckPasswordAsync(findEmail, loginRequest.Password);
            if (!checkPass)
            {
                throw new Exception("invalid password");
            }
            if (!await _usermanager.IsEmailConfirmedAsync(findEmail))
            {
                throw new Exception("email not confirmed");
            }
            return new UserResponse()
            {
                Token = await GenerateToken(findEmail)
            };



        }
        public async Task<string> ConfirmEmail(string token, string userId)
        {
            var user = await _usermanager.FindByIdAsync(userId);
            if (user == null)
            {
                throw new Exception("not found");
            }
            var result = await _usermanager.ConfirmEmailAsync(user, token);
            if (result.Succeeded)
            {
                return "email confirmed";
            }
            else
            {
                throw new Exception("error confirming email");
            }
        }
        public async Task<UserResponse> RegisterAsync(RegisterRequest loginRequest)
        {
            var user = new ApplicationUser()
            {
                Name = loginRequest.Name,
                Email = loginRequest.Email,
                UserName = loginRequest.UserName,
                PhoneNumber = loginRequest.PhoneNumber,
            };
            var newUser = await _usermanager.CreateAsync(user, loginRequest.Password);
            if (newUser.Succeeded)
            {
                var token = await _usermanager.GenerateEmailConfirmationTokenAsync(user);
                var escape = Uri.EscapeDataString(token);
                var EmailURL = $"https://localhost:44394/api/Authentication/ConfirmEmail?userId={user.Id}&token={token}";
                await email.SendEmailAsync(user.Email, "Confirmation", $"<a href='{ EmailURL}'> Confirm your email</h1> .");
                return new UserResponse()
                {

                    Token = await GenerateToken(user)
                };

            }
            else
            {
                throw new Exception($"{newUser.Errors}");
            }
        }

        public async Task<string> GenerateToken(ApplicationUser user)
        {
            var userClaims = new List<Claim>
{
    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
    new Claim(ClaimTypes.Name, user.Name!),
    new Claim(ClaimTypes.Email, user.Email!),
    new Claim(ClaimTypes.UserData, user.UserName!)
};
            var roles = await _usermanager.GetRolesAsync(user);
            foreach (var x in roles)
            {
                userClaims.Add(new Claim(ClaimTypes.Role, x));

            }
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("b983b66aeyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9u"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
            claims: userClaims,
            expires: DateTime.Now.AddDays(5),
            signingCredentials: credentials
        );


            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        public async Task<string> ForgotPassword(ForgotPasswordRequest forgotPasswordRequest)
        {
            var user = await _usermanager.FindByEmailAsync(forgotPasswordRequest.Email);
            if (user == null)
            {
                throw new Exception("not found");
            }
            Random random = new Random();
            var code = random.Next(1000, 9999).ToString();
            user.CodeResetPassword = code;
            user.PasswordResetCodeExpiry = DateTime.UtcNow.AddMinutes(15);
            await _usermanager.UpdateAsync(user);
            await email.SendEmailAsync(user.Email, "Reset Password", $"<h1>Your reset code is: {code}</h1>");
            return "Reset code sent to email";
        }
        public async Task<string> ResetPassword(ResetPasswordRequest resetPasswordRequest)
        {
            var user = await _usermanager.FindByEmailAsync(resetPasswordRequest.Email);
            if (user == null)
            {
                throw new Exception("not found");
            }
            if (user.CodeResetPassword != resetPasswordRequest.Code)
            {
                throw new Exception("invalid code");
            }
            if (user.PasswordResetCodeExpiry < DateTime.UtcNow)
            {
                throw new Exception("code expired");
            }
            var token = await _usermanager.GeneratePasswordResetTokenAsync(user);
            var result = await _usermanager.ResetPasswordAsync(user, token, resetPasswordRequest.NewPassword);
            if (result.Succeeded)
            {
                await email.SendEmailAsync(user.Email, "Password Reset Successful", "<h1>Your password has been reset successfully.</h1>");
                return "Password resset copmleted";
            }
            else
            {
                throw new Exception("error resetting password");
            }
        }
    }
}

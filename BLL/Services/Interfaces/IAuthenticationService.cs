using DAL.DTO.DTORequsts;
using DAL.DTO.DTOResponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Interfaces
{
   public interface IAuthenticationService
    {
        Task<UserResponse> LoginAsync(LoginRequest loginRequest);

        Task<UserResponse> RegisterAsync(RegisterRequest loginRequest);
    Task <string> ConfirmEmail(string token, string userId);
        Task<string> ForgotPassword(ForgotPasswordRequest forgotPasswordRequest);
        Task<string> ResetPassword(ResetPasswordRequest resetPasswordRequest);

    }
}

using BLL.Services.Interfaces;
using DAL.DTO.DTORequsts;
using DAL.DTO.DTOResponses;
using Microsoft.AspNetCore.Http;

using Microsoft.AspNetCore.Mvc;

namespace ECommerce_PL.area.Identity.Controller
{
    [Route("api/[area]/[controller]")]
    [ApiController]
    [Area("Identity")]
    public class AccountController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        public AccountController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }
        [HttpPost("register")]
        public async Task<ActionResult<RegisterResponse>> Register(RegisterRequest register)
        {

          var x=  await _authenticationService.RegisterAsync(register);
            return Ok(x);
        
        }
        [HttpPost("Login")]

        public async Task<ActionResult<LoginResponse>> Login(LoginRequest login)
        {
            var x = await _authenticationService.LoginAsync(login);
            return Ok(x);
        }
        [HttpGet("ConfirmEmail")]
        public async Task<ActionResult<string>> ConfirmEmail([FromQuery] string Token, [FromQuery] string UserId)
        { 
        return _authenticationService.ConfirmEmail(Token, UserId).Result;


        }
        [HttpPost("Forgot - Password")]
        public async Task <ActionResult<string>> ForgotPassword([FromBody] ForgotPasswordRequest forgotPasswordRequest)
        {
            return await _authenticationService.ForgotPassword(forgotPasswordRequest);
        }

        [HttpPatch("Reset - Password")]
        public async Task<ActionResult<string>> ResetPassword([FromBody] ResetPasswordRequest resetPasswordRequest)
        {
            return await _authenticationService.ResetPassword(resetPasswordRequest);
        }
    }
}

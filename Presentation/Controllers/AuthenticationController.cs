using AuthenticationService.Application.Services.Interfaces;
using AuthenticationService.Domain.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace AuthenticationService.Presentation.Controllers
{
    [ApiController, Route("api/[controller]")]
    public class AuthenticationController(
        ILogInService service
    ) : ControllerBase
    {

        protected readonly ILogInService _service = service;

        [HttpPost("log-in")]
        public async Task<IActionResult> LogIn([FromBody] LogInDTO logIn)
        {
            try
            {
                var result = await _service.LogIn(logIn);
                return Ok(result);
            }
            catch (UnauthorizedAccessException exception)
            {
                return Unauthorized(new { message = exception.Message });
            }
            catch (ArgumentException exception)
            {
                return NotFound(new { message = exception.Message });
            }
        }

        [HttpPost("validate")]
        public IActionResult Validate([FromHeader(Name = "Authorization")] string jwt)
        {
            try
            {
                var result = _service.Validate(jwt);
                return Ok(result);
            }
            catch (SecurityTokenValidationException ex)
            {
                return StatusCode(401, new { message = "Token validation failed", details = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal server error", details = ex.Message });
            }
        }

    }
}
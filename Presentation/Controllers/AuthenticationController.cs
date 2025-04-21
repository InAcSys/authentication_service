using AuthenticationService.Application.Services.Interfaces;
using AuthenticationService.Domain.DTOs;
using Microsoft.AspNetCore.Mvc;

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
    }
}
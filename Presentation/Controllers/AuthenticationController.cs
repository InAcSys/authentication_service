using AuthenticationService.Domain.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationService.Presentation.Controllers
{
    [ApiController, Route("api/[controller]")]
    public class AuthenticationController : ControllerBase
    {
        [HttpPost("log-in")]
        public async Task<IActionResult> LogIn([FromBody] LogInDTO logIn)
        {
            return Ok();
        }
    }
}
using LearningHub.Core.data;
using LearningHub.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LearningHub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JWTController : ControllerBase
    {
        private readonly IJWTService _jWTService;

        public JWTController(IJWTService jWTService)
        {
            _jWTService = jWTService;
        }


        [HttpPost]
        public IActionResult Auth([FromBody] UserLogin userLogin)
        {
            var token = _jWTService.Auth(userLogin);
            if (token == null)
                return Unauthorized();
            return Ok(token);

        }
    }
}

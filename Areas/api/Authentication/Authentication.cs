using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PixelPlusMulakat.Areas.api.Models;
using PixelPlusMulakat.Interfaces.api;

namespace PixelPlusMulakat.Areas.api.Authentication
{
    [Area("api")]
    [Route("api/[controller]")]
    [ApiController]
    public class Authentication : ControllerBase
    {
        private IJwtAuthenticationManager _jwtAuthenticationManager;
        public Authentication(IJwtAuthenticationManager jwtAuthenticationManager)
        {
            _jwtAuthenticationManager = jwtAuthenticationManager;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] UserCredential userCredential)
        {
            if (ModelState.IsValid)
            {
                var token = _jwtAuthenticationManager.Authenticate(userCredential.Email, userCredential.Password);

                if (token == null)
                    return Unauthorized();

                return Ok(token);
            }
            return BadRequest();
        }
    }
}

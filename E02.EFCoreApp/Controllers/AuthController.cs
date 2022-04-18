using Microsoft.AspNetCore.Mvc;

namespace E02.EFCoreApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        [HttpPost]
        public IActionResult Login()
        {
            TokenGenerator tokenGenerator = new TokenGenerator();
            var token = tokenGenerator.GenerateJwt();
            return Created("",token);
        }
    }
}

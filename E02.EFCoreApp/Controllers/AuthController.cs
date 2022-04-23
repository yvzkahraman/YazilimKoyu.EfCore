using E02.EFCoreApp.Application.CQRS.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace E02.EFCoreApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _meditor;

        public AuthController(IMediator meditor)
        {
            _meditor = meditor;
        }
        //api/Auth post
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] CheckUserQuery query)
        {
            var personDto = await _meditor.Send(query);

            if(personDto == null)
            {
                return BadRequest("kullanıcı adı veya şifre hatalı");
            }

            TokenGenerator tokenGenerator = new TokenGenerator();
            var token = tokenGenerator.GenerateJwt(personDto);
            return Created("",token);
        }
    }
}

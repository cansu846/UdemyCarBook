using MediatR;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Application.Feature.MediatR.Queries.AppUserQueries;
using UdemyCarBook.Application.Tools;

namespace UdemyCarBook.WebApi.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]

    public class LoginController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LoginController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> Login(GetCheckAppUserQuery getCheckAppUserQuery)
        {
            var user = await _mediator.Send(getCheckAppUserQuery);
            if (user.IsUserExist)
            {
                return Created("",JwtTokenGenerator.GenerateToken(user));
            }
            else
            {
                return BadRequest("Unvalid username or password");

            }
        }
    }
}

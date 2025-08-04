using MediatR;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Application.Feature.MediatR.Commands.AppUserCommands;

namespace UdemyCarBook.WebApi.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]

    public class RegisterController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RegisterController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> UserRegister(CreateAppUserCommand createAppUserCommand)
        {
            await _mediator.Send(createAppUserCommand);
            return Ok("Created successfully");
        }
    }
}

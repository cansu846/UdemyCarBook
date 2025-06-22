using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Application.Feature.MediatR.Commands.ServiceCommands;
using UdemyCarBook.Application.Feature.MediatR.Queries.ServiceQueries;

namespace UdemyCarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ServiceController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllService()
        {
            var values = await _mediator.Send(new GetServiceQuery());
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetServiceById(int id)
        {
            var values = await _mediator.Send(new GetServiceByIdQuery(id));
            return Ok(values);
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveService(int id)
        {
            await _mediator.Send(new RemoveServiceCommand(id));
            return Ok("Service silindi");
        }

        [HttpPost]
        public async Task<IActionResult> CreateService(CreateServiceCommand createServiceCommand)
        {
            await _mediator.Send(createServiceCommand);
            return Ok("Service Eklendi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateService(UpdateServiceCommand updateServiceCommand)
        {
            await _mediator.Send(updateServiceCommand);
            return Ok("Service Güncellendi");
        }
    }
}

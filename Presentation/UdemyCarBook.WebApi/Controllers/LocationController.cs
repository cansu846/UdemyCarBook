using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Application.Feature.MediatR.Commands.LocationCommands;
using UdemyCarBook.Application.Feature.MediatR.Queries.LocationQueries;

namespace UdemyCarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LocationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllLocation()
        {
            var values = await _mediator.Send(new GetLocationQuery());
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetLocationById(int id)
        {
            var values = await _mediator.Send(new GetLocationByIdQuery(id));
            return Ok(values);
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveLocation(int id)
        {
            await _mediator.Send(new RemoveLocationCommand(id));
            return Ok("Location silindi");
        }

        [HttpPost]
        public async Task<IActionResult> CreateLocation(CreateLocationCommand createLocationCommand)
        {
            await _mediator.Send(createLocationCommand);
            return Ok("Location Eklendi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateLocation(UpdateLocationCommand updateLocationCommand)
        {
            await _mediator.Send(updateLocationCommand);
            return Ok("Location Güncellendi");
        }
    }
}

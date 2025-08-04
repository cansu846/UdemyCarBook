using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Application.Feature.CQRS.Results.CarFeatureQueries;
using UdemyCarBook.Application.Feature.MediatR.Commands.CarFeatureCommands;
using UdemyCarBook.Application.Feature.MediatR.Queries.CarPricingQueries;


namespace UdemyCarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarFeatureController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CarFeatureController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetCarFeatureByCarId")]
        public async Task<IActionResult> GetCarFeatureByCarId(int carId)
        {
            var values = await _mediator.Send(new GetCarFeatureByCarIdQuery(carId));
            return Ok(values);
        }


        [HttpPost]
        public async Task<IActionResult> GetCarFeatureByCarId(CreateCarFeatureCommand createCarFeatureCommand)
        {
            await _mediator.Send(createCarFeatureCommand);
            return Ok("Car features created successfully");
        }

        [HttpPut("UpdateCarFeatureAvailableToFalse")]
        public async Task<IActionResult> UpdateCarFeatureAvailableToFalse(int carFeatureId)
        {
           await _mediator.Send(new UpdateCarFeatureAvailableToFalseCommand(carFeatureId));
            return Ok("Car feature available change to false");
        }
        [HttpPut("UpdateCarFeatureAvailableToTrue")]
        public async Task<IActionResult> UpdateCarFeatureAvailableToTrue(int carFeatureId)
        {
            await _mediator.Send(new UpdateCarFeatureAvailableToTrueCommand(carFeatureId));
            return Ok("Car feature available change to true");
        }
    }
}

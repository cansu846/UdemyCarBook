using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Application.Feature.MediatR.Commands.PricingCommands;
using UdemyCarBook.Application.Feature.MediatR.Queries.PricingQueries;

namespace UdemyCarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PricingController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PricingController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPricing()
        {
            var values = await _mediator.Send(new GetPricingQuery());
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPricingById(int id)
        {
            var values = await _mediator.Send(new GetPricingByIdQuery(id));
            return Ok(values);
        }

        [HttpDelete]
        public async Task<IActionResult> RemovePricing(int id)
        {
            await _mediator.Send(new RemovePricingCommand(id));
            return Ok("Pricing silindi");
        }

        [HttpPost]
        public async Task<IActionResult> CreatePricing(CreatePricingCommand createPricingCommand)
        {
            await _mediator.Send(createPricingCommand);
            return Ok("Pricing Eklendi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePricing(UpdatePricingCommand updatePricingCommand)
        {
            await _mediator.Send(updatePricingCommand);
            return Ok("Pricing Güncellendi");
        }
    }
}

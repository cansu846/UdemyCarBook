using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Formats.Asn1;
using UdemyCarBook.Application.Feature.MediatR.Commands.FeatureCommands;
using UdemyCarBook.Application.Feature.MediatR.Queries.FeatureQueries;


namespace UdemyFeatureBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeatureController : ControllerBase
    {
      private readonly IMediator _mediator;

        public FeatureController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllFeature()
        {
            var values = await _mediator.Send(new GetFeatureQuery());
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFeatureById(int id)
        {
            var value = await _mediator.Send( new GetFeatureByIdQuery(id));
            return Ok(value);
        }

        [HttpDelete]  
        public async Task<IActionResult> RemoveFeature(int id)
        {
            await _mediator.Send(new RemoveFeatureCommand(id));
            return Ok("Feature silindi...");    
        }

        [HttpPost]  
        public async Task<IActionResult> CreateFeature(CreateFeatureCommand createFeatureCommand)
        {
            await _mediator.Send(createFeatureCommand);
            return Ok("Feature eklendi...");
        }

        [HttpPut]  
        public async Task<IActionResult> UpdateFeature(UpdateFeatureCommand updateFeatureCommand)
        {
            await _mediator.Send(updateFeatureCommand);
            return Ok("Feature güncellendi...");
        }

    
    }
}

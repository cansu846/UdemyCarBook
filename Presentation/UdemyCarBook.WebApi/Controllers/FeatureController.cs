using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Formats.Asn1;
using UdemyCarBook.Application.Feature.CQRS.Commands.FeatureCommands;
using UdemyCarBook.Application.Feature.CQRS.Handlers.FeatureHandlers;
using UdemyCarBook.Application.Feature.CQRS.Queries.FeatureQueries;
using UdemyCarBook.Application.Feature.MediatR.Handlers.FeatureHandlers;

namespace UdemyFeatureBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeatureController : ControllerBase
    {
        private readonly CreateFeatureCommandHandler _createFeatureCommandHandler;
        private readonly UpdateFeatureCommandHandler _updateFeatureCommandHandler;
        private readonly RemoveFeatureCommandHandler _removeFeatureCommandHandler;
        private readonly GetFeatureByIdQueryHandler _getFeatureByIdQueryHandler;
        private readonly GetFeatureQueryHandler _getFeatureQueryHandler;

        public FeatureController(CreateFeatureCommandHandler createFeatureCommandHandler, 
            UpdateFeatureCommandHandler updateFeatureCommandHandler, 
            RemoveFeatureCommandHandler removeFeatureCommandHandler, 
            GetFeatureByIdQueryHandler getFeatureByIdQueryHandler, 
            GetFeatureQueryHandler getFeatureQueryHandler)
        {
            _createFeatureCommandHandler = createFeatureCommandHandler;
            _updateFeatureCommandHandler = updateFeatureCommandHandler;
            _removeFeatureCommandHandler = removeFeatureCommandHandler;
            _getFeatureByIdQueryHandler = getFeatureByIdQueryHandler;
            _getFeatureQueryHandler = getFeatureQueryHandler;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllFeature()
        {
            var values = await _getFeatureQueryHandler.Handle();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFeatureById(int id)
        {
            var value = await _getFeatureByIdQueryHandler.Handle( new GetFeatureByIdQuery(id));
            return Ok(value);
        }

        [HttpDelete]  
        public async Task<IActionResult> Remove(int id)
        {
            await _removeFeatureCommandHandler.Handle(new RemoveFeatureCommand(id));
            return Ok("Feature silindi...");    
        }

        [HttpPost]  
        public async Task<IActionResult> CreateFeature(CreateFeatureCommand createFeatureCommand)
        {
            await _createFeatureCommandHandler.Handle(createFeatureCommand);
            return Ok("Feature eklendi...");
        }

        [HttpPut]  
        public async Task<IActionResult> UpdateFeature(UpdateFeatureCommand updateFeatureCommand)
        {
            await _updateFeatureCommandHandler.Handle(updateFeatureCommand);
            return Ok("Feature güncellendi...");
        }

    
    }
}

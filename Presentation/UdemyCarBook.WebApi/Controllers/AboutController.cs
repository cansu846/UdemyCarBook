using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Formats.Asn1;
using UdemyCarBook.Application.Feature.CQRS.Commands.AboutCommands;
using UdemyCarBook.Application.Feature.CQRS.Handlers.AboutHandlers;
using UdemyCarBook.Application.Feature.CQRS.Queries.AboutQueries;
using UdemyCarBook.Application.Feature.CQRS.Results.AboutResults;

namespace UdemyCarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly CreateAboutCommandHandler _createAboutCommandHandler;
        private readonly UpdateAboutCommandHandler _updateAboutCommandHandler;
        private readonly RemoveAboutCommandHandler _removeAboutCommandHandler;
        private readonly GetAboutByIdQueryHandler _getAboutByIdQueryHandler;
        private readonly GetAboutQueryHandler _getAboutQueryHandler;

        public AboutController(CreateAboutCommandHandler createAboutCommandHandler, 
            UpdateAboutCommandHandler updateAboutCommandHandler, 
            RemoveAboutCommandHandler removeAboutCommandHandler, 
            GetAboutByIdQueryHandler getAboutByIdQueryHandler, 
            GetAboutQueryHandler getAboutQueryHandler)
        {
            _createAboutCommandHandler = createAboutCommandHandler;
            _updateAboutCommandHandler = updateAboutCommandHandler;
            _removeAboutCommandHandler = removeAboutCommandHandler;
            _getAboutByIdQueryHandler = getAboutByIdQueryHandler;
            _getAboutQueryHandler = getAboutQueryHandler;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAbout()
        {
            var values = await _getAboutQueryHandler.Handle();
            return Ok(values);  
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAboutById(int id)
        {
            var value = await _getAboutByIdQueryHandler.Handle( new GetAboutByIdQuery(id));
            return Ok(value);
        }

        [HttpDelete]  
        public async Task<IActionResult> Remove(int id)
        {
            await _removeAboutCommandHandler.Handle(new RemoveAboutCommand(id));
            return Ok("About silindi...");    
        }

        [HttpPost]  
        public async Task<IActionResult> CreateAbout(CreateAboutCommand createAboutCommand)
        {
            await _createAboutCommandHandler.Handle(createAboutCommand);
            return Ok("About eklendi...");
        }

        [HttpPut]  
        public async Task<IActionResult> UpdateAbout(UpdateAboutCommand updateAboutCommand)
        {
            await _updateAboutCommandHandler.Handle(updateAboutCommand);
            return Ok("About güncellendi...");
        }
    }
}

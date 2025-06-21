using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Formats.Asn1;
using UdemyCarBook.Application.Feature.CQRS.Commands.ContactCommands;
using UdemyCarBook.Application.Feature.CQRS.Handlers.ContactHandlers;
using UdemyCarBook.Application.Feature.CQRS.Queries.ContactQueries;

namespace UdemyContactBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly CreateContactCommandHandler _createContactCommandHandler;
        private readonly UpdateContactCommandHandler _updateContactCommandHandler;
        private readonly RemoveContactCommandHandler _removeContactCommandHandler;
        private readonly GetContactByIdQueryHandler _getContactByIdQueryHandler;
        private readonly GetContactQueryHandler _getContactQueryHandler;

        public ContactController(CreateContactCommandHandler createContactCommandHandler, 
            UpdateContactCommandHandler updateContactCommandHandler, 
            RemoveContactCommandHandler removeContactCommandHandler, 
            GetContactByIdQueryHandler getContactByIdQueryHandler, 
            GetContactQueryHandler getContactQueryHandler)
        {
            _createContactCommandHandler = createContactCommandHandler;
            _updateContactCommandHandler = updateContactCommandHandler;
            _removeContactCommandHandler = removeContactCommandHandler;
            _getContactByIdQueryHandler = getContactByIdQueryHandler;
            _getContactQueryHandler = getContactQueryHandler;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllContact()
        {
            var values = await _getContactQueryHandler.Handle();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetContactById(int id)
        {
            var value = await _getContactByIdQueryHandler.Handle( new GetContactByIdQuery(id));
            return Ok(value);
        }

        [HttpDelete]  
        public async Task<IActionResult> Remove(int id)
        {
            await _removeContactCommandHandler.Handle(new RemoveContactCommand(id));
            return Ok("Contact silindi...");    
        }

        [HttpPost]  
        public async Task<IActionResult> CreateContact(CreateContactCommand createContactCommand)
        {
            await _createContactCommandHandler.Handle(createContactCommand);
            return Ok("Contact eklendi...");
        }

        [HttpPut]  
        public async Task<IActionResult> UpdateContact(UpdateContactCommand updateContactCommand)
        {
            await _updateContactCommandHandler.Handle(updateContactCommand);
            return Ok("Contact güncellendi...");
        }

    
    }
}

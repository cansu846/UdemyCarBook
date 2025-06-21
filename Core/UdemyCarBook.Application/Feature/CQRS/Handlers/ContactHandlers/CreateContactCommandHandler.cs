using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Feature.CQRS.Commands.ContactCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Feature.CQRS.Handlers.ContactHandlers
{
    public class CreateContactCommandHandler
    {
        private readonly IRepository<Contact> _ContactRepository;

        public CreateContactCommandHandler(IRepository<Contact> ContactRepository)
        {
            _ContactRepository = ContactRepository;
        }

        public async Task Handle(CreateContactCommand createContactCommand)
        {
            await _ContactRepository.CreateAsync(new Contact
            {
                
                Name = createContactCommand.Name,   
                Email = createContactCommand.Email,
                Subject = createContactCommand.Subject, 
                Message = createContactCommand.Message,
                SendDate = DateTime.Now,
            });
        }
     
    }
}

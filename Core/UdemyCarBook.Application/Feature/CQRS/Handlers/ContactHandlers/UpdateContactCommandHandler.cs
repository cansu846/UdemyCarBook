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
    public class UpdateContactCommandHandler
    {
        private readonly IRepository<Contact> _ContactRepository;

        public UpdateContactCommandHandler(IRepository<Contact> ContactRepository)
        {
            _ContactRepository = ContactRepository;
        }

        public async Task Handle(UpdateContactCommand updateContactCommand)
        {
            var value = await _ContactRepository.GetByIdAsync(updateContactCommand.ContactId);

            value.Name = updateContactCommand.Name; 
            value.Email = updateContactCommand.Email;   
            value.SendDate = DateTime.Now;
            value.Subject = updateContactCommand.Subject;
            value.Message = updateContactCommand.Message;
            
            await _ContactRepository.UpdateAsync(value);
        }
    }
}

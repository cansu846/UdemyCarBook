using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Feature.CQRS.Commands.ContactCommands;
using UdemyCarBook.Application.Feature.CQRS.Queries.ContactQueries;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Feature.CQRS.Handlers.ContactHandlers
{
    public class RemoveContactCommandHandler
    {
        private readonly IRepository<Contact> _ContactRepository;

        public RemoveContactCommandHandler(IRepository<Contact> ContactRepository)
        {
            _ContactRepository = ContactRepository;
        }

        public async Task Handle(RemoveContactCommand removeContactCommand)
        {
            var value = await _ContactRepository.GetByIdAsync(removeContactCommand.Id);
            await _ContactRepository.RemoveAsync(value);
        }
    }
}

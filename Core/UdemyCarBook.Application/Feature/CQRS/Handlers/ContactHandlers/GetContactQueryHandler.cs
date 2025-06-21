using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Feature.CQRS.Results.ContactResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Feature.CQRS.Handlers.ContactHandlers
{
    public class GetContactQueryHandler
    {
        private readonly IRepository<Contact> _ContactRepository;

        public GetContactQueryHandler(IRepository<Contact> ContactRepository)
        {
            _ContactRepository = ContactRepository;
        }

        public async Task<List<GetContactQueryResult>> Handle()
        {
            var values = await _ContactRepository.GetAllAsync();
            return values.Select(x => new GetContactQueryResult { 
                ContactId = x.ContactId,
                Name = x.Name,
                Email = x.Email,
                SendDate = x.SendDate,
                Subject = x.Subject,
                Message= x.Message
            }).ToList();
        }
    }
}

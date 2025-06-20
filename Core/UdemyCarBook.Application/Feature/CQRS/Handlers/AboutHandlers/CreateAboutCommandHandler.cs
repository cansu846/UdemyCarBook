using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Feature.CQRS.Commands.AboutCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Feature.CQRS.Handlers.AboutHandlers
{
    public class CreateAboutCommandHandler
    {
        private IRepository<About> _repository;

        public CreateAboutCommandHandler(IRepository<About> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateAboutCommand about) {
            await _repository.CreateAsync(new About
            {
                Description = about.Description,
                ImageUrl = about.ImageUrl,
                Title = about.Title
            });
        }
    }
}

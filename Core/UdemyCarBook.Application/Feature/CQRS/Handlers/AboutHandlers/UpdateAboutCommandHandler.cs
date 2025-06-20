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
    public class UpdateAboutCommandHandler
    {
        private readonly IRepository<About> _repository;

        public UpdateAboutCommandHandler(IRepository<About> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateAboutCommand updateAboutCommand)
        {
            var value = await _repository.GetByIdAsync(updateAboutCommand.AboutId);

            value.Title = updateAboutCommand.Title;
            value.Description = updateAboutCommand.Description; 
            value.ImageUrl = updateAboutCommand.ImageUrl;

            await _repository.UpdateAsync(value);
        }
    }
}

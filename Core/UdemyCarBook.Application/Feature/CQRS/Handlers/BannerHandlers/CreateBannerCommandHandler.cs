using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Feature.CQRS.Commands.BannerCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Feature.CQRS.Handlers.BannerHandlers
{
    public class CreateBannerCommandHandler
    {
        private IRepository<Banner> _repository;

        public CreateBannerCommandHandler(IRepository<Banner> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateBannerCommand createBannerCommand)
        {

            await _repository.CreateAsync(new Banner
            {
                Description = createBannerCommand.Description,
                Title = createBannerCommand.Title,  
                VideoDescription = createBannerCommand.VideoDescription,    
               VideoUrl = createBannerCommand.VideoUrl,  
            });
        }
    }
}

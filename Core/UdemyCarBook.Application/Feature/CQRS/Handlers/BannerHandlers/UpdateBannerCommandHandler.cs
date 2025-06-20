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
    public class UpdateBannerCommandHandler
    {
        private readonly IRepository<Banner> _repository;

        public UpdateBannerCommandHandler(IRepository<Banner> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateBannerCommand updateBannerCommand)
        {
            var value = await _repository.GetByIdAsync(updateBannerCommand.BannerId);

            value.Description = updateBannerCommand.Description;
            value.Title = updateBannerCommand.Title;
            value.VideoDescription = updateBannerCommand.VideoDescription;
            value.VideoUrl = updateBannerCommand.VideoUrl;

            await _repository.UpdateAsync(value);
        }
    }
}

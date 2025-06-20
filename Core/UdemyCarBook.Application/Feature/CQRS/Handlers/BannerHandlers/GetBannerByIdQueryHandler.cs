using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Feature.CQRS.Queries.BannerQueries;
using UdemyCarBook.Application.Feature.CQRS.Results.BannerResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Feature.CQRS.Handlers.BannerHandlers
{
    public class GetBannerByIdQueryHandler
    {
        private readonly IRepository<Banner> _respository;

        public GetBannerByIdQueryHandler(IRepository<Banner> respository)
        {
            _respository = respository;
        }

        public async Task<GetBannerByIdQueryResult> Handle(GetBannerByIdQuery getBannerByIdQuery)
        {
            var value = await _respository.GetByIdAsync(getBannerByIdQuery.Id);
            return new GetBannerByIdQueryResult
            {
                BannerId = value.BannerId,
                Description = value.Description,
                Title = value.Title,
                VideoDescription = value.VideoDescription,
                VideoUrl = value.VideoUrl   
            };
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Feature.CQRS.Results.BannerResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Feature.CQRS.Handlers.BannerHandlers
{
    public class GetBannerQueryHandler
    {
        private readonly IRepository<Banner> _respository;

        public GetBannerQueryHandler(IRepository<Banner> respository)
        {
            _respository = respository;
        }

        public async Task<List<GetBannerQueryResult>> Handle()
        {
            var values = await _respository.GetAllAsync();
            return values.Select(b=> new GetBannerQueryResult
            {
                BannerId = b.BannerId,  
                Description = b.Description,
                Title = b.Title,
                VideoDescription = b.VideoDescription,
                VideoUrl= b.VideoUrl
                
            }).ToList();
        }
    }
}

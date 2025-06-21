using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Feature.CQRS.Results.BrandResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Feature.CQRS.Handlers.BrandHandler
{
    public class GetBrandQueryHandler
    {
        private readonly IRepository<Brand> _respository;

        public GetBrandQueryHandler(IRepository<Brand> respository)
        {
            _respository = respository;
        }

        public async Task<List<GetBrandQueryResult>> Handle()
        {
            var values = await _respository.GetAllAsync();
            return values.Select(b=> new GetBrandQueryResult
            {
               BrandId = b.BrandId,
               Name = b.Name
            }).ToList();
        }
    }
}

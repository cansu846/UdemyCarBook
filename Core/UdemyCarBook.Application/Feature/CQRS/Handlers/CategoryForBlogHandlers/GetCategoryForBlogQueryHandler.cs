using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Feature.CQRS.Results.CategoryForBlogResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Feature.CQRS.Handlers.CategoryForBlogHandlers
{
    public class GetCategoryForBlogQueryHandler
    {
        private readonly IRepository<CategoryForBlog> _categoryForBlogRepository;

        public GetCategoryForBlogQueryHandler(IRepository<CategoryForBlog> categoryForBlogRepository)
        {
            _categoryForBlogRepository = categoryForBlogRepository;
        }

        public async Task<List<GetCategoryForBlogQueryResult>> Handle()
        {
            var values = await _categoryForBlogRepository.GetAllAsync();
            return values.Select(x => new GetCategoryForBlogQueryResult { 
                CategoryForBlogId = x.CategoryForBlogId,
                Name = x.Name
            }).ToList();
        }
    }
}

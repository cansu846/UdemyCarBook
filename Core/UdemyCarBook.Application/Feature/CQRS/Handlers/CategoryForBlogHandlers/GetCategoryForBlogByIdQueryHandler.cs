using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Feature.CQRS.Queries.CategoryForBlogQueries;
using UdemyCarBook.Application.Feature.CQRS.Results.CategoryForBlogResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Feature.CQRS.Handlers.CategoryForBlogHandlers
{
    public class GetCategoryForBlogByIdQueryHandler
    {
        private readonly IRepository<CategoryForBlog> _categoryForBlogRepository;

        public GetCategoryForBlogByIdQueryHandler(IRepository<CategoryForBlog> categoryForBlogRepository)
        {
            _categoryForBlogRepository = categoryForBlogRepository;
        }

        public async Task<GetCategoryForBlogByIdQueryResult> Handle(GetCategoryForBlogByIdQuery getCategoryForBlogByIdQuery)
        {
            var values = await _categoryForBlogRepository.GetByIdAsync(getCategoryForBlogByIdQuery.Id);
            return new GetCategoryForBlogByIdQueryResult
            {
                CategoryForBlogId = values.CategoryForBlogId,
                Name = values.Name
            };
        }
    }
}

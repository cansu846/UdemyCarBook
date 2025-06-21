using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Feature.CQRS.Commands.CategoryForBlogCommands;
using UdemyCarBook.Application.Feature.CQRS.Queries.CategoryForBlogQueries;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Feature.CQRS.Handlers.CategoryForBlogHandlers
{
    public class RemoveCategoryForBlogCommandHandler
    {
        private readonly IRepository<CategoryForBlog> _categoryForBlogRepository;

        public RemoveCategoryForBlogCommandHandler(IRepository<CategoryForBlog> categoryForBlogRepository)
        {
            _categoryForBlogRepository = categoryForBlogRepository;
        }

        public async Task Handle(RemoveCategoryForBlogCommand removeCategoryForBlogCommand)
        {
            var value = await _categoryForBlogRepository.GetByIdAsync(removeCategoryForBlogCommand.Id);
            await _categoryForBlogRepository.RemoveAsync(value);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Feature.CQRS.Commands.CategoryForBlogCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Feature.CQRS.Handlers.CategoryForBlogHandlers
{
    public class UpdateCategoryForBlogCommandHandler
    {
        private readonly IRepository<CategoryForBlog> _categoryForBlogRepository;

        public UpdateCategoryForBlogCommandHandler(IRepository<CategoryForBlog> categoryForBlogRepository)
        {
            _categoryForBlogRepository = categoryForBlogRepository;
        }

        public async Task Handle(UpdateCategoryForBlogCommand updateCategoryForBlogCommand)
        {
            var value = await _categoryForBlogRepository.GetByIdAsync(updateCategoryForBlogCommand.CategoryForBlogId);

            value.Name = updateCategoryForBlogCommand.Name; 

            await _categoryForBlogRepository.UpdateAsync(value);
        }
    }
}

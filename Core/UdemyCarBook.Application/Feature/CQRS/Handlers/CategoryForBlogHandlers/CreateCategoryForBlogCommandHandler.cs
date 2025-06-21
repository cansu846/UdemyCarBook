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
    public class CreateCategoryForBlogCommandHandler
    {
        private readonly IRepository<CategoryForBlog> _categoryForBlogRepository;

        public CreateCategoryForBlogCommandHandler(IRepository<CategoryForBlog> categoryForBlogRepository)
        {
            _categoryForBlogRepository = categoryForBlogRepository;
        }

        public async Task Handle(CreateCategoryForBlogCommand createCategoryForBlogCommand)
        {
            await _categoryForBlogRepository.CreateAsync(new CategoryForBlog
            {
                Name = createCategoryForBlogCommand.Name,   
            });
        }
    }
}

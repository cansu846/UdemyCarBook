using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Blog.MediatR.Commands.BlogCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Blog.MediatR.Handlers.BlogHandlers
{
    public class CreateBlogCommandHandler : IRequestHandler<CreateBlogCommand>
    {
        private readonly IRepository<UdemyCarBook.Domain.Entities.Blog> _repository;

        public CreateBlogCommandHandler(IRepository<Domain.Entities.Blog> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateBlogCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Domain.Entities.Blog
            {
                Title = request.Title,
                AuthorId = request.AuthorId,
                CoverImageUrl = request.CoverImageUrl,
                CreatedDate = DateTime.Now,
                CategoryForBlogId = request.CategoryForBlogId,
                Description = request.Description
            });
        }
    }
}

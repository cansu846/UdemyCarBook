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
    public class UpdateBlogCommandHandler : IRequestHandler<UpdateBlogCommand>
    {
        private readonly IRepository<UdemyCarBook.Domain.Entities.Blog> _repository;

        public UpdateBlogCommandHandler(IRepository<Domain.Entities.Blog> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateBlogCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.BlogId);
            value.Title = request.Title;
            value.AuthorId = request.AuthorId;
            value.CoverImageUrl = request.CoverImageUrl;
            value.CreatedDate = DateTime.Now;   
            value.CategoryForBlogId = request.CategoryForBlogId;  
            value.Description = request.Description;  
            await _repository.UpdateAsync(value);
        }
 
    }
}

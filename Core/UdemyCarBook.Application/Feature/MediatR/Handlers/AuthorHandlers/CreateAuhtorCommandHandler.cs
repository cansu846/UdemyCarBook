using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Author.MediatR.Commands.AuthorCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Author.MediatR.Handlers.AuthorHandlers
{
    public class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommand>
    {
        private readonly IRepository<UdemyCarBook.Domain.Entities.Author> _repository;

        public CreateAuthorCommandHandler(IRepository<Domain.Entities.Author> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Domain.Entities.Author
            {
                Name = request.Name,
                ImageUrl = request.ImageUrl,
                Description = request.Description,
            });

        }
    }
}

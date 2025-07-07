using MediatR;
using UdemyCarBook.Application.Feature.MediatR.Queries.AuthorQueries;
using UdemyCarBook.Application.Feature.MediatR.Results.AuthorResults;
using UdemyCarBook.Application.Interfaces;

namespace UdemyCarBook.Application.Author.MediatR.Handlers.AuthorHandlers
{
    public class GetAuthorByIdQueryHandler : IRequestHandler<GetAuthorByIdQuery, GetAuthorByIdQueryResult>
    {
        private readonly IRepository<UdemyCarBook.Domain.Entities.Author> _repository;

        public GetAuthorByIdQueryHandler(IRepository<UdemyCarBook.Domain.Entities.Author> repository)
        {
            _repository = repository;
        }

        public async Task<GetAuthorByIdQueryResult> Handle(GetAuthorByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            return new GetAuthorByIdQueryResult { 
                Name = value.Name,
                ImageUrl = value.ImageUrl,
                Description = value.Description
            };
        }
    }
}

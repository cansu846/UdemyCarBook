using MediatR;
using UdemyCarBook.Application.Feature.MediatR.Queries.AuthorQueries;
using UdemyCarBook.Application.Feature.MediatR.Results.AuthorResults;
using UdemyCarBook.Application.Interfaces;

namespace UdemyCarBook.Application.Author.MediatR.Handlers.AuthorHandlers
{
    public class GetAuthorQueryHandler : IRequestHandler<GetAuthorQuery, List<GetAuthorQueryResult>>
    {
        private readonly IRepository<UdemyCarBook.Domain.Entities.Author> _repository;

        public GetAuthorQueryHandler(IRepository<UdemyCarBook.Domain.Entities.Author> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetAuthorQueryResult>> Handle(GetAuthorQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x=>new GetAuthorQueryResult
            {
               AuthorId= x.AuthorId,
                Name = x.Name,
                ImageUrl = x.ImageUrl,
                Description = x.Description,
            }).ToList();
        }

    }
}

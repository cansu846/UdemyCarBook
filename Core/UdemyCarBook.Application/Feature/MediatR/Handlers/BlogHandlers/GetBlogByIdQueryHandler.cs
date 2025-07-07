using MediatR;
using UdemyCarBook.Application.Feature.MediatR.Queries.BlogQueries;
using UdemyCarBook.Application.Feature.MediatR.Results.BlogResults;
using UdemyCarBook.Application.Interfaces;

namespace UdemyCarBook.Application.Blog.MediatR.Handlers.BlogHandlers
{
    public class GetBlogByIdQueryHandler : IRequestHandler<GetBlogByIdQuery, GetBlogByIdQueryResult>
    {
        private readonly IRepository<UdemyCarBook.Domain.Entities.Blog> _repository;

        public GetBlogByIdQueryHandler(IRepository<UdemyCarBook.Domain.Entities.Blog> repository)
        {
            _repository = repository;
        }

        public async Task<GetBlogByIdQueryResult> Handle(GetBlogByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            return new GetBlogByIdQueryResult {
                BlogId = value.BlogId,
                Title = value.Title,
                AuthorId = value.AuthorId,
                CoverImageUrl = value.CoverImageUrl,    
                CreatedDate = value.CreatedDate,
                CategoryForBlogId = value.CategoryForBlogId,
                Description = value.Description,    
            };
        }
    }
}

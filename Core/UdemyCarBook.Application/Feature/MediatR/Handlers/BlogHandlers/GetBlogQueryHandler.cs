using MediatR;
using UdemyCarBook.Application.Feature.MediatR.Queries.BlogQueries;
using UdemyCarBook.Application.Feature.MediatR.Results.BlogResults;
using UdemyCarBook.Application.Interfaces;

namespace UdemyCarBook.Application.Blog.MediatR.Handlers.BlogHandlers
{
    public class GetBlogQueryHandler : IRequestHandler<GetBlogQuery, List<GetBlogQueryResult>>
    {
        private readonly IRepository<UdemyCarBook.Domain.Entities.Blog> _repository;

        public GetBlogQueryHandler(IRepository<UdemyCarBook.Domain.Entities.Blog> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetBlogQueryResult>> Handle(GetBlogQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x=>new GetBlogQueryResult
            {
              AuthorId = x.AuthorId,
              CategoryForBlogId = x.CategoryForBlogId,
              CreatedDate = x.CreatedDate,
              Title = x.Title,
              CoverImageUrl = x.CoverImageUrl,
              BlogId = x.BlogId ,
              Description = x.Description
            }).ToList();
        }
    }
}

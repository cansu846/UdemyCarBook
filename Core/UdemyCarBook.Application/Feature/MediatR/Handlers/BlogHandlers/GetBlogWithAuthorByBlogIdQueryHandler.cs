using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Feature.MediatR.Queries.BlogQueries;
using UdemyCarBook.Application.Feature.MediatR.Results.BlogResults;
using UdemyCarBook.Application.Interfaces.BlogInterfaces;

namespace UdemyCarBook.Application.Feature.MediatR.Handlers.BlogHandlers
{
    public class GetBlogWithAuthorByBlogIdQueryHandler : IRequestHandler<GetBlogWithAuthorByBlogIdQuery, GetBlogWithAuthorByBlogIdQueryResult>
    {
        private readonly IBlogRepository _blogRepository;

        public GetBlogWithAuthorByBlogIdQueryHandler(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public async Task<GetBlogWithAuthorByBlogIdQueryResult> Handle(GetBlogWithAuthorByBlogIdQuery request, CancellationToken cancellationToken)
        {
            var value = _blogRepository.GetBlogWithAuthorByBlogId(request.BlogId);
            return new GetBlogWithAuthorByBlogIdQueryResult
            {
                BlogId = value.BlogId,
                AuthorDescription = value.Author.Description,
                AuthorName = value.Author.Name,
                AuthorImageUrl = value.Author.ImageUrl,
                AuthorId = value.AuthorId
            };
        }
    }
}

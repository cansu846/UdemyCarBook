using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Feature.MediatR.Queries.TagCloudQueries;
using UdemyCarBook.Application.Feature.MediatR.Results.TagCloudResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Application.Interfaces.TagCloudInterfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Feature.MediatR.Handlers.BlogHandlers
{
    public class GetTagCloudByBlogIdQueryHandler : IRequestHandler<GetTagCloudByBlogIdQuery, List<GetTagCloudByBlogIdQueryResult>>
    {
        private readonly ITagCloudRepository _tagCloudRepository;

        public GetTagCloudByBlogIdQueryHandler(ITagCloudRepository tagCloudRepository)
        {
            _tagCloudRepository = tagCloudRepository;
        }

        public async Task<List<GetTagCloudByBlogIdQueryResult>> Handle(GetTagCloudByBlogIdQuery request, CancellationToken cancellationToken)
        {
            var values = _tagCloudRepository.GetTagCloudByBlogIdDto(request.BlogId);
            return values.Select(x => new GetTagCloudByBlogIdQueryResult
            {
                Title = x.Title,
                BlogId = x.BlogId,
                TagCloudId = x.TagCloudId,  
            }).ToList();
        }
    }
}

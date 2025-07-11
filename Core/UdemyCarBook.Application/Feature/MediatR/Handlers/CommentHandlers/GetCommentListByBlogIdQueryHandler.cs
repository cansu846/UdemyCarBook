using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Feature.MediatR.Queries.CommentQueries;
using UdemyCarBook.Application.Feature.MediatR.Results.CommandResults;
using UdemyCarBook.Application.Interfaces.CommentInterfaces;

namespace UdemyCarBook.Application.Feature.MediatR.Handlers.CommentHandlers
{
    public class GetCommentListByBlogIdQueryHandler : IRequestHandler<GetCommentByBlogIdQuery, List<GetCommentByBlogIdQueryResult>>
    {
        private readonly ICommentRepository _commentRepository;

        public GetCommentListByBlogIdQueryHandler(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task<List<GetCommentByBlogIdQueryResult>> Handle(GetCommentByBlogIdQuery request, CancellationToken cancellationToken)
        {
            var values =  _commentRepository.GetCommentListByBlogId(request.BlogId);
            return values.Select(x => new GetCommentByBlogIdQueryResult {
                BlogId = x.BlogId,
                CommentId = x.CommentId,
                CreatedDate = x.CreatedDate,
                Description = x.Description,
                Name = x.Name   
            }).ToList();
        }
    }
}

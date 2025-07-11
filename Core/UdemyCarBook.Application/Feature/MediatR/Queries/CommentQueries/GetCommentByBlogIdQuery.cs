using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Feature.MediatR.Results.CommandResults;

namespace UdemyCarBook.Application.Feature.MediatR.Queries.CommentQueries
{
    public class GetCommentByBlogIdQuery:IRequest<List<GetCommentByBlogIdQueryResult>>
    {
        public int BlogId { get; set; }

        public GetCommentByBlogIdQuery(int blogId)
        {
            BlogId = blogId;
        }
    }
}

using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Feature.MediatR.Results.BlogResults;

namespace UdemyCarBook.Application.Feature.MediatR.Queries.BlogQueries
{
    public class GetBlogWithAuthorByBlogIdQuery:IRequest<GetBlogWithAuthorByBlogIdQueryResult>
    {
        public int BlogId { get; set; }

        public GetBlogWithAuthorByBlogIdQuery(int blogId)
        {
            BlogId = blogId;
        }
    }
}

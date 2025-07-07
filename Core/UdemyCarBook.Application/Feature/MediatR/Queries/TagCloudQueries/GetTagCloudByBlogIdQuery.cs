using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Feature.MediatR.Results.TagCloudResults;

namespace UdemyCarBook.Application.Feature.MediatR.Queries.TagCloudQueries
{
    public class GetTagCloudByBlogIdQuery:IRequest<List<GetTagCloudByBlogIdQueryResult>>
    {
        public int BlogId { get; set; }

        public GetTagCloudByBlogIdQuery(int blogId)
        {
            BlogId = blogId;
        }
    }
}

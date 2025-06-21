using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarBook.Application.Feature.CQRS.Queries.CategoryForBlogQueries
{
    public class GetCategoryForBlogByIdQuery
    {
        public int Id { get; set; }

        public GetCategoryForBlogByIdQuery(int id)
        {
            Id = id;
        }
    }
}

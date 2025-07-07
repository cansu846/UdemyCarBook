using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarBook.Application.Blog.MediatR.Commands.BlogCommands
{
    public class CreateBlogCommand:IRequest
    {
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public string CoverImageUrl { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CategoryForBlogId { get; set; }
        public string Description { get; set; }

    }
}

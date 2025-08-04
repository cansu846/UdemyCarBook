using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarBook.Dtos.BlogDtos
{
    public class ResultBlogWithCommentByBlogIdDto
    {

            public int commentId { get; set; }
            public string name { get; set; }
            public DateTime createdDate { get; set; }
            public string description { get; set; }
            public int blogId { get; set; }
    
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarBook.Dtos.CommentDtos
{
    public class UpdateCommentDto
    {
        public int CommentId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int BlogId { get; set; }
    }
}

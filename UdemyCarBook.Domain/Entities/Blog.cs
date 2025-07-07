using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarBook.Domain.Entities
{
    public class Blog
    {
        public int BlogId { get; set; }
        public string Title{ get; set; }
        public string Description { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }
        public string CoverImageUrl { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CategoryForBlogId { get; set; }
        public CategoryForBlog CategoryForBlog { get; set; }
        public List<TagCloud> TagClouds { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarBook.Dtos.CategoryDtos
{
    public class UpdateCategoryDto
    {
        public int categoryForBlogId { get; set; }
        public string name { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarBook.Application.Feature.CQRS.Commands.CategoryForBlogCommands
{
    public class UpdateCategoryForBlogCommand
    {
        public int CategoryForBlogId { get; set; }
        public string Name { get; set; }
    }
}

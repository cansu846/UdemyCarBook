using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarBook.Application.Feature.CQRS.Commands.CategoryForBlogCommands
{
    public class RemoveCategoryForBlogCommand
    {
        public int Id { get; set; }

        public RemoveCategoryForBlogCommand(int id)
        {
            Id = id;
        }
    }
}

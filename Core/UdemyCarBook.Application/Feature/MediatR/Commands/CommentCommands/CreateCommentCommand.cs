using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarBook.Application.Feature.MediatR.Commands.CommentCommands
{
    public class CreateCommentCommand:IRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int BlogId { get; set; }
    }
}

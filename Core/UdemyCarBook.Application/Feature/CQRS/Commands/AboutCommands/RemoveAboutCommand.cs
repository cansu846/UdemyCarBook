using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarBook.Application.Feature.CQRS.Commands.AboutCommands
{
    public class RemoveAboutCommand
    {
        public int AboutId { get; set; }

        public RemoveAboutCommand(int aboutId)
        {
            AboutId = aboutId;
        }
    }
}

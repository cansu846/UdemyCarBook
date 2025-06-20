using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarBook.Application.Feature.CQRS.Commands.BannerCommands
{
    public class RemoveBannerCommand
    {
        public int BannerId { get; set; }

        public RemoveBannerCommand(int Id)
        {
            BannerId = Id;
        }
    }
}

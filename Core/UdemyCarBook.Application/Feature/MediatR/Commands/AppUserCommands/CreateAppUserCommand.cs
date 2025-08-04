using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Feature.MediatR.Commands.AppUserCommands
{
    public class CreateAppUserCommand:IRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public int AppRoleId { get; set; }
    }
}

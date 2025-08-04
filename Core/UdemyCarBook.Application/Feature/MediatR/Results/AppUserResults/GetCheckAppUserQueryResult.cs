using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarBook.Application.Feature.MediatR.Results.AppUserResults
{
    public class GetCheckAppUserQueryResult
    {
        public int AppUserId { get; set; }
        public string Username { get; set; }
        public string Role { get; set; }
        public bool IsUserExist { get; set; }
    }
}

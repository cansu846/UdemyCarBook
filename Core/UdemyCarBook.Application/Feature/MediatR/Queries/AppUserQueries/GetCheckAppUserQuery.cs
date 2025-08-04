using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Feature.MediatR.Results.AppUserResults;

namespace UdemyCarBook.Application.Feature.MediatR.Queries.AppUserQueries
{
    public class GetCheckAppUserQuery:IRequest<GetCheckAppUserQueryResult>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}

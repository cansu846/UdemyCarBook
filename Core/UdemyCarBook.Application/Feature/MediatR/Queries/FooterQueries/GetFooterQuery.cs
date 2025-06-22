using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Feature.MediatR.Results.FooterResults;

namespace UdemyCarBook.Application.Feature.MediatR.Queries.FooterQueries
{
    public class GetFooterQuery:IRequest<List<GetFooterQueryResult>>
    {
    }
}

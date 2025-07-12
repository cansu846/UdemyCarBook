using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Feature.MediatR.Results.StatisticsResults;

namespace UdemyCarBook.Application.Feature.MediatR.Queries.StatisticsQueries
{
    public class GetCarCountQuery:IRequest<GetCarCountQueryResult>
    {
    }
}

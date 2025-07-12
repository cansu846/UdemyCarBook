using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Feature.Mediator.Results.StatisticsResults;

namespace UdemyCarBook.Application.Feature.Mediator.Queries.StatisticsQueries
{
    public class GetLocationCountQuery : IRequest<GetLocationCountQueryResult>
    {
    }
}

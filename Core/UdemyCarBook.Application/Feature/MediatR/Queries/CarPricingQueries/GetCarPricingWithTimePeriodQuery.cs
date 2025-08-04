using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Feature.MediatR.Results.CarPricingResults;

namespace UdemyCarBook.Application.Feature.MediatR.Queries.CarPricingQueries
{
    public class GetCarPricingWithTimePeriodQuery:IRequest<List<GetCarPricingWithTimePeriodQueryResult>>
    {
    
    }
}

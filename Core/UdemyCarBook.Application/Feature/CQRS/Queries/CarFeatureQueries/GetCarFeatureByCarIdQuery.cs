using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Feature.CQRS.Results.CarFeatureResults;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Feature.CQRS.Results.CarFeatureQueries
{
    public class GetCarFeatureByCarIdQuery:IRequest<List<GetCarFeatureByCarIdQueryResult>>
    {
        public int CarId { get; set; }

        public GetCarFeatureByCarIdQuery(int carId)
        {
            CarId = carId;
        }
    }
}

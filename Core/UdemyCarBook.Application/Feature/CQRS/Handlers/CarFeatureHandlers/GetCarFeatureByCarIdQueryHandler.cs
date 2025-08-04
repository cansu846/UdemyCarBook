using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Feature.CQRS.Results.CarFeatureQueries;
using UdemyCarBook.Application.Interfaces.CarFeatureInterfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Feature.CQRS.Results.CarFeatureResults
{
    public class GetCarFeatureByCarIdQueryHandler : IRequestHandler<GetCarFeatureByCarIdQuery, List<GetCarFeatureByCarIdQueryResult>>
    {
        private readonly ICarFeatureRepository _carFeatureRepository;

        public GetCarFeatureByCarIdQueryHandler(ICarFeatureRepository carFeatureRepository)
        {
            _carFeatureRepository = carFeatureRepository;
        }

        public async Task<List<GetCarFeatureByCarIdQueryResult>> Handle(GetCarFeatureByCarIdQuery request, CancellationToken cancellationToken)
        {
            return _carFeatureRepository.GetCarFeatureById(request.CarId).Select(x=> new GetCarFeatureByCarIdQueryResult
            {
                CarId = x.CarId,    
                Available = x.Available,
                CarFeatureId = x.CarFeatureId,
                FeatureId=x.FeatureId,  
                FeatureName=x.Feature.FeatureName
            }).ToList();
        }
    }
}

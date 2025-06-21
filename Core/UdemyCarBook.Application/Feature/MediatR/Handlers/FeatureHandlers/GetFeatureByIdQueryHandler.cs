using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Application.Feature.MediatR.Queries.FeatureQueries;
using UdemyCarBook.Application.Feature.MediatR.Results.FeatureResults;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Feature.MediatR.Handlers.FeatureHandlers
{
    public class GetFeatureByIdQueryHandler : IRequestHandler<GetFeatureByIdQuery, GetFeatureByIdQueryResult>
    {
        private readonly IRepository<UdemyCarBook.Domain.Entities.Feature> _repository;

        public GetFeatureByIdQueryHandler(IRepository<UdemyCarBook.Domain.Entities.Feature> repository)
        {
            _repository = repository;
        }

        public async Task<GetFeatureByIdQueryResult> Handle(GetFeatureByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            return new GetFeatureByIdQueryResult { 
                FeatureName = value.FeatureName,    
                FeatureId = value.FeatureId
            };
        }
    }
}

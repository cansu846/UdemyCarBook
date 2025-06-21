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
    public class GetFeatureQueryHandler : IRequestHandler<GetFeatureQuery, List<GetFeatureQueryResult>>
    {
        private readonly IRepository<UdemyCarBook.Domain.Entities.Feature> _repository;

        public GetFeatureQueryHandler(IRepository<UdemyCarBook.Domain.Entities.Feature> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetFeatureQueryResult>> Handle(GetFeatureQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x=>new GetFeatureQueryResult
            {
                FeatureId = x.FeatureId,
                FeatureName = x.FeatureName
            }).ToList();
        }
    }
}

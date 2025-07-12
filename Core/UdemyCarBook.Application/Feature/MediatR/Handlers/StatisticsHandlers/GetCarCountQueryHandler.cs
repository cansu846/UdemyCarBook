using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Feature.MediatR.Queries.StatisticsQueries;
using UdemyCarBook.Application.Feature.MediatR.Results.StatisticsResults;
using UdemyCarBook.Application.Interfaces.CarInterfaces;

namespace UdemyCarBook.Application.Feature.Mediator.Handlers.StatisticsHandlers
{
    public class GetCarCountQueryHandler : IRequestHandler<GetCarCountQuery, GetCarCountQueryResult>
    {
        private readonly ICarRepository _repository;

        public GetCarCountQueryHandler(ICarRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetCarCountQueryResult> Handle(GetCarCountQuery request, CancellationToken cancellationToken)
        {
            var value =  _repository.GetCarCount();
            return new GetCarCountQueryResult
            {
                CarCount = value,
            };
        }
    }
}

using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Feature.Mediator.Queries.StatisticsQueries;
using UdemyCarBook.Application.Feature.Mediator.Results.StatisticsResults;
using UdemyCarBook.Application.Interfaces.StatisticsInterfaces;

namespace UdemyCarBook.Application.Feature.Mediator.Handlers.StatisticsHandlers
{
    public class GetCarCountByFuelGasolineOrDieselQueryHandler : IRequestHandler<GetCarCountByFuelGasolineOrDieselQuery, GetCarCountByFuelGasolineOrDieselQueryResult>
    {
        private readonly IStatisticsRepository _repository;

        public GetCarCountByFuelGasolineOrDieselQueryHandler(IStatisticsRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetCarCountByFuelGasolineOrDieselQueryResult> Handle(GetCarCountByFuelGasolineOrDieselQuery request, CancellationToken cancellationToken)
        {
            var value = _repository.GetCarCountByFuelGasolineOrDiesel();
            return new GetCarCountByFuelGasolineOrDieselQueryResult
            {
                CarCountByFuelGasolineOrDiesel = value
            };
        }
    }
}

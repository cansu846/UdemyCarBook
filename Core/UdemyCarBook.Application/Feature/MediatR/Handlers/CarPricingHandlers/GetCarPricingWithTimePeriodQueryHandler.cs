using MediatR;
using UdemyCarBook.Application.Feature.MediatR.Queries.CarPricingQueries;
using UdemyCarBook.Application.Feature.MediatR.Results.CarPricingResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Application.Interfaces.CarInterfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Feature.MediatR.Handlers.CarPricingHandlers
{
    public class GetCarPricingWithTimePeriodQueryHandler : IRequestHandler<GetCarPricingWithTimePeriodQuery, List<GetCarPricingWithTimePeriodQueryResult>>
    {
        private readonly ICarPricingRepository _repository;

        public GetCarPricingWithTimePeriodQueryHandler(ICarPricingRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetCarPricingWithTimePeriodQueryResult>> Handle(GetCarPricingWithTimePeriodQuery request, CancellationToken cancellationToken)
        {
            var values = _repository.GetCarPricingWithTimePeriod();
            return values.Select(x => new GetCarPricingWithTimePeriodQueryResult{ 
                Model=x.Model,
                Brand=x.Brand,
                CoverImageUrl=x.CoverImageUrl,
                DailyAmount = x.Amounts[0],
                WeeklyAmount=x.Amounts[1],  
                MontlyAmount=x.Amounts[2]
            }).ToList();
        }
    }
}

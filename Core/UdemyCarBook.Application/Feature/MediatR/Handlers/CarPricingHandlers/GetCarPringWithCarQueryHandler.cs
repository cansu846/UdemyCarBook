using MediatR;
using UdemyCarBook.Application.Feature.MediatR.Queries.CarPricingQueries;
using UdemyCarBook.Application.Feature.MediatR.Results.CarPricingResults;
using UdemyCarBook.Application.Interfaces.CarInterfaces;

namespace UdemyCarBook.Application.Feature.MediatR.Handlers.CarPricingHandlers
{
    public class GetCarWithPricingQueryHandler : IRequestHandler<GetCarPricingWithCarQuery, List<GetCarPricingWithCarQueryResult>>
    {
        private readonly ICarPricingRepository _carPricingRepository;

        public GetCarWithPricingQueryHandler(ICarPricingRepository carPricingRepository)
        {
            _carPricingRepository = carPricingRepository;
        }

        public async Task<List<GetCarPricingWithCarQueryResult>> Handle(GetCarPricingWithCarQuery request, CancellationToken cancellationToken)
        {
            return _carPricingRepository.GetCarPricingWithCar().Select(x=>new GetCarPricingWithCarQueryResult
            {
                CarPricingId = x.CarPricingId,
                PricingId = x.CarPricingId,
                CarId = x.Car.CarId,    
                CoverImage = x.Car.CoverImage,
                Amount = x.Amount,
                BrandName = x.Car.Brand.Name,   
                Model = x.Car.Model
            }).ToList();

        }
    }
}

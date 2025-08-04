using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Feature.MediatR.Queries.RentACarQueries;
using UdemyCarBook.Application.Feature.MediatR.Results.RentACarResults;
using UdemyCarBook.Application.Interfaces.RentACarInterfaces;

namespace UdemyCarBook.Application.Feature.MediatR.Handlers.RentACarHandlers
{
    public class GetRentACarQueryHandler : IRequestHandler<GetRentACarQuery, List<GetRentACarQueryResult>>
    {
        private readonly IRentACarRepository _rentACarRepository;

        public GetRentACarQueryHandler(IRentACarRepository rentACarRepository)
        {
            _rentACarRepository = rentACarRepository;
        }

        public async Task<List<GetRentACarQueryResult>> Handle(GetRentACarQuery request, CancellationToken cancellationToken)
        {
            var values = _rentACarRepository.GetByFilterAsync(x=>x.Available==true && x.LocationId==request.LocationId);
            return values.Select(x=> new GetRentACarQueryResult
            {
                CarId=x.CarId,
                BrandName = x.Car.Brand.Name,
                Model = x.Car.Model,
                CoverImage = x.Car.CoverImage
            }).ToList();
        }
    }
}

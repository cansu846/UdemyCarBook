using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Feature.CQRS.Queries.CarQueries;
using UdemyCarBook.Application.Feature.CQRS.Results.CarResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Feature.CQRS.Handlers.CarHandler
{
    public class GetCarByIdQueryHandler
    {
        private readonly IRepository<Car> _respository;

        public GetCarByIdQueryHandler(IRepository<Car> respository)
        {
            _respository = respository;
        }

        public async Task<GetCarByIdQueryResult> Handle(GetCarByIdQuery getCarByIdQuery)
        {
            var value = await _respository.GetByIdAsync(getCarByIdQuery.Id);
            return new GetCarByIdQueryResult
            {
               BrandId = value.BrandId,
               CarId = value.CarId, 
               Fuel = value.Fuel,
               Seat = value.Seat,
               Transmission = value.Transmission,
               Km = value.Km,
               CoverImage = value.CoverImage,
               Luggace = value.Luggace,
               Model = value.Model 
            };
        }
    }
}

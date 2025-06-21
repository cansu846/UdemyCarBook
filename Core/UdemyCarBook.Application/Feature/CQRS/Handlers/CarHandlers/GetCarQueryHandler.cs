using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Feature.CQRS.Results.CarResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Feature.CQRS.Handlers.CarHandler
{
    public class GetCarQueryHandler
    {
        private readonly IRepository<Car> _respository;

        public GetCarQueryHandler(IRepository<Car> respository)
        {
            _respository = respository;
        }

        public async Task<List<GetCarQueryResult>> Handle()
        {
            var values = await _respository.GetAllAsync();
            return values.Select(c=> new GetCarQueryResult
            {
                BrandId = c.BrandId,
                CarId = c.CarId,
                Fuel = c.Fuel,
                Seat = c.Seat,
                Transmission = c.Transmission,
                Km = c.Km,
                CoverImage = c.CoverImage,
                Luggace = c.Luggace,
                Model = c.Model
            }).ToList();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Feature.CQRS.Results.CarResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Application.Interfaces.CarInterfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Feature.CQRS.Handlers.CarHandlers
{
    public class GetCarWithBrandQueryHandler
    {
        private readonly ICarRepository _carRespository;

        public GetCarWithBrandQueryHandler(ICarRepository carRespository)
        {
            _carRespository = carRespository;
        }

        public List<GetCarWithBrandQueryResult> Handle()
        {
            var values = _carRespository.GetCarListWithBrands();
            return values
                .Select(c => new GetCarWithBrandQueryResult
                {
                    BrandId = c.BrandId,
                    BrandName = c.Brand?.Name,
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Feature.CQRS.Commands.CarCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Feature.CQRS.Handlers.CarHandler
{
    public class CreateCarCommandHandler
    {
        private IRepository<Car> _repository;

        public CreateCarCommandHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateCarCommand createCarCommand)
        {

            await _repository.CreateAsync(new Car
            {
                BrandId = createCarCommand.BrandId,
                Model = createCarCommand.Model,
                CoverImage = createCarCommand.CoverImage,
                Km = createCarCommand.Km,
                Transmission = createCarCommand.Transmission,
                Seat = createCarCommand.Seat,
                Luggace = createCarCommand.Luggace,
                Fuel = createCarCommand.Fuel
            });
        }
    }

}

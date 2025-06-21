using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Feature.CQRS.Commands.CarCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Feature.CQRS.Handlers.CarHandler
{
    public class UpdateCarCommandHandler
    {
        private readonly IRepository<Car> _repository;

        public UpdateCarCommandHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateCarCommand updateCarCommand)
        {
            var value = await _repository.GetByIdAsync(updateCarCommand.CarId);

            value.BrandId = updateCarCommand.BrandId;
            value.CarId = updateCarCommand.CarId;
            value.Fuel = updateCarCommand.Fuel;
            value.Seat = updateCarCommand.Seat;
            value.Transmission = updateCarCommand.Transmission;
            value.Km = updateCarCommand.Km;
            value.CoverImage = updateCarCommand.CoverImage;
            value.Luggace = updateCarCommand.Luggace;
            value.Model = updateCarCommand.Model;


            await _repository.UpdateAsync(value);
        }
    }
}

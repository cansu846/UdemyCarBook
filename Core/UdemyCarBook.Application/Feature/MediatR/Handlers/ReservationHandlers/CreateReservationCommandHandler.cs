using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Feature.MediatR.Commands.ReservationCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Feature.MediatR.Handlers.ReservationHandlers
{
    public class CreateReservationCommandHandler : IRequestHandler<CreateReservationCommand>
    {
        private readonly IRepository<Reservation> _repository;

        public CreateReservationCommandHandler(IRepository<Reservation> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateReservationCommand request, CancellationToken cancellationToken)
        {
            Reservation reservation = new Reservation {
                Name = request.Name,
                Surname = request.Surname,
                Age = request.Age,  
                CarID = request.CarID,
                Email = request.Email,
                Phone = request.Phone,
                PickUpLocationID = request.PickUpLocationID,
               DropOffLocationID = request.DropOffLocationID,
               DriverLicenseYear = request.DriverLicenseYear,   
               Description = request.Description,
               Status= "Reservation Recieved"
            };

            await _repository.CreateAsync(reservation);
        }
    }
}

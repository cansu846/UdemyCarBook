using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Feature.MediatR.Commands.CarFeatureCommands;
using UdemyCarBook.Application.Interfaces.CarFeatureInterfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Feature.MediatR.Handlers.CarFeatureHandlers
{
    public class CreateCarFeatureCommandHandler : IRequestHandler<CreateCarFeatureCommand>
    {
        private readonly ICarFeatureRepository _repository;

        public CreateCarFeatureCommandHandler(ICarFeatureRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateCarFeatureCommand request, CancellationToken cancellationToken)
        {
            _repository.CreateAsync(new CarFeature
            {
                Available = request.Available,
                CarId = request.CarId,  
                FeatureId = request.FeatureId,  
            });
        }
    }
}

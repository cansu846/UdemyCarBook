using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Feature.MediatR.Commands.ServiceCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Feature.MediatR.Handlers.ServiceHandlers
{
    public class UpdateServiceHandler:IRequestHandler<UpdateServiceCommand>
    {
        private readonly IRepository<Service> _repository;

        public UpdateServiceHandler(IRepository<Service> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateServiceCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.ServiceId);
            value.Description = request.Description;
            value.Title = request.Title;
            value.IconUrl = request.IconUrl;    
            await _repository.UpdateAsync(value);
        }
    }
}

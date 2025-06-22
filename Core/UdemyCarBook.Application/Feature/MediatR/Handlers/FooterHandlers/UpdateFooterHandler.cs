using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Feature.MediatR.Commands.FeatureCommands;
using UdemyCarBook.Application.Feature.MediatR.Commands.FooterCommand;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Feature.MediatR.Handlers.FooterHandlers
{
    public class UpdateFooterHandler : IRequestHandler<UpdateFooterCommand>
    {
        private readonly IRepository<Footer> _repository;

        public UpdateFooterHandler(IRepository<Footer> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateFooterCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.FooterId);
            value.Description = request.Description;
            value.Address = request.Address;
            value.Email = request.Email;
            value.PhoneNumber = request.PhoneNumber;

            await _repository.UpdateAsync(value);
        }

    }
}

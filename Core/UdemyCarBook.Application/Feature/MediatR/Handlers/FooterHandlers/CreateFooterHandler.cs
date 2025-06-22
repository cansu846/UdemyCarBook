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
    public class CreateFooterHandler : IRequestHandler<CreateFooterCommand>
    {
        private readonly IRepository<Footer> _repository;

        public CreateFooterHandler(IRepository<Footer> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateFooterCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Footer
            {
                Description = request.Description,
                Address = request.Address,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
            });
        }
    
    }
}

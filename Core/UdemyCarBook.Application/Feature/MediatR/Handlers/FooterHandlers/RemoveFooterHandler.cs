using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Feature.MediatR.Commands.FeatureCommands;
using UdemyCarBook.Application.Feature.MediatR.Commands.FooterCommand;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Feature.MediatR.Handlers.FooterHandlers
{
    public class RemoveFooterHandler : IRequestHandler<RemoveFooterCommand>
    {
        private readonly IRepository<Footer> _repository;

        public RemoveFooterHandler(IRepository<Footer> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveFooterCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id); 

            await _repository.RemoveAsync(value);
        }
    
    }
}

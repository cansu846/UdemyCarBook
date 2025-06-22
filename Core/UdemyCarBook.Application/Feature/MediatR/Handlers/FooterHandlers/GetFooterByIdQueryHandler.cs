using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Feature.MediatR.Commands.FeatureCommands;
using UdemyCarBook.Application.Feature.MediatR.Commands.FooterCommand;
using UdemyCarBook.Application.Feature.MediatR.Queries.FooterQueries;
using UdemyCarBook.Application.Feature.MediatR.Results.FooterResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Feature.MediatR.Handlers.FooterHandlers
{
    public class GetFooterByIdQueryHandler : IRequestHandler<GetFooterByIdQuery, GetFooterByIdQueryResult>
    {
        private readonly IRepository<Footer> _repository;

        public GetFooterByIdQueryHandler(IRepository<Footer> repository)
        {
            _repository = repository;
        }

        public async Task<GetFooterByIdQueryResult> Handle(GetFooterByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id); 

            return new GetFooterByIdQueryResult
            {
                FooterId = request.Id,  
                Description = value.Description,
                Address = value.Address,
                Email =value.Email,  
                PhoneNumber = value.PhoneNumber
            };
        }
    
    }
}

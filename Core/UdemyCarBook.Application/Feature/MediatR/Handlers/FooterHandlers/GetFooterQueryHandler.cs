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
    public class GetFooterQueryHandler : IRequestHandler<GetFooterQuery,List<GetFooterQueryResult>>
    {
        private readonly IRepository<Footer> _repository;

        public GetFooterQueryHandler(IRepository<Footer> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetFooterQueryResult>> Handle(GetFooterQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x=>new GetFooterQueryResult
            {
                Description = x.Description,
                Address = x.Address,
                Email = x.Email,
                FooterId = x.FooterId,
                PhoneNumber = x.PhoneNumber
            }).ToList();
        }
    }
}

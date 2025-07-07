using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Feature.MediatR.Commands.TagCloudCommands;
using UdemyCarBook.Application.Feature.MediatR.Queries.TagCloudQueries;
using UdemyCarBook.Application.Feature.MediatR.Results.TagCloudResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Feature.MediatR.Handlers.TagCloudHandlers
{
    public class UpdateTagCloudCommandHandler : IRequestHandler<UpdateTagCloudCommand>
    {
        private readonly IRepository<TagCloud> _repository;

        public UpdateTagCloudCommandHandler(IRepository<TagCloud> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateTagCloudCommand request, CancellationToken cancellationToken)
        {
            var tagCloud = await _repository.GetByIdAsync(request.TagCloudId);

            if (tagCloud != null) { 
                tagCloud.Title = request.Title; 
                tagCloud.BlogId = request.BlogId;   
            }
            await _repository.UpdateAsync(tagCloud);
        }
    }
}

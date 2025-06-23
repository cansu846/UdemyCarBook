using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;
using UdemyCarBook.Application.Feature.MediatR.Queries.TestimonialQueries;
using UdemyCarBook.Application.Feature.MediatR.Results.TestimonialResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Feature.MediatR.Handlers.TestimonialHandlers
{
    public class GetTestimonialByIdQueryHandler : IRequestHandler<GetTestimonialByIdQuery, GetTestimonialByIdQueryResult>
    {
        private readonly IRepository<Testimonial> _repository;

        public GetTestimonialByIdQueryHandler(IRepository<Testimonial> repository)
        {
            _repository = repository;
        }

        public async Task<GetTestimonialByIdQueryResult> Handle(GetTestimonialByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);

            return new GetTestimonialByIdQueryResult
            {
                TestimonialId = values.TestimonialId, 
                Name = values.Name,
                Title = values.Title,
                Comment = values.Comment,
                ImageUrl = values.ImageUrl
            };
        }
      
    }
}

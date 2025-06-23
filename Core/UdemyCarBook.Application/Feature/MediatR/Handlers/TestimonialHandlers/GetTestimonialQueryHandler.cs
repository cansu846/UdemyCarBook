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
    public class GetTestimonialQueryHandler : IRequestHandler<GetTestimonialQuery, List<GetTestimonialQueryResult>>
    {
        private readonly IRepository<Testimonial> _repository;

        public GetTestimonialQueryHandler(IRepository<Testimonial> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetTestimonialQueryResult>> Handle(GetTestimonialQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();

            return values.Select(x => new GetTestimonialQueryResult
            {
                TestimonialId = x.TestimonialId,
                Name = x.Name,
              ImageUrl = x.ImageUrl,
              Comment = x.Comment,
              Title = x.Title
            }).ToList();
        }
    }
}

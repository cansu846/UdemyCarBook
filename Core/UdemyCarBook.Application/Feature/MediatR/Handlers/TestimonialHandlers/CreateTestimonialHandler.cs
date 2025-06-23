using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Feature.MediatR.Commands.TestimonialCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Feature.MediatR.Handlers.TestimonialHandlers
{
    public class CreateTestimonialHandler:IRequestHandler<CreateTestimonialCommand>
    {
        private readonly IRepository<Testimonial> _repository;

        public CreateTestimonialHandler(IRepository<Testimonial> repository)
        {
            _repository = repository;
        }
        public async Task Handle(CreateTestimonialCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Testimonial
            {
                Name = request.Name,
                Title = request.Title,
                Comment = request.Comment,
                ImageUrl = request.ImageUrl
            });
        }
    
    }
}

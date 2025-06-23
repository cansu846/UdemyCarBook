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
    public class UpdateTestimonialHandler:IRequestHandler<UpdateTestimonialCommand>
    {
        private readonly IRepository<Testimonial> _repository;

        public UpdateTestimonialHandler(IRepository<Testimonial> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateTestimonialCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.TestimonialId);
            value.Name  = request.Name;
            value.Title = request.Title;    
            value.Comment = request.Comment;
            value.ImageUrl = request.ImageUrl;
            await _repository.UpdateAsync(value);
        }
      
    }
}

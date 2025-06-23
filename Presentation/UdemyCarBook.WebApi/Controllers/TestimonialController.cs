using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Application.Feature.MediatR.Commands.TestimonialCommands;
using UdemyCarBook.Application.Feature.MediatR.Queries.TestimonialQueries;

namespace UdemyCarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TestimonialController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTestimonial()
        {
            var values = await _mediator.Send(new GetTestimonialQuery());
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTestimonialById(int id)
        {
            var values = await _mediator.Send(new GetTestimonialByIdQuery(id));
            return Ok(values);
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveTestimonial(int id)
        {
            await _mediator.Send(new RemoveTestimonialCommand(id));
            return Ok("Testimonial silindi");
        }

        [HttpPost]
        public async Task<IActionResult> CreateTestimonial(CreateTestimonialCommand createTestimonialCommand)
        {
            await _mediator.Send(createTestimonialCommand);
            return Ok("Testimonial Eklendi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTestimonial(UpdateTestimonialCommand updateTestimonialCommand)
        {
            await _mediator.Send(updateTestimonialCommand);
            return Ok("Testimonial Güncellendi");
        }
    }
}

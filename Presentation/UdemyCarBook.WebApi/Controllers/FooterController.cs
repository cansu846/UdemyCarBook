using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Application.Feature.MediatR.Commands.FooterCommand;
using UdemyCarBook.Application.Feature.MediatR.Queries.FooterQueries;

namespace UdemyCarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FooterController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FooterController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllFooter()
        {
            var values = await _mediator.Send(new GetFooterQuery());
            return Ok(values);  
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFooterById(int id)
        {
            var values = await _mediator.Send(new GetFooterByIdQuery(id));
            return Ok(values);
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveFooter(int id)
        {
            await _mediator.Send(new RemoveFooterCommand(id));
            return Ok("Footer silindi");
        }

        [HttpPost]
        public async Task<IActionResult> CreateFooter(CreateFooterCommand createFooterCommand)
        {
            await _mediator.Send(createFooterCommand);
            return Ok("Footer Eklendi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateFooter(UpdateFooterCommand updateFooterCommand)
        {
            await _mediator.Send(updateFooterCommand);
            return Ok("Footer Güncellendi");
        }
    }
}

using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Application.Feature.MediatR.Commands.TagCloudCommands;
using UdemyCarBook.Application.Feature.MediatR.Queries.TagCloudQueries;

namespace UdemyCarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagCloudController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TagCloudController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTagCloud()
        {
            var values = await _mediator.Send(new GetTagCloudQuery());
            return Ok(values);
        }
        //id değişken bir degerdir yol olarak url e eklenmez
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTagCloudById(int id)
        {
            var values = await _mediator.Send(new GetTagCloudByIdQuery(id));
            return Ok(values);
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveTagCloud(int id)
        {
            await _mediator.Send(new RemoveTagCloudCommand(id));
            return Ok("TagCloud silindi");
        }

        [HttpPost]
        public async Task<IActionResult> CreateTagCloud(CreateTagCloudCommand createTagCloudCommand)
        {
            await _mediator.Send(createTagCloudCommand);
            return Ok("TagCloud Eklendi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTagCloud(UpdateTagCloudCommand updateTagCloudCommand)
        {
            await _mediator.Send(updateTagCloudCommand);
            return Ok("TagCloud Güncellendi");
        }

        //blogId, değişken değildir sabit olrak urle yol olarak eklenir
        [HttpGet("GetTagCloudByBlogId")]
        public async Task<IActionResult> GetTagCloudByBlogId(int blogId)
        {
            var values = await _mediator.Send(new GetTagCloudByBlogIdQuery(blogId));
            return Ok(values);
        }
        
    }
}

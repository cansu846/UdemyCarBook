using MediatR;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Application.Blog.MediatR.Commands.BlogCommands;
using UdemyCarBook.Application.Feature.MediatR.Handlers.BlogHandlers;
using UdemyCarBook.Application.Feature.MediatR.Queries.BlogQueries;
using UdemyCarBook.Application.Feature.MediatR.Results.BlogResults;


namespace UdemyCarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BlogController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBlog()
        {
            var values = await _mediator.Send(new GetBlogQuery());
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBlogById(int id)
        {
            var values = await _mediator.Send(new GetBlogByIdQuery(id));
            return Ok(values);
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveBlog(int id)
        {
            await _mediator.Send(new RemoveBlogCommand(id));
            return Ok("Blog silindi");
        }

        [HttpPost]
        public async Task<IActionResult> CreateBlog(CreateBlogCommand createBlogCommand)
        {
            await _mediator.Send(createBlogCommand);
            return Ok("Blog Eklendi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBlog(UpdateBlogCommand updateBlogCommand)
        {
            await _mediator.Send(updateBlogCommand);
            return Ok("Blog Güncellendi");
        }


        [HttpGet("GetLast3BlogWithAuthor")]
        public async Task<IActionResult> GetLast3BlogWithAuthor()
        {
            var values = await _mediator.Send(new GetBlogWithAuthorQuery());
            return Ok(values);
        }


        [HttpGet("GetAllBlogWithAuthor")]
        public async Task<IActionResult> GetAllBlogWithAuthor()
        {
            var values = await _mediator.Send(new GetAllBlogWithAuthorQuery());
            return Ok(values);
        }

        [HttpGet("GetBlogWithAuthorByBlogId")]
        public async Task<IActionResult> GetBlogWithAuthorByBlogId(int blogId)
        {
            var values = await _mediator.Send(new GetBlogWithAuthorByBlogIdQuery(blogId));
            return Ok(values);
        }
        
    }
}

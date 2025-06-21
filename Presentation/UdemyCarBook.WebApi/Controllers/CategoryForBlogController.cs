using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Formats.Asn1;
using UdemyCarBook.Application.Feature.CQRS.Commands.CategoryForBlogCommands;
using UdemyCarBook.Application.Feature.CQRS.Handlers.CategoryForBlogHandlers;
using UdemyCarBook.Application.Feature.CQRS.Queries.CategoryForBlogQueries;

namespace UdemyCategoryForBlogBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryForBlogController : ControllerBase
    {
        private readonly CreateCategoryForBlogCommandHandler _createCategoryForBlogCommandHandler; 
        private readonly UpdateCategoryForBlogCommandHandler _updateCategoryForBlogCommandHandler;
        private readonly RemoveCategoryForBlogCommandHandler _removeCategoryForBlogCommandHandler;
        private readonly GetCategoryForBlogByIdQueryHandler _getCategoryForBlogByIdQueryHandler;
        private readonly GetCategoryForBlogQueryHandler _getCategoryForBlogQueryHandler;

        public CategoryForBlogController(CreateCategoryForBlogCommandHandler createCategoryForBlogCommandHandler, 
            UpdateCategoryForBlogCommandHandler updateCategoryForBlogCommandHandler, 
            RemoveCategoryForBlogCommandHandler removeCategoryForBlogCommandHandler, 
            GetCategoryForBlogByIdQueryHandler getCategoryForBlogByIdQueryHandler, 
            GetCategoryForBlogQueryHandler getCategoryForBlogQueryHandler)
        {
            _createCategoryForBlogCommandHandler = createCategoryForBlogCommandHandler;
            _updateCategoryForBlogCommandHandler = updateCategoryForBlogCommandHandler;
            _removeCategoryForBlogCommandHandler = removeCategoryForBlogCommandHandler;
            _getCategoryForBlogByIdQueryHandler = getCategoryForBlogByIdQueryHandler;
            _getCategoryForBlogQueryHandler = getCategoryForBlogQueryHandler;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategoryForBlog()
        {
            var values = await _getCategoryForBlogQueryHandler.Handle();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryForBlogById(int id)
        {
            var value = await _getCategoryForBlogByIdQueryHandler.Handle( new GetCategoryForBlogByIdQuery(id));
            return Ok(value);
        }

        [HttpDelete]  
        public async Task<IActionResult> Remove(int id)
        {
            await _removeCategoryForBlogCommandHandler.Handle(new RemoveCategoryForBlogCommand(id));
            return Ok("CategoryForBlog silindi...");    
        }

        [HttpPost]  
        public async Task<IActionResult> CreateCategoryForBlog(CreateCategoryForBlogCommand createCategoryForBlogCommand)
        {
            await _createCategoryForBlogCommandHandler.Handle(createCategoryForBlogCommand);
            return Ok("CategoryForBlog eklendi...");
        }

        [HttpPut]  
        public async Task<IActionResult> UpdateCategoryForBlog(UpdateCategoryForBlogCommand updateCategoryForBlogCommand)
        {
            await _updateCategoryForBlogCommandHandler.Handle(updateCategoryForBlogCommand);
            return Ok("CategoryForBlog güncellendi...");
        }

  
    }
}

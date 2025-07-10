using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;
using UdemyCarBook.Dtos.CommentDtos;

namespace UdemyCarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly IRepository<Comment> _commentRepository;

        public CommentController(IRepository<Comment> commentRepository)
        {
            _commentRepository = commentRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllComment()
        {
            var values = await _commentRepository.GetAllAsync();
            return Ok(values);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteComment(int id)
        {
            var value = await _commentRepository.GetByIdAsync(id);
            await _commentRepository.RemoveAsync(value);
            return Ok("Yorum başarıyla silindi.");
        }

        [HttpPost]
        public async Task<IActionResult> CreateComment(CreateCommentDto createCommentDto)
        {
            var value = new Comment
            {
                Name = createCommentDto.Name,
                BlogId = createCommentDto.BlogId,
                CreatedDate = DateTime.Now,
                Description = createCommentDto.Description,
            };
            await _commentRepository.CreateAsync(value);
            return Ok("Yorum başarıyla eklendi.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateComment(UpdateCommentDto updateCommentDto)
        {
            var value = await _commentRepository.GetByIdAsync(updateCommentDto.CommentId);
            value.CommentId = updateCommentDto.CommentId;
            value.Name = updateCommentDto.Name;
            value.BlogId = updateCommentDto.BlogId;
            value.CreatedDate = DateTime.Now;
            value.Description = updateCommentDto.Description;

            await _commentRepository.UpdateAsync(value);
            return Ok("Yorum başarıyla güncellendi.");
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using UdemyCarBook.Dto.ReservationDtos;
using UdemyCarBook.Dtos.BlogDtos;
using UdemyCarBook.Dtos.CommentDtos;

namespace UdemyCarBook.WebUI.Controllers
{
    public class BlogController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BlogController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Blog";
            ViewBag.v2 = "Our Author Blogs";
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7277/api/Blog/GetAllBlogWithAuthor");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<List<ResultAllBlogWithAuthor>>(jsonData);
                return View(data);
            }
            return View();
        }

        public IActionResult BlogDetail(int id)
        {
            ViewBag.v1 = "Blog";
            ViewBag.v2 = "Blog Detail";
            ViewBag.blogId = id;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> BlogDetailMainLeaveCommentComponentPartial(CreateCommentDto createCommentDto )
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createCommentDto);
            var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var resultMessage = await client.PostAsync("https://localhost:7277/api/Comment\r\n", stringContent);

            if (resultMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("BlogDetail","Blog",new {id=createCommentDto.BlogId});
            }

            return View();
        }
    }
}

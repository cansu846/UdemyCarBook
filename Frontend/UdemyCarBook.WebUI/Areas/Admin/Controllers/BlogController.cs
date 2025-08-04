using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;
using UdemyCarBook.Dto.BlogDtos;
using UdemyCarBook.Dtos.AuthorDtos;
using UdemyCarBook.Dtos.BlogDtos;
using UdemyCarBook.Dtos.CategoryDtos;


namespace UdemyBlogBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    public class BlogController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BlogController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var result = await client.GetAsync("https://localhost:7277/api/Blog/GetAllBlogWithAuthor");
            if (result.IsSuccessStatusCode)
            {
                var jsonData = await result.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultAllBlogWithAuthor>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CreateBlog()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage1 = await client.GetAsync("https://localhost:7277/api/Author");
            var responseMessage2 = await client.GetAsync("https://localhost:7277/api/CategoryForBlog");
            if(responseMessage1.IsSuccessStatusCode && responseMessage2.IsSuccessStatusCode)
            {
                var authors = await responseMessage1.Content.ReadAsStringAsync();
                var categories = await responseMessage2.Content.ReadAsStringAsync();

                var authorsJson = JsonConvert.DeserializeObject<List<ResultAuthorDto>>(authors);
                var categoriesJson = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(categories);

                
                ViewBag.authors = authorsJson.Select(x=> new SelectListItem
                {
                    Text=x.name,
                    Value = x.authorId.ToString(),
                }).ToList();

                ViewBag.categories = categoriesJson.Select(x=> new SelectListItem
                {
                    Text=x.name,
                    Value = x.categoryForBlogId.ToString(), 
                }).ToList();
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBlog(CreateBlogDto createBlogDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createBlogDto);
            var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7277/api/Blog", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Blog", new { area = "Admin" });
            }
            return View();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> DeleteBlog(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7277/api/Blog?id={id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Blog", new { area = "Admin" });
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateBlog(int id)
        {
            var client = _httpClientFactory.CreateClient();
            
            var responseMessage = await client.GetAsync($"https://localhost:7277/api/Blog/{id}");

            var responseMessage1 = await client.GetAsync("https://localhost:7277/api/Author");
            var responseMessage2 = await client.GetAsync("https://localhost:7277/api/CategoryForBlog");

            if (responseMessage1.IsSuccessStatusCode && responseMessage2.IsSuccessStatusCode && responseMessage.IsSuccessStatusCode)
            {
                var authors = await responseMessage1.Content.ReadAsStringAsync();
                var categories = await responseMessage2.Content.ReadAsStringAsync();

                var authorsJson = JsonConvert.DeserializeObject<List<ResultAuthorDto>>(authors);
                var categoriesJson = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(categories);


                ViewBag.authors = authorsJson.Select(x => new SelectListItem
                {
                    Text = x.name,
                    Value = x.authorId.ToString(),
                }).ToList();

                ViewBag.categories = categoriesJson.Select(x => new SelectListItem
                {
                    Text = x.name,
                    Value = x.categoryForBlogId.ToString(),
                }).ToList();

                var jsonDataBlog = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultBlogDto>(jsonDataBlog);
                return View(values);
            }

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> UpdateBlog(UpdateBlogDto updateBlogDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateBlogDto);
            var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7277/api/Blog", stringContent);
          
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Blog", new { Area = "Admin" });
            }
            return View();
        }
    }
}

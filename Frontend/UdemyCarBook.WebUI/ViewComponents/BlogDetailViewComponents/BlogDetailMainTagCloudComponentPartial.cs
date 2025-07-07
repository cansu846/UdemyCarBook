using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UdemyCarBook.Dtos.CategoryDtos;
using UdemyCarBook.Dtos.TagCloudDtos;

namespace UdemyCarBook.WebUI.ViewComponents.BlogDetailViewComponents
{
    public class BlogDetailMainTagCloudComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BlogDetailMainTagCloudComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(int blogId)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7277/api/TagCloud/GetTagCloudByBlogId?blogId={blogId}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultTagCloudByBlogIdDto>>(jsonData);
                Console.WriteLine(values);
                return View(values);
            }
            return View();
        }
    }
}

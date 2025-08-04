using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using UdemyCarBook.Dtos.BlogDtos;

namespace UdemyCarBook.WebUI.ViewComponents.BlogDetailViewComponents
{
    public class BlogDetailMainCommentComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public BlogDetailMainCommentComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(int blogId)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7277/api/Comment/GetCommentListByBlogId?id={blogId}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBlogWithCommentByBlogIdDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}

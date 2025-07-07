using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UdemyCarBook.Dtos.BannerDtos;
using UdemyCarBook.Dtos.BlogDtos;

namespace UdemyCarBook.WebUI.ViewComponents.DefaultComponents
{
    public class Last3BlogWithAuthorComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public Last3BlogWithAuthorComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7277/api/Blog/GetLast3BlogWithAuthor\r\n");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<List<ResultLast3BlogWithAuthor>>(jsonData);
                return View(data);
            }
            return View();
        }
    }
}

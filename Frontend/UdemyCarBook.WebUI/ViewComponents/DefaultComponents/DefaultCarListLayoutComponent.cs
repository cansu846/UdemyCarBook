using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UdemyCarBook.Dtos.CarDtos;

namespace UdemyCarBook.WebUI.ViewComponents.DefaultComponents
{
    public class DefaultCarListLayoutComponent : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DefaultCarListLayoutComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7277/api/Car");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<List<ResultCarDto>>(jsonData);
                return View(data);
            }
            return View();
        }
    }
}

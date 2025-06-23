using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UdemyCarBook.Dtos.ServiceDtos;

namespace UdemyCarBook.WebUI.Controllers
{
    public class ServiceController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ServiceController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7277/api/Service");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<List<ResultServiceDto>>(jsonData); 
                return View(data);
            }
            return View();
        }
    }
}

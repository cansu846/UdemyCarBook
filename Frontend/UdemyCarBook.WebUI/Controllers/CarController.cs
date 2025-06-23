using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;
using UdemyCarBook.Dtos.CarDtos;

namespace UdemyCarBook.WebUI.Controllers
{
    public class CarController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CarController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
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

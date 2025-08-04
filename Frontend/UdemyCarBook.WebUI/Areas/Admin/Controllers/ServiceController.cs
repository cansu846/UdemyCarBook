using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;
using UdemyCarBook.Dtos.ServiceDtos;


namespace UdemyAboutBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
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
            var result = await client.GetAsync("https://localhost:7277/api/Service");
            if (result.IsSuccessStatusCode)
            {
                var jsonData = await result.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultServiceDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CreateService()
        {
            
            return View();
        }

        //[HttpPost]
        //public async Task<IActionResult> CreateService(CreateServiceDto createServiceDto)
        //{
        //    var client = _httpClientFactory.CreateClient();
        //    var jsonData = JsonConvert.SerializeObject(createServiceDto);
        //    var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
        //    var responseMessage = await client.PostAsync("https://localhost:7277/api/Service", stringContent);
        //    if (responseMessage.IsSuccessStatusCode)
        //    {
        //        return RedirectToAction("Index", "Service", new { area = "Admin" });
        //    }
        //    return View();
        //}

        //[HttpGet("{id}")]
        //public async Task<IActionResult> DeleteService(int id)
        //{
        //    var client = _httpClientFactory.CreateClient();
        //    var responseMessage = await client.DeleteAsync($"https://localhost:7277/api/Service?id={id}");
        //    if (responseMessage.IsSuccessStatusCode)
        //    {
        //        return RedirectToAction("Index", "Service", new { area = "Admin" });
        //    }
        //    return View();
        //}

        //[HttpGet]
        //public async Task<IActionResult> UpdateService(int id)
        //{
        //    var client = _httpClientFactory.CreateClient();
            
        //    var responseMessage = await client.GetAsync($"https://localhost:7277/api/Service/{id}");
        //    if (responseMessage.IsSuccessStatusCode)
        //    {
        //        var jsonDataService = await responseMessage.Content.ReadAsStringAsync();
        //        var values = JsonConvert.DeserializeObject<ResultServiceDto>(jsonDataService);
        //        return View(values);
        //    }
        //    return View();
        //}


        //[HttpPost]
        //public async Task<IActionResult> UpdateService(UpdateServiceDto updateServiceDto)
        //{
        //    var client = _httpClientFactory.CreateClient();
        //    var jsonData = JsonConvert.SerializeObject(updateServiceDto);
        //    var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
        //    var responseMessage = await client.PutAsync("https://localhost:7277/api/Service", stringContent);
          
        //    if (responseMessage.IsSuccessStatusCode)
        //    {
        //        return RedirectToAction("Index", "Service", new { Area = "Admin" });
        //    }
        //    return View();
        //}
    }
}

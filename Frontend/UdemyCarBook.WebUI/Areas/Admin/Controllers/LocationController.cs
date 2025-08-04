using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;
using UdemyCarBook.Dtos.LocationDtos;


namespace UdemyAboutBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    public class LocationController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public LocationController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var result = await client.GetAsync("https://localhost:7277/api/Location");
            if (result.IsSuccessStatusCode)
            {
                var jsonData = await result.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultLocationDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CreateLocation()
        {
            
            return View();
        }

        //[HttpPost]
        //public async Task<IActionResult> CreateLocation(CreateLocationDto createLocationDto)
        //{
        //    var client = _httpClientFactory.CreateClient();
        //    var jsonData = JsonConvert.SerializeObject(createLocationDto);
        //    var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
        //    var responseMessage = await client.PostAsync("https://localhost:7277/api/Location", stringContent);
        //    if (responseMessage.IsSuccessStatusCode)
        //    {
        //        return RedirectToAction("Index", "Location", new { area = "Admin" });
        //    }
        //    return View();
        //}

        //[HttpGet("{id}")]
        //public async Task<IActionResult> DeleteLocation(int id)
        //{
        //    var client = _httpClientFactory.CreateClient();
        //    var responseMessage = await client.DeleteAsync($"https://localhost:7277/api/Location?id={id}");
        //    if (responseMessage.IsSuccessStatusCode)
        //    {
        //        return RedirectToAction("Index", "Location", new { area = "Admin" });
        //    }
        //    return View();
        //}

        //[HttpGet]
        //public async Task<IActionResult> UpdateLocation(int id)
        //{
        //    var client = _httpClientFactory.CreateClient();
            
        //    var responseMessage = await client.GetAsync($"https://localhost:7277/api/Location/{id}");
        //    if (responseMessage.IsSuccessStatusCode)
        //    {
        //        var jsonDataLocation = await responseMessage.Content.ReadAsStringAsync();
        //        var values = JsonConvert.DeserializeObject<ResultLocationDto>(jsonDataLocation);
        //        return View(values);
        //    }
        //    return View();
        //}


        //[HttpPost]
        //public async Task<IActionResult> UpdateLocation(UpdateLocationDto updateLocationDto)
        //{
        //    var client = _httpClientFactory.CreateClient();
        //    var jsonData = JsonConvert.SerializeObject(updateLocationDto);
        //    var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
        //    var responseMessage = await client.PutAsync("https://localhost:7277/api/Location", stringContent);
          
        //    if (responseMessage.IsSuccessStatusCode)
        //    {
        //        return RedirectToAction("Index", "Location", new { Area = "Admin" });
        //    }
        //    return View();
        //}
    }
}

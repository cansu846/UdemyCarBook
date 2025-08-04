using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Newtonsoft.Json;
using System.Text;
using UdemyCarBook.Dtos.ContactDtos;
using UdemyCarBook.Dtos.LocationDtos;
using UdemyCarBook.WebUI.Models;

namespace UdemyCarBook.WebUI.Controllers
{
    public class DefaultController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DefaultController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7277/api/Location");
          
            if (responseMessage.IsSuccessStatusCode)
            {
                var values = await responseMessage.Content.ReadAsStringAsync();
                var jsonData = JsonConvert.DeserializeObject<List<ResultLocationDto>>(values);
                ViewBag.locations = jsonData;
            }
            return View();
        }

        [HttpPost]
        public IActionResult Index(RentCarRequestViewModel model)
        {
            TempData["rentACarViewModel"] = JsonConvert.SerializeObject(model);
            return RedirectToAction("Index", "RentACarList");
        }
    }
}

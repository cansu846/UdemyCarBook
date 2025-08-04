using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using UdemyCarBook.Dtos.RentACarDtos;
using UdemyCarBook.Dtos.ServiceDtos;
using UdemyCarBook.WebUI.Models;

namespace UdemyCarBook.WebUI.Controllers
{
    public class RentACarListController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public RentACarListController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var json = TempData["rentACarViewModel"].ToString();
            var value = JsonConvert.DeserializeObject<RentCarRequestViewModel>(json);
            var locationId = value.SelectedLocation;
            ViewBag.rentACarFilter = value;

            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync($"https://localhost:7277/api/RentACar?locationId={locationId}&available=true");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<List<ResultRentACarDto>>(jsonData);
                return View(data);
            }
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;
using UdemyCarBook.Dto.ReservationDtos;
using UdemyCarBook.Dtos.LocationDtos;

namespace UdemyCarBook.WebUI.Controllers
{
    public class ReservationController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public ReservationController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int id)
        {
            ViewBag.v1 = "Car Rental";
            ViewBag.v2 = "Car Reservation Form";

            ViewBag.v3 = id;


            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7277/api/Location\r\n");

            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultLocationDto>>(jsonData);
            List<SelectListItem> values2 = (from x in values
                                            select new SelectListItem
                                            {
                                                Text = x.LocationName,
                                                Value = x.LocationId.ToString()
                                            }).ToList();
            ViewBag.v = values2;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreateReservationDto createReservationDto)
        {
         
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createReservationDto);
            var stringContent = new StringContent(jsonData,Encoding.UTF8,"application/json");
            var resultMessage = await client.PostAsync("https://localhost:7277/api/Reservation\r\n",stringContent);

            if (resultMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index","Default");
            }

            return View(createReservationDto);
        }
    }
}

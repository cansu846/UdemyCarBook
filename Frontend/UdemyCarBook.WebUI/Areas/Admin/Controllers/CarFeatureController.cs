using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Domain.Entities;
using UdemyCarBook.Dtos.CarDtos;
using UdemyCarBook.Dtos.CarFeaturesDtos;
using UdemyCarBook.Dtos.CarPricingWithCarDto;
using UdemyCarBook.Dtos.FeatureDtos;

namespace UdemyCarBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    public class CarFeatureController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CarFeatureController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index(int carId)
        {
            ViewBag.carId = carId;

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7277/api/CarFeature/GetCarFeatureByCarId?carId={carId}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<List<ResultCarFeatureByCarIdDto>>(jsonData);
                ViewBag.carıd = carId;
                return View(data);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(List<UpdateCarFeatureByCarIdDto> list)
        {

            foreach (var carFeature in list)
            {
                var client = _httpClientFactory.CreateClient();
                var carFeatureId = carFeature.CarFeatureId;
                var jsonData = JsonConvert.SerializeObject(carFeatureId);
                var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                HttpResponseMessage responseMessage;
                if (carFeature.Available)
                {
                    responseMessage = await client.PutAsync($"https://localhost:7277/api/CarFeature/UpdateCarFeatureAvailableToTrue?carFeatureId={carFeatureId}\r\n", stringContent);
                }
                else
                {
                    responseMessage = await client.PutAsync($"https://localhost:7277/api/CarFeature/UpdateCarFeatureAvailableToFalse?carFeatureId={carFeatureId}\r\n", stringContent);

                }
                if (!responseMessage.IsSuccessStatusCode)
                {

                    return View(list);
                }
            }
            return RedirectToAction("Index", "Car");

        }

        [HttpGet]
        public async Task<IActionResult> CreateCarFeatureByCarId(int carId)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7277/api/Feature");
            if (!responseMessage.IsSuccessStatusCode)
            {
                return View(new List<CreateCarFeatureByCarIdDto>());
            }

            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var features = JsonConvert.DeserializeObject<List<ResultFeatureDto>>(jsonData);

            var model = features.Select(x => new CreateCarFeatureByCarIdDto
            {
                FeatureId = x.FeatureId,
                FeatureName = x.FeatureName,
                CarId = carId,
                Available = false
            }).ToList();
            return View(model);

        }
        [HttpPost]
        public async Task<IActionResult> CreateCarFeatureByCarId(List<CreateCarFeatureByCarIdDto> list)
        {

            var client = _httpClientFactory.CreateClient();
            foreach (var item in list)
            {
                CarFeature carFeature = new CarFeature
                {
                    Available = item.Available,
                    FeatureId = item.FeatureId,
                    CarId = item.CarId,
                };
                var jsonData = JsonConvert.SerializeObject(carFeature);
                var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var responseMessage = await client.PostAsync($"https://localhost:7277/api/CarFeature\r\n", stringContent);
                if (!responseMessage.IsSuccessStatusCode)
                {
                    return View(list);
                }
            }

            return RedirectToAction("Index", "Car");
        }
    }
}

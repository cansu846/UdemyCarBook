using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Dtos.BrandDtos;
using UdemyCarBook.Dtos.CarDtos;

namespace UdemyCarBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
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
            var result = await client.GetAsync("https://localhost:7277/api/Car");
            if (result.IsSuccessStatusCode)
            {
                var jsonData = await result.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCarDto>>(jsonData);   
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CreateCar()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7277/api/Brand");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync(); 
                var values = JsonConvert.DeserializeObject<List<ResultBrandDto>>(jsonData);
                List<SelectListItem> selectListItems = (from item in values
                                                       select new SelectListItem {
                                                           Text=item.Name,
                                                           Value = item.BrandId.ToString(),
                                                       }).ToList();
                ViewBag.brandValues = selectListItems;
            }
            return View();  
        }

        [HttpPost]
        public async Task<IActionResult> CreateCar(CreateCarDto createCarDto)
        {
            var client = _httpClientFactory.CreateClient();

            if (!ModelState.IsValid)
            {
                var responseMessage1 = await client.GetAsync("https://localhost:7277/api/Brand");
                if (responseMessage1.IsSuccessStatusCode)
                {
                    var jsonData1 = await responseMessage1.Content.ReadAsStringAsync();
                    var values = JsonConvert.DeserializeObject<List<ResultBrandDto>>(jsonData1);
                    List<SelectListItem> selectListItems = (from item in values
                                                            select new SelectListItem
                                                            {
                                                                Text = item.Name,
                                                                Value = item.BrandId.ToString(),
                                                            }).ToList();
                    ViewBag.brandValues = selectListItems;
                }
            }

            var jsonData = JsonConvert.SerializeObject(createCarDto);
            var stringContent = new StringContent(jsonData,Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7277/api/Car",stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index","Car", new {area="Admin"});  
            }
            return View();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> DeleteCar(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7277/api/Car?id={id}");
            if (responseMessage.IsSuccessStatusCode) {
                return RedirectToAction("Index", "Car", new { area = "Admin" });
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateCar(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessageBrand = await client.GetAsync("https://localhost:7277/api/Brand");
            if (responseMessageBrand.IsSuccessStatusCode)
            {
                var jsonDataBrand = await responseMessageBrand.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBrandDto>>(jsonDataBrand);
                List<SelectListItem> selectListItems = (from item in values
                                                        select new SelectListItem
                                                        {
                                                            Text = item.Name,
                                                            Value = item.BrandId.ToString(),
                                                        }).ToList();
                ViewBag.brandValues = selectListItems;
            }
            var responseMessage = await client.GetAsync($"https://localhost:7277/api/Car/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonDataCar = await responseMessage.Content.ReadAsStringAsync();
                var carValues = JsonConvert.DeserializeObject<ResultCarDto>(jsonDataCar);
                return View(carValues);
            }
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> UpdateCar(UpdateCarDto updateCarDto)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessageBrand = await client.GetAsync("https://localhost:7277/api/Brand");
            if (responseMessageBrand.IsSuccessStatusCode)
            {
                var jsonDataBrand = await responseMessageBrand.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBrandDto>>(jsonDataBrand);
                List<SelectListItem> selectListItems = (from item in values
                                                        select new SelectListItem
                                                        {
                                                            Text = item.Name,
                                                            Value = item.BrandId.ToString(),
                                                        }).ToList();
                ViewBag.brandValues = selectListItems;
            }
            var jsonDataCar = JsonConvert.SerializeObject(updateCarDto);
            var stringContent = new StringContent(jsonDataCar,Encoding.UTF8,"application/json");

            var responseMessage = await client.PostAsync($"https://localhost:7277/api/Car",stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index","Car", new {Area="Admin"});
            }
            return View();
        }
    }
} 

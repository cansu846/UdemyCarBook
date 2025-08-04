using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using UdemyCarBook.Dtos.CarAndCarFeatureDtos;
using UdemyCarBook.Dtos.CarDtos;
using UdemyCarBook.Dtos.CarFeaturesDtos;


namespace UdemyCarBook.WebUI.ViewComponents.CarDetailComponents
{
    public class _CarDetailMainContentComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _CarDetailMainContentComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(int carId)
        {
            ViewBag.carId = carId;

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7277/api/Car/{carId}\r\n");
            var responseMessage2 = await client.GetAsync($"https://localhost:7277/api/CarFeature/GetCarFeatureByCarId?carId={carId}");
            if (responseMessage.IsSuccessStatusCode && responseMessage2.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
                var carInfo = JsonConvert.DeserializeObject<ResultCarDto>(jsonData);
                var carFeatures = JsonConvert.DeserializeObject<List<ResultCarFeatureByCarIdDto>>(jsonData2);
                ResultCarAndCarFeatureDto resultCarAndCarFeatureDto = new ResultCarAndCarFeatureDto
                {
                    resultCarDto = carInfo,
                    resultCarFeatureByCarIdDto = carFeatures
                };
                return View(resultCarAndCarFeatureDto);
            }
            return View();
        }
    }
}


using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UdemyCarBook.Dtos.ContactDtos;

namespace UdemyCarBook.WebUI.ViewComponents.ContactViewComponents
{
    public class ContactAddressComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ContactAddressComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7277/api/Footer");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<List<ResultContactAddressDto>>(jsonData);
                return View(data);
            }
            return View();
        }
    }
}

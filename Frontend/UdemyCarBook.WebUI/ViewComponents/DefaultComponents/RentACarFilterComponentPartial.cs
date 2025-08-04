using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using UdemyCarBook.Dtos.BannerDtos;
using UdemyCarBook.Dtos.LocationDtos;

namespace UdemyCarBook.WebUI.ViewComponents.DefaultComponents
{
    public class RentACarFilterComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public RentACarFilterComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(List<ResultLocationDto> locations)
        {
            
            ViewBag.locations = locations.Select(x=> new SelectListItem
            {
                Text=x.LocationName,
                Value=x.LocationId.ToString(),
            }).ToList();  
            return View();
        }

    }
}
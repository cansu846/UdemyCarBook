using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UdemyCarBook.Dtos.BannerDtos;

namespace UdemyCarBook.WebUI.ViewComponents.DefaultComponents
{
    public class StatisticsComponentPartial : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {

            return View();
        }

    }
}

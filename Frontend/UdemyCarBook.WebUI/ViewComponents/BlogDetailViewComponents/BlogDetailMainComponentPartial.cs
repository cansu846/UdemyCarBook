using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UdemyCarBook.Dtos.BlogDtos;

namespace UdemyCarBook.WebUI.ViewComponents.BlogDetailViewComponents
{
    public class BlogDetailMainComponentPartial : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(int blogId)
        {
            ViewBag.blogId = blogId;
            return View();
        }

    }
}

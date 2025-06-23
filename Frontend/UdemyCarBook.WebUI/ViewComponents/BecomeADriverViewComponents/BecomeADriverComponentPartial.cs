using Microsoft.AspNetCore.Mvc;

namespace UdemyCarBook.WebUI.ViewComponents.BecomeADriverViewComponents
{
    public class BecomeADriverComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

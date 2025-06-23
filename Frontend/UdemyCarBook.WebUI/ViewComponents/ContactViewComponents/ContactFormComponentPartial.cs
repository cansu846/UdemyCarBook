using Microsoft.AspNetCore.Mvc;

namespace UdemyCarBook.WebUI.ViewComponents.ContactViewComponents
{
    public class ContactFormComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }

    }
}

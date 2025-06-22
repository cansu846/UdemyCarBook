using Microsoft.AspNetCore.Mvc;

namespace UdemyCarBook.WebUI.ViewComponents
{
    public class _NavbarLayoutComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();  
        }
    }
}

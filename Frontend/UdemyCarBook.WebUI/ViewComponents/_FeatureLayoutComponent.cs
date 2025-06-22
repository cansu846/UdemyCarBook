using Microsoft.AspNetCore.Mvc;

namespace UdemyCarBook.WebUI.ViewComponents
{
    public class _FeatureLayoutComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();  
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace UdemyCarBook.WebUI.Controllers
{
    public class _UILayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

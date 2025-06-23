using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;
using UdemyCarBook.Dtos.ContactDtos;

namespace UdemyCarBook.WebUI.Controllers
{
    public class ContactController : Controller
    {
      
        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}

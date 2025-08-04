using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Dtos.ContactDtos;

namespace UdemyCarBook.WebUI.Controllers
{
    public class ContactController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ContactController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]   
        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Contact";
            ViewBag.v2 = "Contact To Us";
            return View();
        }

        [HttpPost]  
        public async Task<IActionResult> Index(CreateContactFormDto createContactFormDto)
        {
            var client = _httpClientFactory.CreateClient();
            //createContactFormDto.SendDate = DateTime.Now;
            var jsonData =  JsonConvert.SerializeObject(createContactFormDto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8,"application/json");
            var responseMessage = await client.PostAsync("https://localhost:7277/api/Contact", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index","Default");
            }
            return View();  
        }
    }
}

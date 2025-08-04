using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using UdemyCarBook.Dtos.AppUserDtos;

namespace UdemyCarBook.WebUI.Controllers
{
    public class RegisterController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public RegisterController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public IActionResult CreateUser()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserDto createUserDto)
        {
            if (!ModelState.IsValid)
            {
                return View(createUserDto);  
            }
            var client = _httpClientFactory.CreateClient(); 
            var jsonData = JsonConvert.SerializeObject(createUserDto);  
            var content = new StringContent(jsonData,Encoding.UTF8,"application/json");
           var resultMessage =  await client.PostAsync("https://localhost:7277/api/Register", content);
            if (resultMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index","Default");
            }
            return View(createUserDto);
        }
    }
}

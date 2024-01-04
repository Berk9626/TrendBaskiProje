using ECommerce.WebUI.Dtos.BookingDto;
using ECommerce.WebUI.Dtos.ContactDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace ECommerce.WebUI.Controllers.Request
{
    [AllowAnonymous]
    public class ContactController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ContactController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        //------------------------------------------------------------------------------------------------------------------------------
        public IActionResult Index()
        {
            return View();
        }
        //------------------------------------------------------------------------------------------------------------------------------
        [HttpGet]
        public PartialViewResult SendMessage()
        {
            return PartialView();
        }
        //------------------------------------------------------------------------------------------------------------------------------
        [HttpPost]
        public async Task<IActionResult> SendMessage(CreateContactDto createContactDto)
        {         
            createContactDto.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createContactDto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            await client.PostAsync("http://localhost:59815/api/Contact", content);
            return RedirectToAction("Index", "Default");
        }
        //------------------------------------------------------------------------------------------------------------------------------
    }
}

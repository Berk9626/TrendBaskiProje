using ECommerce.WebUI.Dtos.SubscribeDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace ECommerce.WebUI.Controllers.Others
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DefaultController(IHttpClientFactory httpClientFactory)
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
        public PartialViewResult _SubscribePartialAsync()
        {
            return PartialView();
        }
        //------------------------------------------------------------------------------------------------------------------------------
        [HttpPost]
        public async Task<IActionResult> _SubscribePartialAsync(CreateSubscribeDto SubscribeDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(SubscribeDto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            await client.PostAsync("http://localhost:59815/api/Subscribe", content);

            return RedirectToAction("Index", "Default");


        }
        //------------------------------------------------------------------------------------------------------------------------------
    }
}

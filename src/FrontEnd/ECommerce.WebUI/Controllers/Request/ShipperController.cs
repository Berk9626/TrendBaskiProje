using ECommerce.WebUI.Dtos.ShipperDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ECommerce.WebUI.Controllers.Request
{
    [AllowAnonymous]
    public class ShipperController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public ShipperController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        //------------------------------------------------------------------------------------------------------------------------------
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:59815/api/Shipper/GetActivesShipper/");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultShipperDto>>(jsonData);
                return View(values);
            }
            return View();
        }
        //------------------------------------------------------------------------------------------------------------------------------
    }
}

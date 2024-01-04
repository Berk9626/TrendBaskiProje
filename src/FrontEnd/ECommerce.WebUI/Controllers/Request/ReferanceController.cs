using ECommerce.WebUI.Dtos.ReferanceDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ECommerce.WebUI.Controllers.Request
{
    [AllowAnonymous]
    public class ReferanceController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public ReferanceController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        //------------------------------------------------------------------------------------------------------------------------------
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:59815/api/Referance/GetActivesReferance/");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultReferanceDto>>(jsonData);

                return View(values);
            }
            return View();
        }
        //------------------------------------------------------------------------------------------------------------------------------
    }
}

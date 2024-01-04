using ECommerce.WebUI.Dtos.SupplierDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ECommerce.WebUI.Controllers.Request
{
    [AllowAnonymous]
    public class SupplierController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public SupplierController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        //------------------------------------------------------------------------------------------------------------------------------
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:59815/api/Supplier/GetActivesSupplier/");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultSupplierDto>>(jsonData);
                return View(values);
            }
            return View();
        }
        //------------------------------------------------------------------------------------------------------------------------------
    }
}

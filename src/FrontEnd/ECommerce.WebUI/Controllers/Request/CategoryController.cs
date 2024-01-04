using ECommerce.WebUI.Dtos.CategoryDto;
using ECommerce.WebUI.Dtos.ProductDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ECommerce.WebUI.Controllers.Request
{
    [AllowAnonymous]
    public class CategoryController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public CategoryController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        //------------------------------------------------------------------------------------------------------------------------------
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:59815/api/Product/GetActivesCategory/");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);

                return View(values);
            }
            return View();
        }
        //------------------------------------------------------------------------------------------------------------------------------
        [HttpGet]
        public async Task<IActionResult> CategoryDetail(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:59815/api/Category/GetProductsWithCategoryId/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);

                return View(values);
            }
            return View();
        }
        //------------------------------------------------------------------------------------------------------------------------------
    }
}

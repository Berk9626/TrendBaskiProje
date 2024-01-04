using ECommerce.WebUI.Dtos.EmployeeDto;
using ECommerce.WebUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace ECommerce.WebUI.Controllers.Request
{
    [AllowAnonymous]
    public class EmployeeController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public EmployeeController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        //------------------------------------------------------------------------------------------------------------------------------
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:59815/api/Employee/GetActivesEmployee/");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultEmployeeDto>>(jsonData);

                return View(values);
            }
            return View();
        }
        //------------------------------------------------------------------------------------------------------------------------------


    }
}

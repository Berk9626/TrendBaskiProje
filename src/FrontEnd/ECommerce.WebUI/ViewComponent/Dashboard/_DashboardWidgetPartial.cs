using ECommerce.WebUI.Dtos.EmployeeDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ECommerce.WebUI.ViewComponent.Dashboard
{
    public class _DashboardWidgetPartial : Microsoft.AspNetCore.Mvc.ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DashboardWidgetPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:59815/api/DashboardWidget/EmployeeCount"); 
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            ViewBag.EmployeeCount = jsonData;

            var client2 = _httpClientFactory.CreateClient();
            var responseMessage2 = await client2.GetAsync("http://localhost:59815/api/DashboardWidget/BookingCount"); 
            var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
            ViewBag.BookingCount = jsonData2;

            var client3 = _httpClientFactory.CreateClient();
            var responseMessage3 = await client3.GetAsync("http://localhost:59815/api/DashboardWidget/ProductCount");
            var jsonData3 = await responseMessage3.Content.ReadAsStringAsync();
            ViewBag.ProductCount = jsonData3;

            var client4 = _httpClientFactory.CreateClient();
            var responseMessage4 = await client4.GetAsync("http://localhost:59815/api/DashboardWidget/OrderCount");
            var jsonData4 = await responseMessage4.Content.ReadAsStringAsync();
            ViewBag.OrderCount = jsonData4;
            return View();
        }
    }
}




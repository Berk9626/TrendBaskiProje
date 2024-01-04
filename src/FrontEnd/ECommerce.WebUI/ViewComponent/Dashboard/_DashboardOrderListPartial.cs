using ECommerce.DataAccessLayer.Concrete;
using ECommerce.WebUI.Dtos.EmployeeDto;
using ECommerce.WebUI.Dtos.OrderDto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace ECommerce.WebUI.ViewComponent.Dashboard
{
    public class _DashboardOrderListPartial : Microsoft.AspNetCore.Mvc.ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public _DashboardOrderListPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
                     
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:59815/api/Order/GetLastFourOrder/");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultLastFourOrderDto>>(jsonData);
                return View(values);

            }
            return View();

        }
    }
}

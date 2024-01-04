using ECommerce.WebUI.Dtos.EmployeeDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ECommerce.WebUI.ViewComponent.Dashboard
{
    public class _DashboardLastFourEmployeeList : Microsoft.AspNetCore.Mvc.ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public _DashboardLastFourEmployeeList(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
       
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:59815/api/Employee/GetLastFourEmployee/"); 
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync(); 
                var values = JsonConvert.DeserializeObject<List<ResultLastFourEmployeeDto>>(jsonData); 
                return View(values);

            }
            return View();

        }
    }
}

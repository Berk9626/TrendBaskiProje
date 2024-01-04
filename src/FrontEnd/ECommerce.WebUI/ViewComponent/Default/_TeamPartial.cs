using ECommerce.WebUI.Dtos.EmployeeDto;
using ECommerce.WebUI.Dtos.ReferanceDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ECommerce.WebUI.ViewComponent.Defult
{
    public class _TeamPartial : Microsoft.AspNetCore.Mvc.ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public _TeamPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
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
    }
}

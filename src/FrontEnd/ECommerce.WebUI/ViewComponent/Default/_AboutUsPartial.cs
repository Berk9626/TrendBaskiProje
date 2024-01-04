using ECommerce.WebUI.Dtos.AboutDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace ECommerce.WebUI.ViewComponent.Defult
{
    public class _AboutUsPartial : Microsoft.AspNetCore.Mvc.ViewComponent
    {

        private readonly IHttpClientFactory _httpClientFactory;
        public _AboutUsPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
           
                var client = _httpClientFactory.CreateClient();
                var responseMessage = await client.GetAsync("http://localhost:59815/api/About/GetActivesAbout/"); 
                if (responseMessage.IsSuccessStatusCode)
                {
                    var jsonData = await responseMessage.Content.ReadAsStringAsync(); 
                    var values = JsonConvert.DeserializeObject<List<ResultAboutDto>>(jsonData); 
                    return View(values);
                }
                return View();


             
        }


        





    }
}

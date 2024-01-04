using ECommerce.EntityLayer.Concrete;
using ECommerce.WebUI.Dtos.AppUserDto;
using ECommerce.WebUI.Dtos.ProductDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ECommerce.WebUI.Controllers.Others
{
    [Authorize(Roles = "Admin")]
    public class UserAdminController : Controller
    {

        private readonly IHttpClientFactory _httpClientFactory;
        public UserAdminController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        //------------------------------------------------------------------------------------------------------------------------------
        public async Task<IActionResult> UserList()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:59815/api/AppUser");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultAppUserListDto>>(jsonData);

                return View(values);
            }
            return View();
        }
    }
}

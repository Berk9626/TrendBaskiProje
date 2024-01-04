using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace ECommerce.WebUI.Controllers.Request
{
    [AllowAnonymous]
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

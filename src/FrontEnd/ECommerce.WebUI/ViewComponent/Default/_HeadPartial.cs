
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebUI.ViewComponent.Defult
{
    public class _HeadPartial : Microsoft.AspNetCore.Mvc.ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }

    }
}

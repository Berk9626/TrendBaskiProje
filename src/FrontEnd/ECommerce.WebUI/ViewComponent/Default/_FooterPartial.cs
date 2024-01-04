using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebUI.ViewComponent.Defult
{
    public class _FooterPartial : Microsoft.AspNetCore.Mvc.ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

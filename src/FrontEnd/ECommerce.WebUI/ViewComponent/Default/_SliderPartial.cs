using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebUI.ViewComponent.Defult
{
    public class _SliderPartial : Microsoft.AspNetCore.Mvc.ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

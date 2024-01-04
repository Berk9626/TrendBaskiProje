using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebUI.ViewComponent.Dashboard
{
    public class _DashboardHeadPartial : Microsoft.AspNetCore.Mvc.ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

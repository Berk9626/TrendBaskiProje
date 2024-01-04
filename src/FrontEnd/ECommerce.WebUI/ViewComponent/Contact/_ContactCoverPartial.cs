using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebUI.ViewComponent.Contact
{
    public class _ContactCoverPartial : Microsoft.AspNetCore.Mvc.ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

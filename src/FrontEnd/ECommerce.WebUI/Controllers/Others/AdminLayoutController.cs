using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebUI.Controllers.Others
{
    [Authorize(Roles ="Admin")]
    public class AdminLayoutController : Controller
    {
        public IActionResult _AdminLayout()
        {
            return View();
        }
        public PartialViewResult HeadPartial()
        {
            return PartialView();
        }
        public PartialViewResult PreLoaderPartial()
        {
            return PartialView();
        }
        public PartialViewResult NavHeaderPartial()
        {
            return PartialView();
        }
        public PartialViewResult HeaderPartial()
        {
            return PartialView();
        }
        public PartialViewResult SideBarPartial()
        {
            return PartialView();
        }
        public PartialViewResult ContentBodyPartial()
        {
            return PartialView();
        }
        public PartialViewResult FooterPartial()
        {
            return PartialView();
        }

        public PartialViewResult ScriptPartial()
        {
            return PartialView();
        }

    }
}

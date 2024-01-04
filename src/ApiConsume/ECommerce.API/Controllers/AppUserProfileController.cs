using ECommerce.BusinessLayer.Abstract;
using ECommerce.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUserProfileController : ControllerBase
    {
        private readonly IAppUserProfileService _appUserProfileService;
        public AppUserProfileController(IAppUserProfileService appUserProfileService)
        {
            _appUserProfileService = appUserProfileService;
        }
       
    }
}

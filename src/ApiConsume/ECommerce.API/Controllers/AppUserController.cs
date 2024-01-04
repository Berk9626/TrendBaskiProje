using ECommerce.BusinessLayer.Abstract;
using ECommerce.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUserController : ControllerBase
    {
        private readonly IAppUserService _appUserService;
        public AppUserController(IAppUserService appUserService)
        {
            _appUserService = appUserService;
        }
        //---------------------------------------------------------
        [HttpGet]
        public IActionResult AppUserList()
        {
            try
            {
                var values = _appUserService.GetAll();
                return Ok(values);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        //---------------------------------------------------------
        [HttpPost]
        public IActionResult AddAppUser(AppUser appUser)
        {
            try
            {
                _appUserService.Add(appUser);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        //---------------------------------------------------------
        [HttpPut]
        public IActionResult UpdateAppUser(AppUser appUser)
        {
            try
            {
                _appUserService.Update(appUser);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        //---------------------------------------------------------
        [HttpDelete("DeleteAppUser/{id}")]
        public IActionResult DeleteAppUser(int id)
        {
            try
            {
                var values = _appUserService.GetById(id);
                _appUserService.Destroy(values);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        //---------------------------------------------------------
        [HttpDelete("DeletedStatusAppUser/{id}")]
        public IActionResult DeletedStatusAppUser(int id)
        {
            try
            {
                var values = _appUserService.GetById(id);
                _appUserService.Delete(values);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        //---------------------------------------------------------
        [HttpGet("GetActivesAppUser")]
        public IActionResult GetActivesAppUser()
        {
            try
            {
                var values = _appUserService.GetActives();
                return Ok(values);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        //---------------------------------------------------------
        [HttpGet("GetActiveAppUser/{id}")]
        public IActionResult GetActiveAppUser(int id)
        {
            try
            {
                var values = _appUserService.GetById(id);
                _appUserService.GetActive(values);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        //---------------------------------------------------------
        [HttpGet("{id}")]
        public IActionResult GetAppUser(int id)
        {
            try
            {
                var model = _appUserService.GetById(id);
                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        //---------------------------------------------------------

    }
}

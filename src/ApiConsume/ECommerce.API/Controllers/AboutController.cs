using ECommerce.BusinessLayer.Abstract;
using ECommerce.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly IAboutService _aboutService;        
        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }
        //---------------------------------------------------------
        [HttpGet]
        public IActionResult AboutList()
        {
            try
            {
                var values = _aboutService.GetAll();
                return Ok(values);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }                   
        //---------------------------------------------------------
        [HttpGet("{id}")]
        public IActionResult GetAbout(int id)
        {
            try
            {
                var model = _aboutService.GetById(id);
                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        //---------------------------------------------------------
        [HttpPost]
        public IActionResult AddAbout(About about)
        {
            try
            {
                _aboutService.Add(about);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        //---------------------------------------------------------
        [HttpPut]
        public IActionResult UpdateAbout(About about)
        {
            try
            {
                _aboutService.Update(about);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        //---------------------------------------------------------
        [HttpDelete("DeleteAbout/{id}")]
        public IActionResult DeleteAbout(int id)
        {
            try
            {
                var values = _aboutService.GetById(id);
                _aboutService.Destroy(values);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        //---------------------------------------------------------
        [HttpDelete("DeletedStatusAbout/{id}")]
        public IActionResult DeletedStatusAbout(int id)
        {
            try
            {
                var values = _aboutService.GetById(id);
                _aboutService.Delete(values);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        //---------------------------------------------------------
        [HttpGet("GetActivesAbout")]
        public IActionResult GetActivesAbout()
        {
            try
            {
                var values = _aboutService.GetActives();
                return Ok(values);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        //---------------------------------------------------------
        [HttpGet("GetActiveAbout/{id}")]
        public IActionResult GetActiveAbout(int id)
        {
            try
            {
                var values = _aboutService.GetById(id);
                _aboutService.GetActive(values);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        //---------------------------------------------------------
    }
}

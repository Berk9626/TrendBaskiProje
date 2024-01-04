using ECommerce.BusinessLayer.Abstract;
using ECommerce.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuestController : ControllerBase
    {
        private readonly IGuestService _guestService;
        public GuestController(IGuestService guestService)
        {
            _guestService = guestService;
        }
        //---------------------------------------------------------
        [HttpGet]
        public IActionResult GuestList()
        {
            try
            {
                var values = _guestService.GetAll();
                return Ok(values);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        //---------------------------------------------------------
        [HttpGet("{id}")]
        public IActionResult GetGuest(int id)
        {
            try
            {
                var model = _guestService.GetById(id);
                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        //---------------------------------------------------------
        [HttpPost]
        public IActionResult AddGuest(Guest guest)
        {
            try
            {
                _guestService.Add(guest);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        //---------------------------------------------------------
        [HttpPut]
        public IActionResult UpdateGuest(Guest guest)
        {
            try
            {
                _guestService.Update(guest);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        //---------------------------------------------------------
        [HttpDelete("DeleteGuest/{id}")]
        public IActionResult DeleteGuest(int id)
        {
            try
            {
                var values = _guestService.GetById(id);
                _guestService.Destroy(values);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        //---------------------------------------------------------
        [HttpDelete("DeletedStatusGuest/{id}")]
        public IActionResult DeletedStatusGuest(int id)
        {
            try
            {
                var values = _guestService.GetById(id);
                _guestService.Delete(values);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        //---------------------------------------------------------
        [HttpGet("GetActivesGuest")]
        public IActionResult GetActivesGuest()
        {
            try
            {
                var values = _guestService.GetActives();
                return Ok(values);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        //---------------------------------------------------------
        [HttpGet("GetActiveGuest/{id}")]
        public IActionResult GetActiveGuest(int id)
        {
            try
            {
                var values = _guestService.GetById(id);
                _guestService.GetActive(values);
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

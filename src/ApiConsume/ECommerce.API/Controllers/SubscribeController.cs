using ECommerce.BusinessLayer.Abstract;
using ECommerce.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscribeController : ControllerBase
    {
        private readonly ISubscribeService _subscribeService;
        public SubscribeController(ISubscribeService SubscribeService)
        {
            _subscribeService = SubscribeService;
        }
        //---------------------------------------------------------
        [HttpGet]
        public IActionResult SubscribeList()
        {
            try
            {
                var values = _subscribeService.GetAll();
                return Ok(values);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        //---------------------------------------------------------
        [HttpGet("{id}")]
        public IActionResult GetSubscribe(int id)
        {
            try
            {
                var model = _subscribeService.GetById(id);
                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        //---------------------------------------------------------
        [HttpPost]
        public IActionResult AddSubscribe(Subscribe subscribe)
        {
            try
            {
                _subscribeService.Add(subscribe);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        //---------------------------------------------------------
        [HttpPut]
        public IActionResult UpdateSubscribe (Subscribe subscribe)
        {
            try
            {
                _subscribeService.Update(subscribe);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        //---------------------------------------------------------
        [HttpDelete("DeleteSubscribe/{id}")]
        public IActionResult DeleteSubscribe(int id)
        {
            try
            {
                var values = _subscribeService.GetById(id);
                _subscribeService.Destroy(values);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        //---------------------------------------------------------
        [HttpDelete("DeletedStatusSubscribe/{id}")]
        public IActionResult DeletedStatusSubscribe(int id)
        {
            try
            {
                var values = _subscribeService.GetById(id);
                _subscribeService.Delete(values);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        //---------------------------------------------------------
        [HttpGet("GetActivesSubscribe")]
        public IActionResult GetActivesSubscribe()
        {
            try
            {
                var values = _subscribeService.GetActives();
                return Ok(values);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        //---------------------------------------------------------
        [HttpGet("GetActiveSubscribe/{id}")]
        public IActionResult GetActiveSubscribe(int id)
        {
            try
            {
                var values = _subscribeService.GetById(id);
                _subscribeService.GetActive(values);
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

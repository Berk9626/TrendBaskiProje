using ECommerce.BusinessLayer.Abstract;
using ECommerce.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShipperController : ControllerBase
    {
        private readonly IShipperService _shipperService;
        public ShipperController(IShipperService shipperService)
        {
            _shipperService = shipperService;
        }
        //---------------------------------------------------------
        [HttpGet]
        public IActionResult ShipperList()
        {
            try
            {
                var values = _shipperService.GetAll();
                return Ok(values);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        //---------------------------------------------------------
        [HttpGet("{id}")]
        public IActionResult GetShipper(int id)
        {
            try
            {
                var model = _shipperService.GetById(id);
                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        //---------------------------------------------------------
        [HttpPost]
        public IActionResult AddShipper(Shipper shipper)
        {
            try
            {
                _shipperService.Add(shipper);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        //---------------------------------------------------------
        [HttpPut]
        public IActionResult UpdateShipper(Shipper shipper)
        {
            try
            {
                _shipperService.Update(shipper);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        //---------------------------------------------------------
        [HttpDelete("DeleteShipper/{id}")]
        public IActionResult DeleteShipper(int id)
        {
            try
            {
                var values = _shipperService.GetById(id);
                _shipperService.Destroy(values);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        //---------------------------------------------------------
        [HttpDelete("DeletedStatusShipper/{id}")]
        public IActionResult DeletedStatusShipper(int id)
        {
            try
            {
                var values = _shipperService.GetById(id);
                _shipperService.Delete(values);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        //---------------------------------------------------------
        [HttpGet("GetActivesShipper")]
        public IActionResult GetActivesShipper()
        {
            try
            {
                var values = _shipperService.GetActives();
                return Ok(values);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        //---------------------------------------------------------
        [HttpGet("GetActiveShipper/{id}")]
        public IActionResult GetActiveShipper(int id)
        {
            try
            {
                var values = _shipperService.GetById(id);
                _shipperService.GetActive(values);
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

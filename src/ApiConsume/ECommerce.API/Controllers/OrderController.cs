using ECommerce.BusinessLayer.Abstract;
using ECommerce.EntityLayer.Concrete;
using ECommerce.WebUI.Dtos.ProductDto;
using ECommerce.WebUI.Models.EmployeWithImage;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        //---------------------------------------------------------
        [HttpGet]
        public IActionResult OrderList()
        {
            try
            {
                var values = _orderService.GetAll();
                return Ok(values);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        //---------------------------------------------------------
        [HttpGet("{id}")]
        public IActionResult GetOrder(int id)
        {
            try
            {
                var model = _orderService.GetById(id);
                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        //---------------------------------------------------------
        [HttpPost]
        public IActionResult AddOrder(Order order)
        {
            try
            {
                _orderService.Add(order);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        //---------------------------------------------------------
        [HttpPut]
        public IActionResult UpdateOrder(Order order)
        {
            try
            {
                _orderService.Update(order);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        //---------------------------------------------------------
        [HttpDelete("DeleteOrder/{id}")]
        public IActionResult DeleteOrder(int id)
        {
            try
            {
                var values = _orderService.GetById(id);
                _orderService.Destroy(values);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }
        //---------------------------------------------------------
        [HttpDelete("DeletedStatusOrder/{id}")]
        public IActionResult DeletedStatusOrder(int id)
        {
            try
            {
                var values = _orderService.GetById(id);
                _orderService.Delete(values);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }
        //---------------------------------------------------------
        [HttpGet("GetActivesOrder")]
        public IActionResult GetActivesOrder()
        {
            try
            {
                var values = _orderService.GetActives();
                return Ok(values);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        //---------------------------------------------------------
        [HttpGet("GetActiveOrder/{id}")]
        public IActionResult GetActiveOrder(int id)
        {
            try
            {
                var values = _orderService.GetById(id);
                _orderService.GetActive(values);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        //---------------------------------------------------------
        [HttpGet("GetChangeOrderStatusAsOnTheWay/{id}")]
        public IActionResult GetChangeOrderStatusAsOnTheWay(int id)
        {
            try
            {
                _orderService.GetChangeOrderStatusAsOnTheWay(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        //---------------------------------------------------------
        [HttpGet("GetChangeOrderStatusAsStillWaiting/{id}")]
        public IActionResult GetChangeOrderStatusAsStillWaiting(int id)
        {
            try
            {
                _orderService.GetChangeOrderStatusAsStillWaiting(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        //---------------------------------------------------------
        [HttpGet("GetChangeOrderStatusAsCanceled/{id}")]
        public IActionResult GetChangeOrderStatusAsCanceled(int id)
        {
            try
            {
                _orderService.GetChangeOrderStatusAsCanceled(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        //---------------------------------------------------------
        [HttpGet("GetLastFourOrder")]
        public IActionResult GetLastFourOrder()
        {
            try
            {
                _orderService.LastFourOrder();
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

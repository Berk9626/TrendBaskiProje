using ECommerce.BusinessLayer.Abstract;
using ECommerce.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailController : ControllerBase
    {
        private readonly IOrderDetailService _orderDetailService;
        public OrderDetailController(IOrderDetailService orderDetailService)
        {
            _orderDetailService = orderDetailService;
        }
        //---------------------------------------------------------
        [HttpGet]
        public IActionResult OrderDetailList()
        {
            try
            {
                var values = _orderDetailService.GetAll();
                return Ok(values);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        //---------------------------------------------------------
        [HttpGet("{id}")]
        public IActionResult GetOrderDetail(int id)
        {
            try
            {
                var model = _orderDetailService.GetById(id);
                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }
        //---------------------------------------------------------
        [HttpPost]
        public IActionResult AddOrderDetail(OrderDetail orderDetail)
        {
            try
            {
                _orderDetailService.Add(orderDetail);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }
        //---------------------------------------------------------
        [HttpPut]
        public IActionResult UpdateOrderDetail(OrderDetail orderDetail)
        {
            try
            {
                _orderDetailService.Update(orderDetail);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }
        //---------------------------------------------------------
        [HttpDelete("DeleteOrderDetail/{id}")]
        public IActionResult DeleteOrderDetail(int id)
        {
            try
            {
                var values = _orderDetailService.GetById(id);
                _orderDetailService.Destroy(values);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }
        //---------------------------------------------------------
        [HttpDelete("DeletedStatusOrderDetail/{id}")]
        public IActionResult DeletedStatusOrderDetail(int id)
        {
            try
            {
                var values = _orderDetailService.GetById(id);
                _orderDetailService.Delete(values);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }
        //---------------------------------------------------------
        [HttpGet("GetActivesOrderDetail")]
        public IActionResult GetActivesOrderDetail()
        {
            try
            {
                var values = _orderDetailService.GetActives();
                return Ok(values);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }
        //---------------------------------------------------------
        [HttpGet("GetActiveOrderDetail/{id}")]
        public IActionResult GetActiveOrderDetail(int id)
        {
            try
            {
                var values = _orderDetailService.GetById(id);
                _orderDetailService.GetActive(values);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        //---------------------------------------------------------
        [HttpGet("GetTotalRevenueCount")]
        public IActionResult GetTotalRevenueCount()
        {
            try
            {
                return Ok(_orderDetailService.GetTotalRevenueUntilToday());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        //---------------------------------------------------------
        [HttpGet("GetMonthlyRevenue")]
        public IActionResult GetMonthlyRevenue()
        {
            try
            {
                return Ok(_orderDetailService.GetMonthlyRevenue());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        //---------------------------------------------------------
        [HttpGet("GetWeeklyRevenue")]
        public IActionResult GetWeeklyRevenue()
        {
            try
            {
                return Ok(_orderDetailService.GetWeeklyRevenue());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        //---------------------------------------------------------
        [HttpGet("GetDailyRevenue")]
        public IActionResult GetDailyRevenue()
        {
            try
            {
                return Ok(_orderDetailService.GetDailyRevenue());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        //---------------------------------------------------------
    }
}

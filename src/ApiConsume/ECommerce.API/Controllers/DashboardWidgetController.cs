using ECommerce.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardWidgetController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly IBookingService _bookingService;
        private readonly IProductService _productService;
        private readonly IOrderService _orderService;
        private readonly IOrderDetailService _orderDetailService;
        public DashboardWidgetController(IEmployeeService employeeService, IBookingService bookingService, IProductService productService, IOrderService orderService, IOrderDetailService orderDetailService)
        {
            _employeeService = employeeService;
            _bookingService = bookingService;
            _productService = productService;
            _orderService = orderService;
            _orderDetailService = orderDetailService;
        }
        //---------------------------------------------------------
        [HttpGet("EmployeeCount")]
        public IActionResult EmployeeCount()
        {
            try
            {
                return Ok(_employeeService.GetEmploeeCount());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        //---------------------------------------------------------
        [HttpGet("BookingCount")]
        public IActionResult BookingCount() 
        {
            try
            {
                return Ok(_bookingService.GetBookingCount());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        //---------------------------------------------------------
        [HttpGet("ProductCount")]
        public IActionResult ProductCount()
        {
            try
            {
                return Ok(_productService.GetProductCount());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        //---------------------------------------------------------
        [HttpGet("OrderCount")]
        public IActionResult OrderCount()
        {
            try
            {
                return Ok(_orderService.GetOrderCount());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        //---------------------------------------------------------
        [HttpGet("OrderDetailCount")]
        public IActionResult GetTotalSalesCount()
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
    }
}

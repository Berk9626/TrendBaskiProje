using ECommerce.BusinessLayer.Abstract;
using ECommerce.EntityLayer.Concrete;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using ECommerce.WebUI.Dtos.BookingDto;
using Azure.Core;
using ECommerce.WebUI.Dtos.CategoryDto;
using ECommerce.WebUI.Models.CategoryWithFile;
using ECommerce.WebUI.Models.BookingWithImage;

namespace ECommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;  
        private readonly IWebHostEnvironment _webHostEnvironment;
        public BookingController(IBookingService BookingService, IWebHostEnvironment webHostEnvironment)
        {
            _bookingService = BookingService;
            _webHostEnvironment = webHostEnvironment;
        }
        //---------------------------------------------------------
        [HttpGet]
        public IActionResult BookingList()
        {
            try
            {
                var values = _bookingService.GetAll();
                return Ok(values);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        //---------------------------------------------------------
        [HttpGet("GetAllWithImages")]
        public async Task<IActionResult> GetAllWithImages()
        {
            try
            {
                BkWithFile bkWithFile = new BkWithFile(_webHostEnvironment);
                var bookinglist = _bookingService.GetAll();

                if (bookinglist != null && bookinglist.Count > 0)
                {
                    bookinglist.ForEach(item =>
                    {
                        item.ImageFile = bkWithFile.GetImagebyBooking(item.ImageFile);
                    });
                    return Ok(bookinglist);
                }
                else
                {
                    return Ok(new List<ResultBookingDto>());
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }
        //---------------------------------------------------------
        [HttpGet("{id}")]
        public IActionResult GetBooking(int id)
        {
            try
            {
                var model = _bookingService.GetById(id);
                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        //---------------------------------------------------------
        [HttpPost]
        public IActionResult AddBooking(Booking booking)
        {
            try
            {
                _bookingService.Add(booking);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        //---------------------------------------------------------
        [HttpPut]
        public IActionResult UpdateBooking(Booking booking)
        {
            try
            {
                _bookingService.Update(booking);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        //---------------------------------------------------------
        [HttpDelete("DeleteBooking/{id}")]
        public IActionResult DeleteBooking(int id)
        {
            try
            {
                var values = _bookingService.GetById(id);
                _bookingService.Destroy(values);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        //---------------------------------------------------------
        [HttpDelete("DeletedStatusBooking/{id}")]
        public IActionResult DeletedStatusBooking(int id)
        {
            try
            {
                var values = _bookingService.GetById(id);
                _bookingService.Delete(values);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        //---------------------------------------------------------
        [HttpGet("GetActivesBooking")]
        public IActionResult GetActivesBooking()
        {
            try
            {
                var values = _bookingService.GetActives();
                return Ok(values);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        //---------------------------------------------------------
        [HttpGet("GetActiveBooking/{id}")]
        public IActionResult GetActiveBooking(int id)
        {
            try
            {
                var values = _bookingService.GetById(id);
                _bookingService.GetActive(values);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        //---------------------------------------------------------
        [HttpGet("GetChangeBookingStatusAsApproved/{id}")]
        public IActionResult GetChangeBookingStatusAsApproved(int id)
        {
            try
            {            
                _bookingService.GetChangeBookingStatusAsApproved(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        //---------------------------------------------------------
        [HttpGet("GetChangeBookingStatusAsKeepWaiting/{id}")]
        public IActionResult GetChangeBookingStatusAsKeepWaiting(int id)
        {
            try
            {
                _bookingService.GetChangeBookingStatusAsKeepWaiting(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        //---------------------------------------------------------
        [HttpGet("GetChangeBookingStatusAsCanceled/{id}")]
        public IActionResult GetChangeBookingStatusAsCanceled(int id)
        {
            try
            {
                _bookingService.GetChangeOrderStatusAsCanceled(id);
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

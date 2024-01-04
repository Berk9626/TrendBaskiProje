using ECommerce.DataAccessLayer.Concrete;
using ECommerce.EntityLayer.Concrete;
using ECommerce.WebUI.Dtos.BookingDto;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using System.IO;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc.Rendering;
using ECommerce.WebUI.Dtos.ProductDto;
using ECommerce.WebUI.ValidationRules.ProductValidationRules;
using ECommerce.WebUI.ValidationRules.BookingValidationRules;
using ECommerce.WebUI.Models.MailViewModel;
using Microsoft.AspNetCore.Authorization;

namespace ECommerce.WebUI.Controllers.Request
{
    [AllowAnonymous]
    public class BookingController : Controller
    {

        private readonly IHttpClientFactory _httpClientFactory;
        public BookingController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        //------------------------------------------------------------------------------------------------------------------------------
        public IActionResult Index()
        {
            Context context = new Context();
            List<SelectListItem> selectedListItems = (from c in context.Categories.ToList()
                                                      select new SelectListItem
                                                      {
                                                          Text = c.CategoryName,
                                                          Value = c.CategoryId.ToString(),

                                                      }).ToList();

            ViewBag.dgr1 = selectedListItems;
            return View();
        }
        //------------------------------------------------------------------------------------------------------------------------------
        [HttpGet]
        public PartialViewResult AddBooking()
        {
           
            return PartialView();
        }
        //------------------------------------------------------------------------------------------------------------------------------
        [HttpPost]
        public async Task<IActionResult> AddBooking(CreateBookingDto createBookingDto)
        {
            Context context = new Context();
            CreateBookingValidator validationRules = new CreateBookingValidator();
            Booking booking = new Booking();            
            ValidationResult result = validationRules.Validate(createBookingDto);
            List<SelectListItem> selectedListItems = (from c in context.Categories.ToList()
                                                      select new SelectListItem
                                                      {
                                                          Text = c.CategoryName,
                                                          Value = c.CategoryId.ToString(),

                                                      }).ToList();

            ViewBag.dgr1 = selectedListItems;
            if (result.IsValid)
            {
                if (createBookingDto.ImageFile != null)
                {
                    var extension = Path.GetExtension(createBookingDto.ImageFile.FileName);
                    string newImageName = Guid.NewGuid() + extension;
                    var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/bookingImages/", newImageName);
                    var stream = new FileStream(location, FileMode.Create);
                    createBookingDto.ImageFile.CopyTo(stream);                   
                    booking.ImageFile = newImageName;
                    booking.FirstName = createBookingDto.FirstName;
                    booking.LastName = createBookingDto.LastName;
                    booking.Email = createBookingDto.Email;
                    booking.Phone = createBookingDto.Phone;
                    booking.CheckIn = createBookingDto.CheckIn;
                    booking.CheckOut = createBookingDto.CheckOut;
                    booking.SpecialRequest = createBookingDto.SpecialRequest;
                    booking.CategoryId = createBookingDto.CategoryId;
                }
                
                var client = _httpClientFactory.CreateClient();
                var jsonData = JsonConvert.SerializeObject(booking);
                StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var responseMessage = await client.PostAsync("http://localhost:59815/api/Booking/", content);
                if (responseMessage.IsSuccessStatusCode)
                {
                    //MailSender.SendEmail(booking.Email, "Rezervasyon İşleminiz Gerçekleştirildi", $"{booking.BookingId} numaralı rezervasyonunuz oluşturuldu. Hazırlanma veya iptal işlemleri olduğu takdirde bilgilendirme maili iletilecektir.");
                    return RedirectToAction("Index", "Default");
                }
                return View("Index", "Booking");

            }
            else
            {
                foreach (var errors in result.Errors)
                {
                    ModelState.AddModelError(errors.PropertyName, errors.ErrorMessage);
                }
                return View(createBookingDto);
            }

        }
        //------------------------------------------------------------------------------------------------------------------------------

    }
}

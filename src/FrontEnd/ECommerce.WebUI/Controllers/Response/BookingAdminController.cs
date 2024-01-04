using AutoMapper.Configuration.Conventions;
using ECommerce.BusinessLayer.Abstract;
using ECommerce.DataAccessLayer.Concrete;
using ECommerce.EntityLayer.Concrete;
using ECommerce.WebUI.Dtos.BookingDto;

using ECommerce.WebUI.Models;
using ECommerce.WebUI.Models.MailViewModel;
using Humanizer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using NuGet.Protocol.Plugins;
using System.Text;

namespace ECommerce.WebUI.Controllers.Response
{
    [Authorize(Roles = "Admin")]
    public class BookingAdminController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IBookingService _bookingService;
        public BookingAdminController(IHttpClientFactory httpClientFactory, IBookingService bookingService)
        {
            _httpClientFactory = httpClientFactory;
            _bookingService = bookingService;
        }
        //------------------------------------------------------------------------------------------------------------------------------
        public async Task<IActionResult> Index()
        {
            Context context = new Context();
            List<SelectListItem> selectedListItems = (from c in context.Categories.ToList()
                                                      select new SelectListItem
                                                      {
                                                          Text = c.CategoryName,
                                                          Value = c.CategoryId.ToString(),

                                                      }).ToList();

            ViewBag.dgr1 = selectedListItems;
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:59815/api/Booking/GetAllWithImages");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBookingDto>>(jsonData);
                return View(values);
            }
            return View();
        }
        //------------------------------------------------------------------------------------------------------------------------------
        public async Task<IActionResult> ApprovedReservation(int id) 
        {            
            var model = _bookingService.GetBookingForOnlyEmail(id);
          
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:59815/api/Booking/GetChangeBookingStatusAsApproved/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {            
                MailSender.SendEmail(model.Email, "Siparişiniz onaylandı", $"{model.BookingId} numaralı rezervasyonunuz hazırlanıyor. Kargo işlemleri halledildikten sonra kargo bilgileri e-mail yolu ile size bildirilecektir");

                return RedirectToAction("Index");
            }
            return View();

        }
        //------------------------------------------------------------------------------------------------------------------------------
        public async Task<IActionResult> KeepWaitingReservation(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:59815/api/Booking/GetChangeBookingStatusAsKeepWaiting/{id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        //------------------------------------------------------------------------------------------------------------------------------
        public async Task<IActionResult> CanceledStatusBooking(int id)
        {
            var model = _bookingService.GetBookingForOnlyEmail(id);
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:59815/api/Booking/GetChangeBookingStatusAsCanceled/{id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                //booking.BookingId = id;
                MailSender.SendEmail(model.Email, "Siparişiniz iptal edildi", $"{model.BookingId} numaralı rezervasyonunuz iptal edildi. Yeterli bilgi içeriği vb. nedenler ile iptal işlemi gerçekleşmiş olabilir, lütfen tekrardan rezervasyon oluşturunuz.");
                return RedirectToAction("Index");
            }
            return View();
        }
        //------------------------------------------------------------------------------------------------------------------------------
        public async Task<IActionResult> DeleteBooking(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"http://localhost:59815/api/Booking/DeleteBooking/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        //------------------------------------------------------------------------------------------------------------------------------
    }
}

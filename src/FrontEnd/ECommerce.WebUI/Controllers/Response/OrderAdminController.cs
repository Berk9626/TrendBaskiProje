using ECommerce.BusinessLayer.Abstract;
using ECommerce.DataAccessLayer.Concrete;
using ECommerce.EntityLayer.Concrete;
using ECommerce.WebUI.Dtos.OrderDto;
using ECommerce.WebUI.Dtos.SupplierDto;
using ECommerce.WebUI.Models.MailViewModel;
using ECommerce.WebUI.ValidationRules.OrderValidationRules;
using ECommerce.WebUI.ValidationRules.SupplierValidationRules;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;

namespace ECommerce.WebUI.Controllers.Response
{
    [Authorize(Roles = "Admin")]
    public class OrderAdminController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IOrderService _orderService;
        public OrderAdminController(IHttpClientFactory httpClientFactory, IOrderService orderService)
        {
            _httpClientFactory = httpClientFactory;
            _orderService = orderService;
        }
        //------------------------------------------------------------------------------------------------------------------------------
        public async Task<IActionResult> Index()
        {
            Context context = new Context();
            List<SelectListItem> selectedListItems = (from c in context.AppUsers.ToList()
                                                      where c.FirstName != null && c.LastName != null && c.AppUserId != null
                                                      select new SelectListItem
                                                      {
                                                          Text = c.FirstName + " " + c.LastName,
                                                          Value = c.AppUserId.ToString(),
                                                      }).ToList();
            //List<SelectListItem> selectedListItems = (from c in context.AppUsers.ToList()
            //                                          select new SelectListItem
            //                                          {
            //                                              Text = c.FirstName +" "+ c.LastName,
            //                                              Value = c.AppUserId.ToString(),

            //                                          }).ToList();

            ViewBag.dgr1 = selectedListItems;
            List<SelectListItem> selectedListItems2 = (from a in context.Shippers.ToList()
                                                      select new SelectListItem
                                                      {
                                                          Text = a.ShipperName,
                                                          Value = a.ShipperId.ToString(),

                                                      }).ToList();

            ViewBag.dgr2 = selectedListItems2;
            List<SelectListItem> selectedListItems3 = (from b in context.Employees.ToList()
                                                      select new SelectListItem
                                                      {
                                                          Text = b.FirstName + " " + b.LastName,
                                                          Value = b.EmployeeId.ToString(),

                                                      }).ToList();

            ViewBag.dgr3 = selectedListItems3;
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:59815/api/Order");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultOrderDto>>(jsonData);
                return View(values);
            }
            return View();
        }
        //------------------------------------------------------------------------------------
        [HttpGet]
        public async Task<IActionResult> UpdateOrder(int id)
        {
            Context context = new Context();
            List<SelectListItem> selectedListItems5 = (from a in context.Shippers.ToList()
                                                       select new SelectListItem
                                                       {
                                                           Text = a.ShipperName,
                                                           Value = a.ShipperId.ToString(),

                                                       }).ToList();

            ViewBag.dgr5 = selectedListItems5;
            List<SelectListItem> selectedListItems6 = (from b in context.Employees.ToList()
                                                       select new SelectListItem
                                                       {
                                                           Text = b.FirstName + " " + b.LastName,
                                                           Value = b.EmployeeId.ToString(),

                                                       }).ToList();

            ViewBag.dgr6 = selectedListItems6;
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:59815/api/Order/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateOrderDto>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateOrder(UpdateOrderDto model)
        {
            Order order = new Order();
            UpdateOrderValidator validationRules = new UpdateOrderValidator();
            FluentValidation.Results.ValidationResult result = validationRules.Validate(model);
            if (result.IsValid)
            {
                order.OrderId = model.OrderId;               
                order.ShipAddress = model.ShipAddress;
                order.ShipCity = model.ShipCity;
                order.ShipRegion = model.ShipRegion;
                order.ShipCountry = model.ShipCountry;
                order.ShipPostalCode = model.ShipPostalCode;
                order.ShipperId = model.ShipperId;
                order.EmployeeId = model.EmployeeId;
                order.AppUserId = model.AppUserId;
                order.OrderDate = model.OrderDate;
                order.ShippedDate = model.ShippedDate;
                order.CreatedDate = model.CreatedDate;

                var client = _httpClientFactory.CreateClient();
                var jsonData = JsonConvert.SerializeObject(order);
                StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var responseMessage = await client.PutAsync("http://localhost:59815/api/Order", content);

                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                return View();
            }
            else
            {
                foreach (var errors in result.Errors)
                {
                    ModelState.AddModelError(errors.PropertyName, errors.ErrorMessage);
                }
                return View(model);
            }
        }
        //------------------------------------------------------------------------------------------------------------------------------
        public async Task<IActionResult> OrderStatusAsOnTheWay(int id)
        {
            var model = _orderService.GetOrderForOnlyEmail(id);          
            if (model != null)
            {              
                var client = _httpClientFactory.CreateClient();
                var responseMessage = await client.GetAsync($"http://localhost:59815/api/Order/GetChangeOrderStatusAsOnTheWay/{id}");

                if (responseMessage.IsSuccessStatusCode)
                {
                    MailSender.SendEmail(model.AppUser.Email, "Siparişiniz kargoya verildi", $"{model.OrderId} numaralı rezervasyonunuz kargoda, yola çıktı! Kargo bilgileri e-mail yolu ile size bildirilecektir");

                    return RedirectToAction("Index");
                }
            }
            return View();
        }
        //------------------------------------------------------------------------------------------------------------------------------
        public async Task<IActionResult> OrderStatusAsStillWaiting(int id)
        {          
            var model = _orderService.GetOrderForOnlyEmail(id);

            if (model != null)
            {
                var client = _httpClientFactory.CreateClient();
                var responseMessage = await client.GetAsync($"http://localhost:59815/api/Order/GetChangeOrderStatusAsStillWaiting/{id}");

                if (responseMessage.IsSuccessStatusCode)
                {
                    MailSender.SendEmail(model.AppUser.Email, "Siparişiniz onaylandı ve beklemede", $"{model.OrderId} numaralı rezervasyonunuz hazırlanıyor. Kargo işlemleri halledildikten sonra kargo bilgileri e-mail yolu ile size bildirilecektir");
                    return RedirectToAction("Index");
                }
            }

            return View();
        }
        //------------------------------------------------------------------------------------------------------------------------------
        public async Task<IActionResult> OrderStatusAsCanceled(int id)
        {
            var model = _orderService.GetOrderForOnlyEmail(id);

            if (model != null)
            {
                var client = _httpClientFactory.CreateClient();
                var responseMessage = await client.GetAsync($"http://localhost:59815/api/Order/GetChangeOrderStatusAsCanceled/{id}");

                if (responseMessage.IsSuccessStatusCode)
                {
                    MailSender.SendEmail(model.AppUser.Email, "Siparişiniz iptal edildi", $"{model.OrderId} numaralı rezervasyonunuz iptal edildi, lütfen tekrardan satın alma işlemi oluşturunuz.");
                    return RedirectToAction("Index");
                }
            }
            return View();
        }
        //------------------------------------------------------------------------------------------------------------------------------
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"http://localhost:59815/api/Order/DeleteOrder/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        //------------------------------------------------------------------------------------------------------------------------------
    }
}


using ECommerce.EntityLayer.Concrete;
using ECommerce.WebUI.Dtos.AboutDto;
using ECommerce.WebUI.Dtos.ReferanceDto;
using ECommerce.WebUI.Dtos.ShipperDto;
using ECommerce.WebUI.ValidationRules.AboutValidationRules;
using ECommerce.WebUI.ValidationRules.ReferanceValidationRules;
using ECommerce.WebUI.ValidationRules.ShipperValidationRules;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace ECommerce.WebUI.Controllers.Response
{
    [Authorize(Roles = "Admin")]
    public class ShipperAdminController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public ShipperAdminController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        //------------------------------------------------------------------------------------------------------------------------------
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:59815/api/Shipper");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultShipperDto>>(jsonData);
                return View(values);
            }
            return View();
        }
        //------------------------------------------------------------------------------------------------------------------------------
        [HttpGet]
        public IActionResult AddShipper()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddShipper(CreateShipperDto model)
        {
            Shipper shipper = new Shipper();
            CreateShipperValidator validationRules = new CreateShipperValidator();
            FluentValidation.Results.ValidationResult result = validationRules.Validate(model);
            if (result.IsValid)
            {
                shipper.ShipperName = model.ShipperName;
                shipper.ShipperEmail = model.ShipperEmail;
                shipper.ShipperPhone = model.ShipperPhone;
                
                var client = _httpClientFactory.CreateClient();
                var jsonData = JsonConvert.SerializeObject(shipper);
                StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var responseMessage = await client.PostAsync("http://localhost:59815/api/Shipper", content);

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
        [HttpGet]
        public async Task<IActionResult> UpdateShipper(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:59815/api/Shipper/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateShipperDto>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateShipper(UpdateShipperDto model)
        {
            Shipper shipper = new Shipper();
            UpdateShipperValidator validationRules = new UpdateShipperValidator();
            FluentValidation.Results.ValidationResult result = validationRules.Validate(model);
            if (result.IsValid)
            {
                shipper.ShipperId = shipper.ShipperId;
                shipper.ShipperName = model.ShipperName;
                shipper.ShipperEmail = model.ShipperEmail;
                shipper.ShipperPhone = model.ShipperPhone;
                shipper.CreatedDate = model.CreatedDate;

                var client = _httpClientFactory.CreateClient();
                var jsonData = JsonConvert.SerializeObject(shipper);
                StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var responseMessage = await client.PutAsync("http://localhost:59815/api/Shipper", content);

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
        public async Task<IActionResult> DeleteShipper(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"http://localhost:59815/api/Shipper/DeleteShipper/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        //------------------------------------------------------------------------------------------------------------------------------
        public async Task<IActionResult> DeletedStatusShipper(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"http://localhost:59815/api/Shipper/DeletedStatusShipper/{id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        //------------------------------------------------------------------------------------------------------------------------------
        public async Task<IActionResult> ActiveShipper(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:59815/api/Shipper/GetActiveShipper/{id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        //------------------------------------------------------------------------------------------------------------------------------
    }
}

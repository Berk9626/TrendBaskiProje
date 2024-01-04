using ECommerce.EntityLayer.Concrete;
using ECommerce.WebUI.Dtos.ShipperDto;
using ECommerce.WebUI.Dtos.SupplierDto;
using ECommerce.WebUI.ValidationRules.ShipperValidationRules;
using ECommerce.WebUI.ValidationRules.SupplierValidationRules;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace ECommerce.WebUI.Controllers.Response
{
    [Authorize(Roles = "Admin")]
    public class SupplierAdminController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public SupplierAdminController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        //------------------------------------------------------------------------------------------------------------------------------
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:59815/api/Supplier");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultSupplierDto>>(jsonData);
                return View(values);
            }
            return View();
        }
        //------------------------------------------------------------------------------------------------------------------------------
        [HttpGet]
        public IActionResult AddSupplier()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddSupplier(CreateSupplierDto model)
        {
            Supplier supplier = new Supplier();
            CreateSupplierValidator validationRules = new CreateSupplierValidator();
            FluentValidation.Results.ValidationResult result = validationRules.Validate(model);
            if (result.IsValid)
            {
                supplier.CompanyName = model.CompanyName;
                supplier.ContactName = model.ContactName;
                supplier.ContactTitle = model.ContactTitle;
                supplier.Address = model.Address;               
                supplier.City = model.City;
                supplier.Region = model.Region;
                supplier.PostalCode = model.PostalCode;
                supplier.Country = model.Country;
                supplier.Phone = model.Phone;
                
                var client = _httpClientFactory.CreateClient();
                var jsonData = JsonConvert.SerializeObject(supplier);
                StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var responseMessage = await client.PostAsync("http://localhost:59815/api/Supplier", content);

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
        public async Task<IActionResult> UpdateSupplier(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:59815/api/Supplier/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateSupplierDto>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateSupplier(UpdateSupplierDto model)
        {
            Supplier supplier = new Supplier();
            UpdateSupplierValidator validationRules = new UpdateSupplierValidator();
            FluentValidation.Results.ValidationResult result = validationRules.Validate(model);
            if (result.IsValid)
            {
                supplier.SupplierId = model.SupplierId;
                supplier.CompanyName = model.CompanyName;
                supplier.ContactName = model.ContactName;
                supplier.ContactTitle = model.ContactTitle;
                supplier.Address = model.Address;
                supplier.City = model.City;
                supplier.Region = model.Region;
                supplier.PostalCode = model.PostalCode;
                supplier.Country = model.Country;
                supplier.Phone = model.Phone;
                supplier.CreatedDate = model.CreatedDate;

                var client = _httpClientFactory.CreateClient();
                var jsonData = JsonConvert.SerializeObject(supplier);
                StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var responseMessage = await client.PutAsync("http://localhost:59815/api/Supplier", content);

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
        public async Task<IActionResult> DeleteSupplier(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"http://localhost:59815/api/Supplier/DeleteSupplier/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        //------------------------------------------------------------------------------------------------------------------------------
        public async Task<IActionResult> DeletedStatusSupplier(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"http://localhost:59815/api/Supplier/DeletedStatusSupplier/{id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        //------------------------------------------------------------------------------------------------------------------------------
        public async Task<IActionResult> ActiveSupplier(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:59815/api/Supplier/GetActiveSupplier/{id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        //------------------------------------------------------------------------------------------------------------------------------
    }
}

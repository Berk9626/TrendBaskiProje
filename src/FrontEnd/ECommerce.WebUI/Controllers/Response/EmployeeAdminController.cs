using Azure;
using ECommerce.EntityLayer.Concrete;
using ECommerce.EntityLayer.Enums;
using ECommerce.WebUI.Dtos.AboutDto;
using ECommerce.WebUI.Dtos.EmployeeDto;
using ECommerce.WebUI.Dtos.ProductDto;
using ECommerce.WebUI.ValidationRules.EmployeeValidation;
using ECommerce.WebUI.ValidationRules.ProductValidationRules;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace ECommerce.WebUI.Controllers.Response
{
    [Authorize(Roles = "Admin")]
    public class EmployeeAdminController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public EmployeeAdminController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        //------------------------------------------------------------------------------------------------------------------------------
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:59815/api/Employee/GetAllWithImages/");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultEmployeeDto>>(jsonData);
                return View(values);


            }
            return View();
        }
        //------------------------------------------------------------------------------------------------------------------------------
        [HttpGet]
        public IActionResult AddEmployee()
        {
            //List<string> genders = new();
            //foreach(string cinsiyet in Enum.GetNames(typeof(Gender)))
            //{
            //    genders.Add(cinsiyet);
            //}
            //ViewBag.gender = genders;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddEmployee(CreateEmployeeDto model)
        {
            CreateEmployeeValidator validationRules = new CreateEmployeeValidator();
            Employee employee = new Employee();

            FluentValidation.Results.ValidationResult result = validationRules.Validate(model);
            if (result.IsValid)
            {
                if (model.ImageFile != null)
                {
                    var extension = Path.GetExtension(model.ImageFile.FileName);
                    string newImageName = Guid.NewGuid() + extension;
                    var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/employeeImages/", newImageName);
                    var stream = new FileStream(location, FileMode.Create);
                    model.ImageFile.CopyTo(stream);
                    employee.ImageFile = newImageName;
                    employee.FirstName = model.FirstName;
                    employee.LastName = model.LastName;
                    employee.Title = model.Title;
                    employee.Gender = model.Gender;
                    employee.Birthday = model.Birthday;
                    employee.Phone = model.Phone;
                    employee.Email = model.Email;
                    employee.SocialMedia1 = model.SocialMedia1;
                    employee.SocialMedia2 = model.SocialMedia2;
                    employee.SocialMedia3 = model.SocialMedia3;
                }

                var client = _httpClientFactory.CreateClient();
                var jsonData = JsonConvert.SerializeObject(employee);
                StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var responseMessage = await client.PostAsync("http://localhost:59815/api/Employee", content);

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
        public async Task<IActionResult> UpdateEmployee(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:59815/api/Employee/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateEmployeeDto>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateEmployee(UpdateEmployeeDto model)
        {
            UpdateEmployeeValidator validationRules = new UpdateEmployeeValidator();
            Employee employee = new Employee();

            FluentValidation.Results.ValidationResult result = validationRules.Validate(model);
            if (result.IsValid)
            {
                if (model.ImagePath != null)
                {
                    var extension = Path.GetExtension(model.ImagePath.FileName);
                    string newImageName = Guid.NewGuid() + extension;
                    var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/employeeImages/", newImageName);
                    var stream = new FileStream(location, FileMode.Create);
                    model.ImagePath.CopyTo(stream);
                    employee.EmployeeId = model.EmployeeId;
                    employee.ImageFile = newImageName;
                    employee.FirstName = model.FirstName;
                    employee.LastName = model.LastName;
                    employee.Title = model.Title;
                    employee.Gender = model.Gender;
                    employee.Birthday = model.Birthday;
                    employee.Phone = model.Phone;
                    employee.Email = model.Email;
                    employee.SocialMedia1 = model.SocialMedia1;
                    employee.SocialMedia2 = model.SocialMedia2;
                    employee.SocialMedia3 = model.SocialMedia3;
                    employee.CreatedDate = model.CreatedDate;
                }

                var client = _httpClientFactory.CreateClient();
                var jsonData = JsonConvert.SerializeObject(employee);
                StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var responseMessage = await client.PutAsync("http://localhost:59815/api/Employee", content);

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
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"http://localhost:59815/api/Employee/DeleteEmployee/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        //------------------------------------------------------------------------------------------------------------------------------
        public async Task<IActionResult> DeletedStatusEmployee(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"http://localhost:59815/api/Employee/DeletedStatusEmployee/{id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        //------------------------------------------------------------------------------------------------------------------------------
        public async Task<IActionResult> ActiveEmployee(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:59815/api/Employee/GetActiveEmployee/{id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        //------------------------------------------------------------------------------------------------------------------------------
    }
}

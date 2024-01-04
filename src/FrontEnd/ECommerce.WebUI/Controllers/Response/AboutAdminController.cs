using ECommerce.EntityLayer.Concrete;
using ECommerce.WebUI.Dtos.AboutDto;
using ECommerce.WebUI.Dtos.BookingDto;
using ECommerce.WebUI.Dtos.CategoryDto;
using ECommerce.WebUI.ValidationRules.AboutValidationRules;
using ECommerce.WebUI.ValidationRules.CategoryValidationRules;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ECommerce.WebUI.Controllers.Response
{
    [Authorize(Roles = "Admin")]
    public class AboutAdminController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public AboutAdminController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        //------------------------------------------------------------------------------------------------------------------------------
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:59815/api/About");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultAboutDto>>(jsonData);
                return View(values);
            }
            return View();
        }
        //------------------------------------------------------------------------------------------------------------------------------
        [HttpGet]
        public IActionResult AddAbout()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddAbout(CreateAboutDto model)
        {
            About about = new About();
            CreateAboutValidator validationRules = new CreateAboutValidator();
            FluentValidation.Results.ValidationResult result = validationRules.Validate(model);
            if (result.IsValid)
            {
                about.Title1 = model.Title1;
                about.Title2 = model.Title2;
                about.Content = model.Content;
                about.EmployeeCount = model.EmployeeCount;
                about.ProductCount = model.ProductCount;
                about.CustomerCount = model.CustomerCount;

                var client = _httpClientFactory.CreateClient();
                var jsonData = JsonConvert.SerializeObject(about);
                StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var responseMessage = await client.PostAsync("http://localhost:59815/api/About", content);

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
        public async Task<IActionResult> UpdateAbout(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:59815/api/About/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateAboutDto>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateAbout(UpdateAboutDto model)
        {

            About about = new About();
            UpdateAboutValidator validationRules = new UpdateAboutValidator();
            FluentValidation.Results.ValidationResult result = validationRules.Validate(model);
            if (result.IsValid)
            {
                about.AboutId = model.AboutId;
                about.Title1 = model.Title1;
                about.Title2 = model.Title2;
                about.Content = model.Content;
                about.EmployeeCount = model.EmployeeCount;
                about.ProductCount = model.ProductCount;
                about.CustomerCount = model.CustomerCount;
                about.CreatedDate = model.CreatedDate;

                var client = _httpClientFactory.CreateClient();
                var jsonData = JsonConvert.SerializeObject(about);
                StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var responseMessage = await client.PutAsync("http://localhost:59815/api/About/", content);

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
        public async Task<IActionResult> DeleteAbout(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"http://localhost:59815/api/About/DeleteAbout/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        //------------------------------------------------------------------------------------------------------------------------------
        public async Task<IActionResult> DeletedStatusAbout(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"http://localhost:59815/api/About/DeletedStatusAbout/{id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        //------------------------------------------------------------------------------------------------------------------------------        
        public async Task<IActionResult> ActiveAbout(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:59815/api/About/GetActiveAbout/{id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        //------------------------------------------------------------------------------------------------------------------------------
    }
}

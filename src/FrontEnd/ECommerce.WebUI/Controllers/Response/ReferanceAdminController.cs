using ECommerce.EntityLayer.Concrete;
using ECommerce.WebUI.Dtos.ProductDto;
using ECommerce.WebUI.Dtos.ReferanceDto;
using ECommerce.WebUI.ValidationRules.ProductValidationRules;
using ECommerce.WebUI.ValidationRules.ReferanceValidationRules;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace ECommerce.WebUI.Controllers.Response
{
    [Authorize(Roles = "Admin")]
    public class ReferanceAdminController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public ReferanceAdminController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        //------------------------------------------------------------------------------------------------------------------------------
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:59815/api/Referance/GetAllWithImages/");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultReferanceDto>>(jsonData);

                return View(values);
            }
            return View();
        }
        //------------------------------------------------------------------------------------------------------------------------------
        [HttpGet]
        public IActionResult AddReferance()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddReferance(CreateReferanceDto model)
        {
            CreateReferanceValidator validationRules = new CreateReferanceValidator();
            Referance referance = new Referance();

            FluentValidation.Results.ValidationResult result = validationRules.Validate(model);
            if (result.IsValid)
            {
                if (model.Image != null)
                {
                    var extension = Path.GetExtension(model.Image.FileName);
                    string newImageName = Guid.NewGuid() + extension;
                    var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/referanceImages/", newImageName);
                    var stream = new FileStream(location, FileMode.Create);
                    model.Image.CopyTo(stream);
                    referance.Image = newImageName;
                    referance.Title = model.Title;
                    referance.Description = model.Description;
                    referance.Name = model.Name;
                }
                var client = _httpClientFactory.CreateClient();
                var jsonData = JsonConvert.SerializeObject(referance);
                StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var responseMessage = await client.PostAsync("http://localhost:59815/api/Referance", content);
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
        public async Task<IActionResult> UpdateReferance(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:59815/api/Referance/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateReferanceDto>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateReferance(UpdateReferanceDto model)
        {
            UpdateReferanceValidator validationRules = new UpdateReferanceValidator();
            Referance referance = new Referance();

            FluentValidation.Results.ValidationResult result = validationRules.Validate(model);
            if (result.IsValid)
            {
                if (model.ImagePath != null)
                {
                    var extension = Path.GetExtension(model.ImagePath.FileName);
                    string newImageName = Guid.NewGuid() + extension;
                    var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/referanceImages/", newImageName);
                    var stream = new FileStream(location, FileMode.Create);
                    model.ImagePath.CopyTo(stream);
                    referance.ReferanceId = model.ReferanceId;
                    referance.Image = newImageName;
                    referance.Description = model.Description;
                    referance.Title = model.Title;
                    referance.Name = model.Name;
                    referance.CreatedDate = model.CreatedDate;
                }

                var client = _httpClientFactory.CreateClient();
                var jsonData = JsonConvert.SerializeObject(referance);
                StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var responseMessage = await client.PutAsync("http://localhost:59815/api/Referance", content);
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
        public async Task<IActionResult> DeleteReferance(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"http://localhost:59815/api/Referance/DeleteReferance/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        //------------------------------------------------------------------------------------------------------------------------------
        public async Task<IActionResult> DeletedStatusReferance(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"http://localhost:59815/api/Referance/DeletedStatusReferance/{id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        //------------------------------------------------------------------------------------------------------------------------------
        public async Task<IActionResult> ActiveReferance(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:59815/api/Referance/GetActiveReferance/{id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        //------------------------------------------------------------------------------------------------------------------------------
    }
}

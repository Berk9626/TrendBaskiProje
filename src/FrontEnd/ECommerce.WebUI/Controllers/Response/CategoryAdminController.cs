using ECommerce.WebUI.Dtos.CategoryDto;
using ECommerce.WebUI.Dtos.ProductDto;
using ECommerce.EntityLayer;
using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Newtonsoft.Json;
using System.Text;
using ECommerce.WebUI.ValidationRules.CategoryValidationRules;
using FluentValidation.Results;
using FluentValidation;
using ECommerce.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;


namespace ECommerce.WebUI.Controllers.Response
{
    [Authorize(Roles = "Admin")]
    public class CategoryAdminController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public CategoryAdminController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        //------------------------------------------------------------------------------------------------------------------------------
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:59815/api/Category/GetAllWithImages/");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);

                return View(values);
            }
            return View();
        }
        //------------------------------------------------------------------------------------------------------------------------------
        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddCategory(CreateCategoryDto model)
        {
            CreateCategoryValidator validationRules = new CreateCategoryValidator();
            Category category = new Category();

            ValidationResult result = validationRules.Validate(model);
            if (result.IsValid)
            {
                if (model.CategoryImage != null)
                {
                    var extension = Path.GetExtension(model.CategoryImage.FileName);
                    string newImageName = Guid.NewGuid() + extension;
                    var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/categoryImages/", newImageName);
                    var stream = new FileStream(location, FileMode.Create);
                    model.CategoryImage.CopyTo(stream);
                    category.CategoryImage = newImageName;
                    category.CategoryName = model.CategoryName;
                    category.CategoryDescription = model.CategoryDescription;                   
                }

                var client = _httpClientFactory.CreateClient();
                var jsonData = JsonConvert.SerializeObject(category);
                StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var responseMessage = await client.PostAsync("http://localhost:59815/api/Category/", content);

                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }   
                
                return View();
            }
            else
            {
                foreach(var errors in result.Errors)
                {
                    ModelState.AddModelError(errors.PropertyName, errors.ErrorMessage);
                }
                return View(model);
            }         
                          
        }
        //------------------------------------------------------------------------------------------------------------------------------
        [HttpGet]
        public async Task<IActionResult> UpdateCategory(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:59815/api/Category/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateCategoryDto>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto model)
        {
            UpdateCategoryValidator validationRules = new UpdateCategoryValidator();
            Category category = new Category();

            ValidationResult result = validationRules.Validate(model);
            if (result.IsValid)
            {
                if (model.ImagePath != null)
                {
                    var extension = Path.GetExtension(model.ImagePath.FileName);
                    string newImageName = Guid.NewGuid() + extension;
                    var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/categoryImages/", newImageName);
                    var stream = new FileStream(location, FileMode.Create);
                    model.ImagePath.CopyTo(stream);
                    category.CategoryId = model.CategoryId;
                    category.CategoryImage = newImageName;
                    category.CategoryName = model.CategoryName;
                    category.CategoryDescription = model.CategoryDescription;
                    category.CreatedDate = model.CreatedDate;
                }

                var client = _httpClientFactory.CreateClient();
                var jsonData = JsonConvert.SerializeObject(category);
                StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var responseMessage = await client.PutAsync("http://localhost:59815/api/Category/", content);

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
        public async Task<IActionResult> DeletedStatusCategory(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"http://localhost:59815/api/Category/DeletedStatusCategory/{id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        //------------------------------------------------------------------------------------------------------------------------------
        public async Task<IActionResult> ActiveCategory(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:59815/api/Category/GetActiveCategory/{id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        //------------------------------------------------------------------------------------------------------------------------------
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"http://localhost:59815/api/Category/DeleteCategory/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        //------------------------------------------------------------------------------------------------------------------------------

    }
}

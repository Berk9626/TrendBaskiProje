using ECommerce.WebUI.Dtos.ProductDto;
using ECommerce.WebUI.Models;
using ECommerce.WebUI.ValidationRules.CategoryValidationRules;
using ECommerce.WebUI.ValidationRules.ProductValidationRules;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Net.Http;
using System.Text;
using FluentValidation;
using FluentValidation.Results;
using ECommerce.EntityLayer.Concrete;
using ECommerce.WebUI.Dtos.BookingDto;
using ECommerce.DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;

namespace ECommerce.WebUI.Controllers.Response
{
    [Authorize(Roles = "Admin")]
    public class ProductAdminController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public ProductAdminController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
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
            List<SelectListItem> selectedListItems2 = (from b in context.Suppliers.ToList()
                                                       select new SelectListItem
                                                       {
                                                           Text = b.CompanyName,
                                                           Value = b.SupplierId.ToString(),

                                                       }).ToList();

            ViewBag.dgr2 = selectedListItems2;
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:59815/api/Product/GetAllWithImages");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync(); 
                var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData); 

                return View(values);
            }
            return View();
        }
        //------------------------------------------------------------------------------------------------------------------------------
        [HttpGet]
        public IActionResult AddProduct()
        {
            Context context = new Context();
            List<SelectListItem> selectedListItems = (from c in context.Categories.ToList()
                                                      select new SelectListItem
                                                      {
                                                          Text = c.CategoryName,
                                                          Value = c.CategoryId.ToString(),

                                                      }).ToList();
           
            ViewBag.dgr3 = selectedListItems;
            List<SelectListItem> selectedListItems2 = (from c in context.Suppliers.ToList()
                                                       select new SelectListItem
                                                       {
                                                           Text = c.CompanyName,
                                                           Value = c.SupplierId.ToString(),

                                                       }).ToList();

            ViewBag.dgr4 = selectedListItems2;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddProduct(CreateProductDto model)
        {
            CreateProductValidator validationRules = new CreateProductValidator();
            Product product = new Product();

            FluentValidation.Results.ValidationResult result = validationRules.Validate(model);
            if(result.IsValid)
            {
                if (model.ImageFile != null)
                {
                    var extension = Path.GetExtension(model.ImageFile.FileName);
                    string newImageName = Guid.NewGuid() + extension;
                    var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/productImages/", newImageName);
                    var stream = new FileStream(location, FileMode.Create);
                    model.ImageFile.CopyTo(stream);
                    product.ImageFile = newImageName;
                    product.ProductName = model.ProductName;
                    product.ProductDescription = model.ProductDescription;
                    product.UnitPrice = model.UnitPrice;
                    product.UnitsInStock = model.UnitsInStock;
                    product.Title = model.Title;
                    product.CategoryId = model.CategoryId;
                    product.SupplierId = model.SupplierId;
                    product.Color = model.Color;
                    product.Size = model.Size;
                    
                }

                var client = _httpClientFactory.CreateClient();
                var jsonData = JsonConvert.SerializeObject(product);
                StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var responseMessage = await client.PostAsync("http://localhost:59815/api/Product", content);
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
        public async Task<IActionResult> UpdateProduct(int id)
        {
            Context context = new Context();
            List<SelectListItem> selectedListItems = (from c in context.Categories.ToList()
                                                      select new SelectListItem
                                                      {
                                                          Text = c.CategoryName,
                                                          Value = c.CategoryId.ToString(),

                                                      }).ToList();

            ViewBag.dgr5 = selectedListItems;
            List<SelectListItem> selectedListItems2 = (from c in context.Suppliers.ToList()
                                                      select new SelectListItem
                                                      {
                                                          Text = c.CompanyName,
                                                          Value = c.SupplierId.ToString(),

                                                      }).ToList();

            ViewBag.dgr6 = selectedListItems2;

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:59815/api/Product/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateProductDto>(jsonData);
              
                return View(values);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto model)
        {
            UpdateProductValidator validationRules = new UpdateProductValidator();
            Product product = new Product();

            FluentValidation.Results.ValidationResult result = validationRules.Validate(model);
            if (result.IsValid)
            {
                if (model.ImagePath != null)
                {
                    var extension = Path.GetExtension(model.ImagePath.FileName);
                    string newImageName = Guid.NewGuid() + extension;
                    var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/productImages/", newImageName);
                    var stream = new FileStream(location, FileMode.Create);
                    model.ImagePath.CopyTo(stream);
                    product.ImageFile = newImageName;
                    product.ProductId = model.ProductId;
                    product.ProductName = model.ProductName;
                    product.ProductDescription = model.ProductDescription;
                    product.UnitPrice = model.UnitPrice;
                    product.UnitsInStock = model.UnitsInStock;
                    product.Color = model.Color;
                    product.Size= model.Size;
                    product.Title = model.Title;
                    product.CategoryId = model.CategoryId;
                    product.SupplierId = model.SupplierId;
                    product.CreatedDate = model.CreatedDate;
                }

                var client = _httpClientFactory.CreateClient();
                var jsonData = JsonConvert.SerializeObject(product);
                StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var responseMessage = await client.PutAsync("http://localhost:59815/api/Product", content);
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
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"http://localhost:59815/api/Product/DeleteProduct/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        //------------------------------------------------------------------------------------------------------------------------------
        public async Task<IActionResult> DeletedStatusProduct(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"http://localhost:59815/api/Product/DeletedStatusProduct/{id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        //------------------------------------------------------------------------------------------------------------------------------
        public async Task<IActionResult> ActiveProduct(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:59815/api/Product/GetActiveProduct/{id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        //------------------------------------------------------------------------------------------------------------------------------

    }
}

using ECommerce.BusinessLayer.Abstract;
using ECommerce.DataAccessLayer.Abstract;
using ECommerce.DataAccessLayer.Concrete;
using ECommerce.EntityLayer.Concrete;
using ECommerce.MVC.Utils;
using ECommerce.WebUI.Dtos.BookingDto;
using ECommerce.WebUI.Dtos.ProductDto;
using ECommerce.WebUI.Models.CartModelsForMvc;
using ECommerce.WebUI.Models.ShoppingTools;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace ECommerce.WebUI.Controllers.Request
{
    [AllowAnonymous]
    public class ProductController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
           
        }
        //------------------------------------------------------------------------------------------------------------------------------
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:59815/api/Product/GetActivesProduct/");
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
        public async Task<IActionResult> ProductDetail(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:59815/api/Product/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultProductDto>(jsonData);

                return View(values);
            }
            return View();
        }
        //------------------------------------------------------------------------------------------------------------------------------
        [HttpPost]
        public async Task<IActionResult> ProductDetail(ResultProductDto resultProductDto)
        {
            var id = resultProductDto.ProductId;

            Context context = new Context();
            var getit = context.Products.Where(x => x.ProductId == resultProductDto.ProductId).FirstOrDefault();

            var product = getit;
            if (product != null)
            {
                CartService cartService;

                if (SessionHelper.GetProductFromJson<CartService>(HttpContext.Session, "sepet") == null)
                {
                    cartService = new CartService();
                }
                else
                {
                    cartService = SessionHelper.GetProductFromJson<CartService>(HttpContext.Session, "sepet");
                }

                CartModel cartItem = new CartModel();
                cartItem.Id = product.ProductId;
                cartItem.ProductName = product.ProductName;
                cartItem.UnitPrice = product.UnitPrice;

                cartService.AddItem(cartItem);
                SessionHelper.SetJsonProduct(HttpContext.Session, "sepet", cartService);


                return RedirectToAction("MyCart", "Shopping");


            }
            return RedirectToAction("Index", "Home");
        }
        //------------------------------------------------------------------------------------------------------------------------------



    }

}

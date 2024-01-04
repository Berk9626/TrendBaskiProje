using ECommerce.BusinessLayer.Abstract;
using ECommerce.BusinessLayer.Concrete;
using ECommerce.DataAccessLayer.Abstract;
using ECommerce.DataAccessLayer.EntityFramework;
using ECommerce.EntityLayer.Concrete;

using ECommerce.WebUI.Models.ShoppingTools;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Project.WebAPI.ExtensionClasses;

namespace ECommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IOrderService _orderService;
        private readonly IOrderDetailService _orderDetailService;
        public ShoppingController(IProductService productService, IOrderService orderService, IOrderDetailService orderDetailService)
        {
            _productService = productService;
            _orderService = orderService;
            _orderDetailService = orderDetailService;
        }
        //---------------------------------------------------------
        [HttpPost("AddProductToCart/{id}")] //burda id yoktu sade post vardı
        public async Task<IActionResult> AddProductToCart(int id)
        {
            Cart c = HttpContext.Session.GetObject<Cart>("scart") == null ? new Cart() : HttpContext.Session.GetObject<Cart>("scart");

            Product productEntity = await _productService.FindAsync(id);
            
            CartItem ci = new()
            {
                ID = productEntity.ProductId,
                Name = productEntity.ProductName,
                Price = productEntity.UnitPrice
                
            };

            c.AddToCart(ci);
            HttpContext.Session.SetObject("scart", c);
            return Ok($"{ci.Name} isimli ürün sepete eklenmiştir");
        }
        //---------------------------------------------------------
        [HttpGet]
        public async Task<IActionResult> GetCardInfo(int id)
        {

            if(HttpContext.Session.GetObject<Cart>("scart") != null)
            {
                Cart c = HttpContext.Session.GetObject<Cart>("scart");
                
                return Ok(c);
            }
            return BadRequest("Sepetinizde henüz bir ürün bulunmamaktadır");
        }
        //---------------------------------------------------------
        [HttpDelete]
        public async Task<IActionResult> DeleteFromCart(int id)
        {
            if (HttpContext.Session.GetObject<Cart>("scart") != null)
            {
                Cart c = HttpContext.Session.GetObject<Cart>("scart");
                c.RemoveFromCart(id);
                HttpContext.Session.SetObject("scart", c);
                return Ok(c);
            }
            else
            {
                return BadRequest("Sepetinizde ürün bulunmamaktadır");
            }
        }
        //---------------------------------------------------------
        [HttpPost("confirm")]
        public async Task<IActionResult> ConfirmOrder(string shippingAddress, int appUserID)
        {
            if (HttpContext.Session.GetObject<Cart>("scart") != null)
            {
                //API banka ile haberlesme kodları...
                Cart c = HttpContext.Session.GetObject<Cart>("scart");

                Order o = new()
                {
                    ShipAddress = shippingAddress,
                    AppUserId = appUserID
                };

                _orderService.Add(o);

                foreach(CartItem item in c.MyCart)
                {
                    OrderDetail od = new();
                    od.OrderId = o.OrderId;
                    od.ProductId = item.ID;
                    od.Quantity = item.Amount;
                    _orderDetailService.Add(od);
                   
                }
                return Ok($"Siparişiniz alınmıstır...Ödediginiz fiyat : {c.TotalPrice}");
            }
            else
            {
                return BadRequest("Sepetinizde ürün bulunmamaktadır");
            }
        }
        //---------------------------------------------------------

    }
}

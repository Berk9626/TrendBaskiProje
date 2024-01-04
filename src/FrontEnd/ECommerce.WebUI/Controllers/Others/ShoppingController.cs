using Castle.Core.Smtp;
using ECommerce.BusinessLayer.Abstract;
using ECommerce.EntityLayer.Concrete;
using ECommerce.MVC.Utils;
using ECommerce.WebUI.Models.CartModelsForMvc;
using ECommerce.WebUI.Models.ShoppingTools;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Project.WebAPI.ExtensionClasses;
using System.Web.Helpers;

namespace ECommerce.WebUI.Controllers.Others
{
    [Authorize(Roles = "Admin")]
    public class ShoppingController : Controller
    {
        private readonly IProductService _productService;
        private readonly UserManager<AppUser> _userManager;
        private readonly IOrderService _orderService;
        private readonly IOrderDetailService _orderDetailService;

        public ShoppingController(IProductService productService, UserManager<AppUser> userManager, IOrderService orderService, IOrderDetailService orderDetailService)
        {
            _productService = productService;
            _userManager = userManager;
            _orderService = orderService;
            _orderDetailService = orderDetailService;
        }
        //------------------------------------------------------------------------------------------------------------------------------
        public IActionResult AddToCart(int id)
        {
            var product = _productService.GetById(id);
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

                return RedirectToAction("Index", "Default");


            }
            return RedirectToAction("Index", "Default");
        }
        //------------------------------------------------------------------------------------------------------------------------------
        [HttpPost]
        public IActionResult UpdateCart(int id, short quantity)
        {
            var cart = SessionHelper.GetProductFromJson<CartService>(HttpContext.Session, "sepet");
            cart.UpdateItem(id, quantity);
            SessionHelper.SetJsonProduct(HttpContext.Session, "sepet", cart);
            return RedirectToAction("MyCart");
        }
        //------------------------------------------------------------------------------------------------------------------------------
        public IActionResult DeleteCart(int id)
        {
            var cart = SessionHelper.GetProductFromJson<CartService>(HttpContext.Session, "sepet");
            cart.DeleteItem(id);
            SessionHelper.SetJsonProduct(HttpContext.Session, "sepet", cart);
            return RedirectToAction("Index", "Default");
        }
        //------------------------------------------------------------------------------------------------------------------------------
        public IActionResult MyCart()
        {
            return View();
        }
        //------------------------------------------------------------------------------------------------------------------------------
        public async Task<IActionResult> CompleteCart()
        {

            var cart = SessionHelper.GetProductFromJson<CartService>(HttpContext.Session, "sepet");
          
            Order order = new Order();
            var user = await _userManager.GetUserAsync(User);
            order.ShipperId = 1;
            order.EmployeeId = 1;
            order.OrderBasket = Guid.NewGuid();
            order.OrderDate = DateTime.Now;
            order.CreatedDate = DateTime.Now;
            order.ShippedDate = null;
            order.AppUser = user;
            
            _orderService.CreateOrder(order);
          
            foreach (var item in cart.MyCart)
            {
                OrderDetail orderDetail = new OrderDetail();
                Product product = _productService.GetById(item.Value.Id);
                orderDetail.Product = product;
                orderDetail.Quantity = item.Value.Quantity;
                orderDetail.UnitPrice = item.Value.UnitPrice;

                orderDetail.Order = order;
                order.OrderDetails.Add(orderDetail);
                _orderDetailService.TCreateOrderDetail(orderDetail);

            }

            SessionHelper.RemoveSession(HttpContext.Session, "sepet");

            return RedirectToAction("Confirmation", order);
        }


        public IActionResult Confirmation(Order order)
        {
            return View(order);
        }
        //------------------------------------------------------------------------------------------------------------------------------
    }
}

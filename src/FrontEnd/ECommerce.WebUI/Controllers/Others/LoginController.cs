using ECommerce.EntityLayer.Concrete;
using ECommerce.WebUI.Dtos.LoginDto;
using ECommerce.WebUI.Dtos.RegisterDto;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp;
using System.Runtime.InteropServices;
using System.Security.Claims;

namespace ECommerce.WebUI.Controllers.Others
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        public LoginController(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }
        //------------------------------------------------------------------------------------------------------------------------------
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        //------------------------------------------------------------------------------------------------------------------------------
        [HttpPost]
        public async Task<IActionResult> Index(LoginUserDto loginUserDto)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(loginUserDto.UserName, loginUserDto.Password, false, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Default");
                }
                else
                {
                    return View();
                }

            }

            return View();
        }
        //------------------------------------------------------------------------------------------------------------------------------
        public async Task<IActionResult> Logout ()
        {
            //await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Default");
        }


    }
}

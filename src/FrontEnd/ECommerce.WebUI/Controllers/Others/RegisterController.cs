using ECommerce.EntityLayer.Concrete;
using ECommerce.WebUI.Dtos.RegisterDto;
using ECommerce.WebUI.Models.MailViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebUI.Controllers.Others
{
    [AllowAnonymous]
    public class RegisterController : Controller
    {
        
        private readonly UserManager<AppUser> _userManager;
        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        //------------------------------------------------------------------------------------------------------------------------------
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        //------------------------------------------------------------------------------------------------------------------------------
        [HttpPost]
        public async Task<IActionResult> Index(CreateNewUserDto createNewUser)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var appUser = new AppUser()
            {
                FirstName = createNewUser.Name,
                LastName = createNewUser.Surname,
                Email = createNewUser.Mail,
                UserName = createNewUser.UserName,
                CreatedDate = DateTime.Now,
               
                
                
            };
           
            var result = await _userManager.CreateAsync(appUser,createNewUser.Password);

            if (result.Succeeded)
            {
                var roleResult = await _userManager.AddToRoleAsync(appUser, "Üye");
                var token = await _userManager.GenerateEmailConfirmationTokenAsync(appUser);
                var confirmationLink = Url.Action(nameof(ConfirmEmail), "Register", new { token, email = appUser.Email }, Request.Scheme);
                MailSender.SendEmail(appUser.Email!, "E-Mail Adresinizi Onaylayın!", $"Sevgili, {appUser.FirstName} kayıt olduğun için teşekkürler, kayıt olma işlemi başarılı! Hayalindeki ürünü rezerve etmeye hazırsın! Kaliteli vakit geçirmen dileğiyle, TrendBaskıDestek. Lütfen aşağıdaki linke tıklayarak üyelik işlemini tamamla; {confirmationLink!}");
                return RedirectToAction("Index", "Default");
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        //------------------------------------------------------------------------------------------------------------------------------
        public async Task<IActionResult> ConfirmEmail(string token, string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user != null)
            {
                var result = await _userManager.ConfirmEmailAsync(user, token);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Login");
                }
            }
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
        //------------------------------------------------------------------------------------------------------------------------------



    }

}

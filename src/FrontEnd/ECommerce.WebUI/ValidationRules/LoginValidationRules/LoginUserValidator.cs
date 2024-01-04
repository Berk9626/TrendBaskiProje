using ECommerce.DataAccessLayer.Concrete;
using ECommerce.EntityLayer.Concrete;
using ECommerce.WebUI.Dtos.LoginDto;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using System.Web.Helpers;

namespace ECommerce.WebUI.ValidationRules.LoginValidationRules
{
    public class LoginUserValidator : AbstractValidator<LoginUserDto>
    {
        public LoginUserValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Lütfen Kullanıcı Adınızı Giriniz");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Lütfen Şifrenizi Giriniz");
            RuleFor(x => new { x.UserName, x.Password })
            .Must(credentials => IsLoginValid(credentials.UserName, credentials.Password))
            .WithMessage("Kullanıcı adı veya şifre yanlış");
        }

        private bool IsLoginValid(string username, string password)
        {
            Context context = new Context();
            var user = context.Users.SingleOrDefault(u => u.UserName == username);

            if (user == null)
            {
                // Kullanıcı adı bulunamadı.
                return false;
            }

            // Şifre karşılaştırması için PasswordHasher kullanılıyor
            var passwordHasher = new PasswordHasher<AppUser>();
            var passwordVerificationResult = passwordHasher.VerifyHashedPassword(user, user.PasswordHash, password);

            // Şifre doğrulama başarısızsa veya kullanıcı devre dışı bırakılmışsa, false döndür.
            if (passwordVerificationResult != PasswordVerificationResult.Success)
            {
                return false;
            }

            return true;

        }
        
    }
}

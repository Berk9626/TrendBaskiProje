using ECommerce.DataAccessLayer.Concrete;
using ECommerce.EntityLayer.Concrete;
using ECommerce.WebUI.Dtos.RegisterDto;
using FluentValidation;
using Microsoft.AspNetCore.Components.Forms;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.WebUI.ValidationRules.RegisterValidationRules
{
    public class CreateNewUserValidator : AbstractValidator<CreateNewUserDto>
    {       
        public CreateNewUserValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Lütfen Adınızı Giriniz")
            .MaximumLength(25).WithMessage("Ad alanı en fazla 25 karakter olmalıdır.")
            .MinimumLength(2).WithMessage("Ad alanı en az 2 karakter olmalıdır.");

            RuleFor(x => x.Surname).NotEmpty().WithMessage("Lütfen Soyadınızı Giriniz")
            .MaximumLength(25).WithMessage("Soyad alanı en fazla 25 karakter olmalıdır.")
            .MinimumLength(2).WithMessage("Soyad alanı en az 2 karakter olmalıdır.");

            RuleFor(x => x.UserName).NotEmpty().WithMessage("Lütfen Kullanıcı Adınızı Giriniz")
            .MaximumLength(25).WithMessage("Soyad alanı en fazla 25 karakter olmalıdır.")
            .MinimumLength(2).WithMessage("Soyad alanı en az 2 karakter olmalıdır.");

            RuleFor(x => x.Mail).NotEmpty().WithMessage("Lütfen E-mail Adresinizi Giriniz")
                .EmailAddress().WithMessage("Lütfen E-mail Formatında Yazınız bkz. '@gmail.com' ")
                .Must((e, Email) => !IsEmailexist(Email)).WithMessage("Bu mail zaten kullanılmaktadır");

            RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Şifre boş geçilemez")
            .Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{12,30}$")
            .WithMessage("Şifre en az 12, en fazla 30 karakterden oluşmalı ve en az bir tane büyük, küçük harf ve rakam içermelidir.");

            RuleFor(x => x.ConfirmPassword).NotEmpty().WithMessage("Lütfen Şifrenizi Tekrar Giriniz")
            .Must((CreateNewUserDto, confirmPassword, context) =>
            {
                return confirmPassword == CreateNewUserDto.Password;
            }).WithMessage("Şifreler Uyuşmamaktadır");
       
        }

        private Context context = new Context();
        private bool IsEmailexist(string Email)
        {

            return context.Users.Where(x => x.Email == Email).Any();
        }


    }
}

//[Required(ErrorMessage = "Lütfen adınızı giriniz.")]
//public string Name { get; set; }
//[Required(ErrorMessage = "Lütfen soyadınızı giriniz.")]
//public string Surname { get; set; }
//[Required(ErrorMessage = "Lütfen kullanıcı adınızı giriniz.")]
//public string UserName { get; set; }
//[Required(ErrorMessage = "Lütfen e-mail adresinizi giriniz.")]
//public string Mail { get; set; }
//[Required(ErrorMessage = "Lütfen şifrenizi giriniz.")]
//public string Password { get; set; }
//[Required(ErrorMessage = "Lütfen şifrenizi tekrar giriniz.")]
//[Compare("Password", ErrorMessage = "Şifreler uyuşmamaktadır.")]
//public string ConfirmPassword { get; set; }

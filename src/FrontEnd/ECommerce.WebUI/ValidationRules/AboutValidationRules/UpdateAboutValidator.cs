using ECommerce.WebUI.Dtos.AboutDto;
using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.WebUI.ValidationRules.AboutValidationRules
{
    public class UpdateAboutValidator : AbstractValidator<UpdateAboutDto>
    {
        public UpdateAboutValidator()
        {
            //RuleFor(x => x.Title1).NotEmpty().WithMessage("Başlık 1 Boş Geçilemez")
            //.MaximumLength(500).WithMessage("Ad alanı en fazla 500 karakter olmalıdır.")
            //.MinimumLength(10).WithMessage("Ad alanı en az 10 karakter olmalıdır.");

            //RuleFor(x => x.Title2).NotEmpty().WithMessage("Başlık 2 Boş Geçilemez")
            //.MaximumLength(500).WithMessage("Ad alanı en fazla 500 karakter olmalıdır.")
            //.MinimumLength(10).WithMessage("Ad alanı en az 10 karakter olmalıdır.");

            //RuleFor(x => x.Content).NotEmpty().WithMessage("İçerik Boş Geçilemez")
            //.MaximumLength(500).WithMessage("Ad alanı en fazla 500 karakter olmalıdır.")
            //.MinimumLength(10).WithMessage("Ad alanı en az 10 karakter olmalıdır.");

            //RuleFor(x => x.EmployeeCount).NotEmpty().WithMessage("Çalışan Sayısı Boş Geçilemez")
            //.MaximumLength(50).WithMessage("Ad alanı en fazla 50 karakter olmalıdır.")
            //.MinimumLength(1).WithMessage("Ad alanı en az 1 karakter olmalıdır.");

            //RuleFor(x => x.CustomerCount).NotEmpty().WithMessage("Müşteri Sayısı Boş Geçilemez")
            //.MaximumLength(50).WithMessage("Ad alanı en fazla 50 karakter olmalıdır.")
            //.MinimumLength(1).WithMessage("Ad alanı en az 1 karakter olmalıdır.");

            //RuleFor(x => x.ProductCount).NotEmpty().WithMessage("Ürün Sayısı Boş Geçilemez")
            //.MaximumLength(50).WithMessage("Ad alanı en fazla 50 karakter olmalıdır.")
            //.MinimumLength(1).WithMessage("Ad alanı en az 1 karakter olmalıdır.");
        }
        
    }
}

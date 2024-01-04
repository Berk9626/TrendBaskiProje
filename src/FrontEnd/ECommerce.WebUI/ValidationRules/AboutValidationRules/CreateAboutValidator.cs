using ECommerce.WebUI.Dtos.AboutDto;
using FluentValidation;
using FluentValidation.AspNetCore;

namespace ECommerce.WebUI.ValidationRules.AboutValidationRules
{
    public class CreateAboutValidator : AbstractValidator<CreateAboutDto>
    {
        public CreateAboutValidator()
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

//public string Title1 { get; set; }
//public string Title2 { get; set; }
//public string Content { get; set; }
//public string EmployeeCount { get; set; }
//public string CustomerCount { get; set; }
//public string ProductCount { get; set; }
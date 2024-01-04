using ECommerce.WebUI.Dtos.ReferanceDto;
using FluentValidation;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ECommerce.WebUI.ValidationRules.ReferanceValidationRules
{
    public class UpdateReferanceValidator : AbstractValidator<UpdateReferanceDto>
    {
        public UpdateReferanceValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Referans Adı Boş Geçilemez")
            .MaximumLength(50).WithMessage("Ad alanı en fazla 50 karakter olmalıdır.")
            .MinimumLength(10).WithMessage("Ad alanı en az 10 karakter olmalıdır.");

            RuleFor(x => x.Title).NotEmpty().WithMessage("Referans Başlığı Boş Geçilemez")
            .MaximumLength(50).WithMessage("Ad alanı en fazla 50 karakter olmalıdır.")
            .MinimumLength(10).WithMessage("Ad alanı en az 10 karakter olmalıdır.");

            RuleFor(x => x.Description).NotEmpty().WithMessage("Referans Açıklaması Boş Geçilemez")
            .MaximumLength(500).WithMessage("Ad alanı en fazla 500 karakter olmalıdır.")
            .MinimumLength(10).WithMessage("Ad alanı en az 10 karakter olmalıdır.");

            //RuleFor(x => x.Image)
            //.NotEmpty().WithMessage("Resim dosyası gereklidir.")
            //.Must(BeAValidImage).WithMessage("Geçersiz resim dosyası. Desteklenmeyen uzantı veya boyut.");
        }

        //private bool BeAValidImage(IFormFile file)
        //{
        //    if (file == null)
        //    {
        //        return false;
        //    }

        //    // Desteklenen dosya uzantıları
        //    var allowedExtensions = new[] { ".png", ".jpg", ".jpeg" };

        //    // Dosya uzantısını kontrol et
        //    var fileExtension = System.IO.Path.GetExtension(file.FileName).ToLower();
        //    if (!allowedExtensions.Contains(fileExtension))
        //    {
        //        return false;
        //    }

        //    // Dosya boyutunu kontrol et (örneğin, 5 MB olarak belirledik)
        //    var maxFileSizeInBytes = 5 * 1024 * 1024; // 5 MB
        //    if (file.Length > maxFileSizeInBytes)
        //    {
        //        return false;
        //    }

        //    return true;
        //}
    }
}

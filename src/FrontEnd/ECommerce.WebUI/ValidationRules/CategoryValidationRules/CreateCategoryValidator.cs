using ECommerce.WebUI.Dtos.CategoryDto;
using FluentValidation;

namespace ECommerce.WebUI.ValidationRules.CategoryValidationRules
{
    public class CreateCategoryValidator : AbstractValidator<CreateCategoryDto>
    {
        public CreateCategoryValidator()
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Kategori Adı Boş Geçilemez")
            .MaximumLength(500).WithMessage("Kategori Açıklaması En Fazla 500 karakter olmalıdır.")
            .MinimumLength(10).WithMessage("Kategori Açıklaması En az 10 karakter olmalıdır.");

            RuleFor(x => x.CategoryDescription).NotEmpty().WithMessage("Kategori Açıklaması Boş Geçilemez")
            .MaximumLength(500).WithMessage("Kategori Açıklaması En Fazla 500 karakter olmalıdır.")
            .MinimumLength(10).WithMessage("Kategori Açıklaması En az 10 karakter olmalıdır.");

            //RuleFor(x => x.CategoryImage)
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

//public string CategoryName { get; set; }
//public string CategoryDescription { get; set; }
//public string CategoryImage { get; set; }

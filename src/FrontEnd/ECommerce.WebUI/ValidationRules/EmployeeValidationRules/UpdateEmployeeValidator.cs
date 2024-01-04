using ECommerce.WebUI.Dtos.EmployeeDto;
using FluentValidation;

namespace ECommerce.WebUI.ValidationRules.EmployeeValidation
{
    public class UpdateEmployeeValidator : AbstractValidator<UpdateEmployeeDto>
    {
        public UpdateEmployeeValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("Çalışan Adı Boş Geçilemez")
           .MaximumLength(30).WithMessage("Ad alanı en fazla 30 karakter olmalıdır.")
           .MinimumLength(3).WithMessage("Ad alanı en az 3 karakter olmalıdır.");

            RuleFor(x => x.LastName).NotEmpty().WithMessage("Çalışanın Soyadı Boş Geçilemez")
           .MaximumLength(30).WithMessage("Soyad alanı en fazla 30 karakter olmalıdır.")
           .MinimumLength(3).WithMessage("Soyad alanı en az 3 karakter olmalıdır.");

            RuleFor(x => x.Title).NotEmpty().WithMessage("Çalışanın Ünvanı Boş Geçilemez")
           .MaximumLength(30).WithMessage("Ünvan alanı en fazla 30 karakter olmalıdır.")
           .MinimumLength(3).WithMessage("Ünvan alanı en az 3 karakter olmalıdır.");

            //RuleFor(x => x.ImageFile).NotEmpty().WithMessage("Resim dosyası gereklidir.")
            //.Must(BeAValidImage).WithMessage("Geçersiz resim dosyası. Desteklenmeyen uzantı veya boyut.");

            RuleFor(x => x.Email).NotEmpty().WithMessage("E-posta adresi boş bırakılamaz.")
            .EmailAddress().WithMessage("Geçersiz e-posta adresi formatı.");

            RuleFor(x => x.Phone).NotEmpty().WithMessage("Çalışanın Telefon Numarası Boş Geçilemez")
            .Matches(@"^\d{11}$").WithMessage("Geçersiz telefon numarası formatı, lütfen 11 haneli telefon numaranızı yazınız.");

            RuleFor(x => x.Birthday).NotEmpty().WithMessage("Çalışanın Doğum Günü Boş Geçilemez");

            RuleFor(x => x.Gender).NotEmpty().WithMessage("Çalışanın Cinsiyeti Boş Geçilemez");

            RuleFor(x => x.SocialMedia1).NotEmpty().WithMessage("Çalışanın Sosyal Medya Hesabı-1 Boş Geçilemez");

            RuleFor(x => x.SocialMedia2).NotEmpty().WithMessage("Çalışanın Sosyal Medya Hesabı-2 Boş Geçilemez");

            RuleFor(x => x.SocialMedia3).NotEmpty().WithMessage("Çalışanın Sosyal Medya Hesabı-3 Boş Geçilemez");
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

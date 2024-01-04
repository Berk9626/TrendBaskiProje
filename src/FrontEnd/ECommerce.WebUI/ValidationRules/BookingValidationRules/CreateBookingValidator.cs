using ECommerce.DataAccessLayer.Concrete;
using ECommerce.EntityLayer.Concrete;
using ECommerce.WebUI.Dtos.BookingDto;
using FluentValidation;

namespace ECommerce.WebUI.ValidationRules.BookingValidationRules
{
    public class CreateBookingValidator : AbstractValidator<CreateBookingDto>
    {
        public CreateBookingValidator()
        {
            
            RuleFor(dto => dto.FirstName)
            .NotEmpty().WithMessage("Ad alanı boş bırakılamaz.")
            .MaximumLength(25).WithMessage("Ad alanı en fazla 25 karakter olmalıdır.")
            .MinimumLength(3).WithMessage("Ad alanı en az 3 karakter olmalıdır.");

            RuleFor(dto => dto.LastName)
            .NotEmpty().WithMessage("Soyad alanı boş bırakılamaz.")
            .MaximumLength(30).WithMessage("Soyad alanı en fazla 30 karakter olmalıdır.");

            RuleFor(dto => dto.Email)
            .NotEmpty().WithMessage("E-posta adresi boş bırakılamaz.")
            .EmailAddress().WithMessage("Geçersiz e-posta adresi formatı.");               

            //RuleFor(dto => dto.CheckIn)
            //    .NotEmpty().WithMessage("Giriş tarihi boş bırakılamaz.")
            //    .Must(date => date > DateTime.Now).WithMessage("Giriş tarihi gelecekte bir tarih olmalıdır.");

            //RuleFor(dto => dto.CheckOut)
            //    .NotEmpty().WithMessage("Çıkış tarihi boş bırakılamaz.")
            //    .Must((dto, checkOut) => checkOut > dto.CheckIn).WithMessage("Çıkış tarihi giriş tarihinden sonra olmalıdır.");

            //RuleFor(dto => dto.ImageFile)
            //    .NotEmpty().WithMessage("Resim dosyası gereklidir.")
            //    .Must(file => /* Özel dosya doğrulama mantığınızı buraya ekleyin */)
            //        .WithMessage("Geçersiz resim dosyası.");

            RuleFor(dto => dto.Phone)
            .NotEmpty().WithMessage("Telefon numarası boş bırakılamaz.")
            .Matches(@"^\d{11}$").WithMessage("Geçersiz telefon numarası formatı, lütfen 11 haneli telefon numaranızı yazınız.");

            RuleFor(dto => dto.SpecialRequest)
            .NotEmpty().WithMessage("Açıklama mesajı boş bırakılamaz.")
            .MaximumLength(500).WithMessage("Özel İstek en fazla 500 karakter olmalıdır.");

            RuleFor(dto => dto.CategoryId)
            .NotEmpty().WithMessage("Kategori boş bırakılamaz.")
            .GreaterThan(0).WithMessage("Kategori ID 0'dan büyük olmalıdır.");
                
        }
        
    }
    
}

//public string FirstName { get; set; }
//public string LastName { get; set; }
//public string Email { get; set; }
//public DateTime CheckIn { get; set; }
//public DateTime CheckOut { get; set; }
//public string ImageFile { get; set; }
//public string Phone { get; set; }
//public string SpecialRequest { get; set; }
//public int CategoryId { get; set; }

//[JsonIgnore]
//public virtual Category Category { get; set; }

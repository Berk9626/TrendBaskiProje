using ECommerce.WebUI.Dtos.SupplierDto;
using FluentValidation;

namespace ECommerce.WebUI.ValidationRules.SupplierValidationRules
{
    public class UpdateSupplierValidator : AbstractValidator<UpdateSupplierDto>
    {
        public UpdateSupplierValidator()
        {
            RuleFor(x => x.CompanyName).NotEmpty().WithMessage("Tedarikçi Firma Adı Boş Geçilemez")
            .MaximumLength(25).WithMessage("Tedarikçi Firma Ad alanı en fazla 25 karakter olmalıdır.")
            .MinimumLength(2).WithMessage("Tedarikçi Firma Ad alanı en az 2 karakter olmalıdır.");

            RuleFor(x => x.ContactName).NotEmpty().WithMessage("Tedarikçi Ad ve Soyad Boş Geçilemez")
            .MaximumLength(25).WithMessage("Tedarikçi Ad ve Soyad alanı en fazla 25 karakter olmalıdır.")
            .MinimumLength(2).WithMessage("Tedarikçi Ad ve Soyad alanı en az 2 karakter olmalıdır.");

            RuleFor(x => x.ContactTitle).NotEmpty().WithMessage("Tedarikçi Ünvanı Boş Geçilemez")
            .MaximumLength(25).WithMessage("Tedarikçi Ünvan alanı en fazla 25 karakter olmalıdır.")
            .MinimumLength(2).WithMessage("Tedarikçi Ünvan alanı en az 2 karakter olmalıdır.");

            RuleFor(x => x.Address).NotEmpty().WithMessage("Tedarikçi Adresi Geçilemez")
            .MaximumLength(100).WithMessage("Tedarikçi Adresi alanı en fazla 100 karakter olmalıdır.")
            .MinimumLength(2).WithMessage("Tedarikçi Adresi alanı en az 2 karakter olmalıdır.");

            RuleFor(x => x.City).NotEmpty().WithMessage("Tedarikçi Şehir Adı Boş Geçilemez")
            .MaximumLength(25).WithMessage("Tedarikçi Şehir alanı en fazla 25 karakter olmalıdır.")
            .MinimumLength(2).WithMessage("Tedarikçi Şehir alanı en az 2 karakter olmalıdır.");

            RuleFor(x => x.Country).NotEmpty().WithMessage("Tedarikçi Ülke Adı Boş Geçilemez")
            .MaximumLength(25).WithMessage("Tedarikçi Ülke alanı en fazla 25 karakter olmalıdır.")
            .MinimumLength(2).WithMessage("Tedarikçi Ülke alanı en az 2 karakter olmalıdır.");

            RuleFor(x => x.Phone).NotEmpty().WithMessage("Tedarikçi Telefon Numarası Boş Geçilemez")
            .Matches(@"^\d{11}$").WithMessage("Geçersiz telefon numarası formatı, lütfen 11 haneli telefon numaranızı yazınız.");
        }
    }
}

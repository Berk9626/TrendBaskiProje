using ECommerce.WebUI.Dtos.ProductDto;
using FluentValidation;

namespace ECommerce.WebUI.ValidationRules.ProductValidationRules
{
    public class UpdateProductValidator : AbstractValidator<UpdateProductDto>
    {
        public UpdateProductValidator()
        {
            RuleFor(x => x.ProductName).NotEmpty().WithMessage("Ürün Adı Boş Geçilemez")
            .MaximumLength(50).WithMessage("Ad alanı en fazla 50 karakter olmalıdır.")
            .MinimumLength(10).WithMessage("Ad alanı en az 10 karakter olmalıdır.");

            RuleFor(x => x.ProductDescription).NotEmpty().WithMessage("Ürün Açıklaması Boş Geçilemez")
            .MaximumLength(500).WithMessage("Açıklama alanı en fazla 500 karakter olmalıdır.")
            .MinimumLength(10).WithMessage("Açıklama alanı en az 10 karakter olmalıdır.");

            RuleFor(x => x.UnitPrice).NotEmpty().WithMessage("Ürünün Fiyatı Boş Geçilemez")
            .GreaterThan(0).WithMessage("Ürünün Fiyatı sıfırdan büyük olmalıdır");

            RuleFor(x => x.UnitsInStock).NotEmpty().WithMessage("Ürünün Stok Miktarı Boş Geçilemez");

            RuleFor(x => x.Title).NotEmpty().WithMessage("Ürünün Başlığı Boş Geçilemez")
            .MaximumLength(50).WithMessage("Açıklama alanı en fazla 50 karakter olmalıdır.")
            .MinimumLength(10).WithMessage("Açıklama alanı en az 10 karakter olmalıdır.");

            //RuleFor(x => x.ImageFile)
            //.NotEmpty().WithMessage("Resim dosyası gereklidir.")
            //.Must(BeAValidImage).WithMessage("Geçersiz resim dosyası. Desteklenmeyen uzantı veya boyut.");

            RuleFor(x => x.Color).NotEmpty().WithMessage("Ürünün Rengi Boş Geçilemez");

            RuleFor(x => x.Size).NotEmpty().WithMessage("Ürünün Ölçüsü Boş Geçilemez");

            RuleFor(x => x.SupplierId).NotEmpty().WithMessage("Ürünün Tedarikçisi Boş Geçilemez")
            .GreaterThan(0).WithMessage("Supplier ID 0'dan büyük olmalıdır.");

            RuleFor(x => x.CategoryId).NotEmpty().WithMessage("Ürünün Kategorisi Boş Geçilemez")
            .GreaterThan(0).WithMessage("Kategori ID 0'dan büyük olmalıdır.");
        }
        
    }
}

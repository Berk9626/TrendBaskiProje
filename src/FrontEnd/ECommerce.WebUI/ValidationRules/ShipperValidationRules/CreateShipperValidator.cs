using Castle.Components.DictionaryAdapter.Xml;
using ECommerce.EntityLayer.Concrete;
using ECommerce.WebUI.Dtos.ShipperDto;
using FluentValidation;

namespace ECommerce.WebUI.ValidationRules.ShipperValidationRules
{
    public class CreateShipperValidator : AbstractValidator<CreateShipperDto>
    {
        public CreateShipperValidator()
        {
            RuleFor(x => x.ShipperName).NotEmpty().WithMessage("Postane Firma Adı Boş Geçilemez")
            .MaximumLength(25).WithMessage("Firma Ad alanı en fazla 25 karakter olmalıdır.")
            .MinimumLength(2).WithMessage("Firma Ad alanı en az 2 karakter olmalıdır.");

            RuleFor(x => x.ShipperEmail).NotEmpty().WithMessage("Postane E-Mail Adresi Boş Geçilemez")
            .EmailAddress().WithMessage("Lütfen E-mail Formatında Yazınız bkz. '@gmail.com' ");
            
            RuleFor(x => x.ShipperPhone).NotEmpty().WithMessage("Postane Telefon Numarası Boş Geçilemez")
            .Matches(@"^\d{11}$").WithMessage("Geçersiz telefon numarası formatı, lütfen 11 haneli telefon numaranızı yazınız.");
        }
    }
}

//public string ShipperName { get; set; }
//public string ShipperEmail { get; set; }
//public string ShipperPhone { get; set; }

////Relational Properties
//[JsonIgnore]
//public virtual List<Order> Orders { get; set; }
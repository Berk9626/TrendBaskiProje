using ECommerce.WebUI.Dtos.SubscribeDto;
using FluentValidation;

namespace ECommerce.WebUI.ValidationRules.SubscribeValidationRules
{
    public class CreateSubscribeValidator : AbstractValidator<CreateSubscribeDto>
    {
        public CreateSubscribeValidator()
        {
            RuleFor(x => x.Mail).NotEmpty().WithMessage("Lütfen E-Mail Adresinizi Giriniz")
            .EmailAddress().WithMessage("Geçersiz e-posta adresi formatı.");
        }
    }
}

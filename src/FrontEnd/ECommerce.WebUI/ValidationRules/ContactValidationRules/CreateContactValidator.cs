using ECommerce.WebUI.Dtos.ContactDto;
using FluentValidation;

namespace ECommerce.WebUI.ValidationRules.ContactValidationRules
{
    public class CreateContactValidator : AbstractValidator<CreateContactDto>
    {
        public CreateContactValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Kategori Adı Boş Geçilemez")
            .MaximumLength(500).WithMessage("Kategori Açıklaması En Fazla 500 karakter olmalıdır.")
            .MinimumLength(10).WithMessage("Kategori Açıklaması En az 10 karakter olmalıdır.");

            RuleFor(x => x.Email)
            .NotEmpty().WithMessage("E-posta adresi boş bırakılamaz.")
            .EmailAddress().WithMessage("Geçersiz e-posta adresi formatı.");

            RuleFor(x => x.Subject).NotEmpty().WithMessage("Kategori Adı Boş Geçilemez")
            .MaximumLength(500).WithMessage("Kategori Açıklaması En Fazla 500 karakter olmalıdır.")
            .MinimumLength(10).WithMessage("Kategori Açıklaması En az 10 karakter olmalıdır.");

            RuleFor(x => x.Message).NotEmpty().WithMessage("Kategori Açıklaması Boş Geçilemez")
            .MaximumLength(500).WithMessage("Kategori Açıklaması En Fazla 500 karakter olmalıdır.")
            .MinimumLength(10).WithMessage("Kategori Açıklaması En az 10 karakter olmalıdır.");

           
            
        }
    }
}





//public string Name { get; set; }
//public string Email { get; set; }
//public string Subject { get; set; }
//public string Message { get; set; }
//public DateTime Date { get; set; }

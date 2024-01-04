using ECommerce.EntityLayer.Concrete;
using ECommerce.WebUI.Dtos.AppRoleDto;
using FluentValidation;

namespace ECommerce.WebUI.ValidationRules.AppRoleValidationRules
{
    public class CreateAppRoleValidator : AbstractValidator<CreateAppRoleDto>
    {
        public CreateAppRoleValidator()
        {
            RuleFor(x => x.AppRoleName).NotEmpty().WithMessage("Rol Adı Boş Geçilemez");
        }
    }
}

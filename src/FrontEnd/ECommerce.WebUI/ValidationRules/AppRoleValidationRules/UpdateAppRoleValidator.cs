using ECommerce.WebUI.Dtos.AppRoleDto;
using FluentValidation;

namespace ECommerce.WebUI.ValidationRules.AppRoleValidationRules
{
    public class UpdateAppRoleValidator : AbstractValidator<UpdateAppRoleDto>
    {
        public UpdateAppRoleValidator()
        {
            RuleFor(x => x.AppRoleName).NotEmpty().WithMessage("Rol Adı Boş Geçilemez");
        }
    }
}

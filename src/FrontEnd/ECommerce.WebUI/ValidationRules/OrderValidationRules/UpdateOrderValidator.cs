using ECommerce.WebUI.Dtos.OrderDto;
using FluentValidation;

namespace ECommerce.WebUI.ValidationRules.OrderValidationRules
{
    public class UpdateOrderValidator : AbstractValidator<UpdateOrderDto>
    {
        public UpdateOrderValidator()
        {
            
        }
    }
}

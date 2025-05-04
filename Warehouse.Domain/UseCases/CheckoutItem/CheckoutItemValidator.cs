using FluentValidation;
using Warehouse.Domain.Exceptions;

namespace Warehouse.Domain.UseCases.CheckoutItem;

internal class CheckoutItemValidator : AbstractValidator<CheckoutItemCommand>
{
    public CheckoutItemValidator()
    {
        RuleFor(c => c.WarehouseId)
            .NotEmpty().WithErrorCode(ValidationErrorCode.Empty);
        RuleFor(c => c.ItemId)
            .NotEmpty().WithErrorCode(ValidationErrorCode.Empty);
    }
}
using FluentValidation;
using Warehouse.Domain.Exceptions;

namespace Warehouse.Domain.UseCases.ConfirmPay;

internal class ConfirmPayCommandValidator : AbstractValidator<ConfirmPayItemCommand>
{
    public ConfirmPayCommandValidator()
    {
        RuleFor(c => c.WarehouseId)
            .NotEmpty().WithErrorCode(ValidationErrorCode.Empty);
        RuleFor(c => c.ItemId)
            .NotEmpty().WithErrorCode(ValidationErrorCode.Empty);
    }
}
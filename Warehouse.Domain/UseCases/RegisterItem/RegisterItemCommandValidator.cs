using FluentValidation;
using Warehouse.Domain.Exceptions;

namespace Warehouse.Domain.UseCases.RegisterItem;

internal class RegisterItemCommandValidator : AbstractValidator<RegisterItemCommand>
{
    public RegisterItemCommandValidator()
    {
        RuleFor(c => c.WarehouseId)
            .NotEmpty().WithErrorCode(ValidationErrorCode.Empty);
        RuleFor(c => c.Size)
            .GreaterThan(0).WithErrorCode(ValidationErrorCode.Invalid);
        RuleFor(t => t.Name)
            .Cascade(CascadeMode.Stop)
            .NotEmpty().WithErrorCode(ValidationErrorCode.Empty)
            .MaximumLength(100).WithErrorCode(ValidationErrorCode.TooLong);
    }
}

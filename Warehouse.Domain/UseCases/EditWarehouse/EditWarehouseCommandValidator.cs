using FluentValidation;
using Warehouse.Domain.Exceptions;

namespace Warehouse.Domain.UseCases.EditWarehouse;

internal class EditWarehouseCommandValidator : AbstractValidator<EditWarehouseCommand>
{
    public EditWarehouseCommandValidator()
    {
        RuleFor(c => c.WarehouseId)
            .NotEmpty().WithErrorCode(ValidationErrorCode.Empty);
        RuleFor(c => c.NewPrice)
            .Must(x => !x.HasValue || x.Value > 0)
            .WithErrorCode(ValidationErrorCode.Invalid);
        RuleFor(c => c.NewSize)
            .Must(x => !x.HasValue || x.Value > 0)
            .WithErrorCode(ValidationErrorCode.Invalid);
    }
}

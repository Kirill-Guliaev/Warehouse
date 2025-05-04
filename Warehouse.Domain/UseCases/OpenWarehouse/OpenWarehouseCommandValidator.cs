using FluentValidation;
using Warehouse.Domain.Exceptions;

namespace Warehouse.Domain.UseCases.OpenWarehouse;

internal class OpenWarehouseCommandValidator : AbstractValidator<OpenWarehouseCommand>
{
    public OpenWarehouseCommandValidator()
    {
        RuleFor(c => c.Price)
          .GreaterThan(0).WithErrorCode(ValidationErrorCode.Invalid);
        RuleFor(c => c.Size)
            .GreaterThan(0).WithErrorCode(ValidationErrorCode.Invalid);       
    }
}
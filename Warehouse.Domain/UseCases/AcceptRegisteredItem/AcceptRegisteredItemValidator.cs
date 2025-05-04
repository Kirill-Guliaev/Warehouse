using FluentValidation;
using Warehouse.Domain.Exceptions;

namespace Warehouse.Domain.UseCases.AcceptRegisteredItem;

internal class AcceptRegisteredItemValidator : AbstractValidator<AcceptRegisteredItemCommand>
{
    public AcceptRegisteredItemValidator()
    {
        RuleFor(c => c.Id)
            .NotEmpty().WithErrorCode(ValidationErrorCode.Empty);
    }
}
using FluentValidation;
using Warehouse.Domain.Exceptions;

namespace Warehouse.Domain.UseCases.UnpaidItems;

internal class UnpaidItemsCommandValidator : AbstractValidator<UnpaidItemsCommand>
{
    public UnpaidItemsCommandValidator()
    {
        RuleFor(c => c.UserId)
            .NotEmpty().WithErrorCode(ValidationErrorCode.Empty);

    }
}

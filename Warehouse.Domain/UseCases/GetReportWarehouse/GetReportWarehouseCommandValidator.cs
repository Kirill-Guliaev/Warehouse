using FluentValidation;
using Warehouse.Domain.Exceptions;
using Warehouse.Domain.UseCases.ConfirmPay;

namespace Warehouse.Domain.UseCases.GetReportWarehouse;

internal class GetReportWarehouseCommandValidator : AbstractValidator<GetReportWarehouseCommand>
{
    public GetReportWarehouseCommandValidator()
    {
        RuleFor(c => c.WarehouseId)
            .NotEmpty().WithErrorCode(ValidationErrorCode.Empty);
    }
}
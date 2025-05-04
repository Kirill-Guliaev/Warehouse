using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Warehouse.Api.Models.Requests;
using Warehouse.Api.Models.Responses;
using Warehouse.Domain.UseCases.AcceptRegisteredItem;
using Warehouse.Domain.UseCases.CheckoutItem;
using Warehouse.Domain.UseCases.ConfirmPay;
using Warehouse.Domain.UseCases.EditWarehouse;
using Warehouse.Domain.UseCases.GetReportWarehouse;
using Warehouse.Domain.UseCases.OpenWarehouse;

namespace Warehouse.Api.Controllers;

[ApiController]
[Route("[Controller]")]
public class WarehouseController : ControllerBase
{
    [HttpPost(nameof(OpenWarehouse))]
    [SwaggerOperation(
        Summary = "Открыть свой склад",
        Description = "Возвращает новый склад",
        OperationId = "OpenWarehouse",
        Tags = new[] { "Warehouse" })]
    public async Task<IActionResult> OpenWarehouse(
      [FromBody] OpenWarehouseRequest request,
      [FromServices] IOpenWarehouseUseCase useCase,
      CancellationToken cancellationToken)
    {
        var resultWarehouse = await useCase.ExecuteAsync(new OpenWarehouseCommand(request.Size, request.Price), cancellationToken);
        return Ok(resultWarehouse);
    }

    [HttpPost(nameof(AcceptRegisteredItem))]
    [SwaggerOperation(
      Summary = "Принять товар на склад",
      Description = "Может выполнять только сотрудник склада. Возвращает информацию о предмете",
      OperationId = "AcceptRegisteredItem",
      Tags = new[] { "Warehouse" })]
    public async Task<IActionResult> AcceptRegisteredItem(
    [FromBody] AcceptRegisteredItemRequest request,
    [FromServices] IAcceptRegisteredItemUseCase useCase,
    CancellationToken cancellationToken)
    {
        var resultItem = await useCase.ExecuteAsync(new AcceptRegisteredItemCommand(request.Id), cancellationToken);
        return Ok(resultItem);
    }

    [HttpPut(nameof(EditWarehouse))]
    [SwaggerOperation(
        Summary = "Редактирование данных склада",
        Description = "Может выполнять только владелец склада.",
        OperationId = "EditWarehouse",
        Tags = new[] { "Warehouse" })]
    public async Task<IActionResult> EditWarehouse(
    [FromBody] EditWarehouseRequest request,
    [FromServices] IEditWarehouseUseCase useCase,
    CancellationToken cancellationToken)
    {
        var resultWarehouse = await useCase.ExecuteAsync(new EditWarehouseCommand(request.WarehouseId, request.NewPrice, request.NewSize), cancellationToken);
        return Ok(resultWarehouse);
    }

    [HttpGet(nameof(GetReportWarehouse))]
    [SwaggerOperation(
        Summary = "Получить отчет о своем складе.",
        Description = "Может выполнять только владелец склада. Самый просто пример отчета. Сколько товаров оплачено, сколько не оплачено, сколько места занято на складе.",
        OperationId = "GetReportWarehouse",
        Tags = new[] { "Warehouse" })]
    public async Task<IActionResult> GetReportWarehouse(
    [FromServices] IGetReportWarehouseUseCase useCase,
    [FromQuery] WarehouseReportRequest request,
    CancellationToken cancellationToken)
    {
        (int paidItems, int unpaidItems, int reservedPlaces) = await useCase.ExecuteAsync(new GetReportWarehouseCommand(request.WarehouseId), cancellationToken);
        return Ok(new SimpleWarehouseReport(paidItems, unpaidItems, reservedPlaces));

    }

    [HttpPost(nameof(CheckoutItem))]
    [SwaggerOperation(
        Summary = "Выписать предмет со склада",
        Description = "Может выполнять только работник склада.",
        OperationId = "CheckoutIteme",
        Tags = new[] { "Warehouse" })]
    public async Task<IActionResult> CheckoutItem(
        [FromServices] ICheckoutItemUseCase useCase,
        [FromBody] CheckoutItemRequest request,
        CancellationToken cancellationToken)
    {
        var resItem = await useCase.ExecuteAsync(new CheckoutItemCommand(request.ItemId, request.WarehouseId), cancellationToken);
        return Ok(resItem);

    }

    [HttpPost(nameof(ConfirmPayItem))]
    [SwaggerOperation(
        Summary = "Отметить предмет как оплаченный",
        Description = "Может выполнять только работник склада.",
        OperationId = "ConfirmPayItem",
        Tags = new[] { "Warehouse" })]
    public async Task<IActionResult> ConfirmPayItem(
    [FromServices] IConfirmPayItemUseCase useCase,
    [FromBody] ConfrimPaidItemRequest request,
    CancellationToken cancellationToken)
    {
        var resItem = await useCase.ExecuteAsync(new ConfirmPayItemCommand(request.ItemId, request.WarehouseId), cancellationToken);
        return Ok(resItem);

    }
}
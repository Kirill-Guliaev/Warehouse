using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Warehouse.Api.Models.Requests;
using Warehouse.Domain.Models;
using Warehouse.Domain.UseCases.GetUserItems;
using Warehouse.Domain.UseCases.RegisterItem;
using Warehouse.Domain.UseCases.UnpaidItems;

namespace Warehouse.Api.Controllers;

[ApiController]
[Route("[Controller]")]
public class UserController : ControllerBase
{
    [HttpGet(Name = nameof(UserItems))]
    [ProducesResponseType(200, Type = typeof(ICollection<Item>))]
    [SwaggerOperation(
        Summary = "Получить список собственных предметов.",
        Description = "Возвращает нового пользователя",
        OperationId = "UserItems",
        Tags = new[] { "User" })]
    public async Task<IActionResult> UserItems(
      [FromServices] IUserItemsUseCase useCase,
      CancellationToken cancellationToken)
    {
        var resultItem = await useCase.ExecuteAsync(new UserItemsCommand(), cancellationToken);
        return Ok(resultItem);
    }


    [HttpPost(Name = nameof(RegisterItem))]
    [ProducesResponseType(200, Type = typeof(Item))]
    [SwaggerOperation(
        Summary = "Предварительная регистрация предмета на складе.",
        Description = "Возвращает информацию о зарегистрированном предмете",
        OperationId = "RegisterItem",
        Tags = new[] { "User" })]
    public async Task<IActionResult> RegisterItem(
        [FromBody] RegisterItemRequest request,
        [FromServices] IRegisterItemUseCase useCase,
      CancellationToken cancellationToken)
    {
        var resultItem = await useCase.ExecuteAsync(new RegisterItemCommand(request.Name, request.Size, request.WarehouseId), cancellationToken);
        return Ok(resultItem);
    }


    [HttpGet(nameof(UnpaidItems))]
    [SwaggerOperation(
       Summary = "Получить список предметов которые нужно оплатить.",
       Description = "",
       OperationId = "UnpaidItems",
       Tags = new[] { "User" })]
    public async Task<IActionResult> UnpaidItems(
       [FromServices] IUnpaidItemsUseCase useCase,
       [FromServices] IIdentityProvider identityProvider,
       CancellationToken cancellationToken)
    {
        var items = await useCase.ExecuteAsync(new UnpaidItemsCommand(identityProvider.Current.UserId), cancellationToken);
        return Ok(items);

    }
}

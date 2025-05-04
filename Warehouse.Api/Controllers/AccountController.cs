using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Warehouse.Api.Authentication;
using Warehouse.Api.Models.Requests;
using Warehouse.Domain.UseCases.SignIn;
using Warehouse.Domain.UseCases.SignOn;

namespace Warehouse.Api.Controllers;

[ApiController]
[Route("[Controller]")]
public class AccountController : ControllerBase
{
    [HttpPost(nameof(SignOn))]
    [SwaggerOperation(
        Summary = "Создание пользователя по логину",
        Description = "Возвращает нового пользователя",
        OperationId = "SignOn",
        Tags = new[] { "Account" })]
    public async Task<IActionResult> SignOn(
      [FromBody] SignOnRequest request,
      [FromServices] ISignOnUseCase useCase,
      CancellationToken cancellationToken)
    {
        var identity = await useCase.ExecuteAsync(new SignOnCommand(request.Login), cancellationToken);
        return Ok(identity);
    }

    [HttpPost(nameof(SignIn))]
    [SwaggerOperation(
        Summary = "Авторизация пользователя по логину.",
        Description = "Самая простая авторизация. В рамках конкурса вполне достаточно.",
        OperationId = "SignIn",
        Tags = new[] { "Account" })]
    public async Task<IActionResult> SignIn(
        [FromBody] SignInRequest request,
        [FromServices] ISignInUseCase useCase,
        [FromServices] IAuthTokenStorage tokenStorage,
        CancellationToken cancellationToken)
    {
        var identity = await useCase.ExecuteAsync(new SignInCommand(request.Login), cancellationToken);
        tokenStorage.StoreAuth(HttpContext, identity.UserId.ToString());
        return Ok(identity);

    }
}

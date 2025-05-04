using Microsoft.AspNetCore.Mvc;
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
    public async Task<IActionResult> SignOn(
      [FromBody] SignOnRequest request,
      [FromServices] ISignOnUseCase useCase,
      CancellationToken cancellationToken)
    {
        var identity = await useCase.ExecuteAsync(new SignOnCommand(request.Login), cancellationToken);
        return Ok(identity);
    }

    [HttpPost(nameof(SignIn))]
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

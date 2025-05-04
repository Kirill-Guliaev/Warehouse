using Microsoft.AspNetCore.Authentication;
using Warehouse.Api.Authentication;
using Warehouse.Domain.Models;

namespace Warehouse.Api.Middlewares;

public class AuthenticationMiddleware
{
    private readonly RequestDelegate next;

    public AuthenticationMiddleware(RequestDelegate next)
    {
        this.next = next;
    }

    public async Task InvokeAsync(
       HttpContext httpContext,
       IAuthTokenStorage tokenStorage,
       IAuthenticationService authenticationService,
       IIdentityProvider identityProvider)
    {
        identityProvider.Current = new User(Guid.Parse("b13f9c83-bed4-4abe-981b-33d7c38bd829"));
        //identityProvider.Current = tokenStorage.TryExtract(httpContext, out string token)
        //    ? new User(Guid.Parse(token))
        //    : User.Guest;
        await next(httpContext);
    }
}

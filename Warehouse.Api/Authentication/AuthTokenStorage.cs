using Microsoft.AspNetCore.Http;

namespace Warehouse.Api.Authentication;

public class AuthTokenStorage : IAuthTokenStorage
{
    private const string HeaderAuthKey = "Warehouse-Auth-Token";

    public void StoreAuth(HttpContext context, string token)
    {
        context.Response.Cookies.Append(HeaderAuthKey, token);
    }

    public bool TryExtract(HttpContext context, out string token)
    {
        if (context.Request.Cookies.TryGetValue(HeaderAuthKey, out var value) && !string.IsNullOrEmpty(value))
        {
            token = value;
            return true;
        }
        token = string.Empty;
        return false;
    }
}

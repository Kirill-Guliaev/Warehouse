namespace Warehouse.Api.Authentication;

public interface IAuthTokenStorage
{
    public void StoreAuth(HttpContext context, string token);

    public bool TryExtract(HttpContext context, out string token);
}

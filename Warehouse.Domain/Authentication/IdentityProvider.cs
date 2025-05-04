using System.Security.Principal;

internal class IdentityProvider : IIdentityProvider
{
    public IIdentity Current { get; set; }
}

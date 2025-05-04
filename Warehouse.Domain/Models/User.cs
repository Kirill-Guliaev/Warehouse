using Warehouse.Domain.Authentication;

namespace Warehouse.Domain.Models;

public class User : IIdentity
{
    public User(Guid userId)
    {
        UserId = userId;
    }

    public Guid UserId { get; set; }

    public static User Guest => new User(Guid.Empty);
}

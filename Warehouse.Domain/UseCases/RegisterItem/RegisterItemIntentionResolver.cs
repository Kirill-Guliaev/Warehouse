using Warehouse.Domain.Authentication;
using Warehouse.Domain.Authorization;

namespace Warehouse.Domain.UseCases.RegisterItem;

public class RegisterItemIntentionResolver : IIntentionResolver<ItemIntention>
{
    public bool IsAllowed(IIdentity subject, ItemIntention intention)
    {
        return intention switch
        {
            ItemIntention.Register => subject.UserId != Guid.Empty,
            ItemIntention.Get => subject.UserId != Guid.Empty,
            _ => false
        };
    }
}

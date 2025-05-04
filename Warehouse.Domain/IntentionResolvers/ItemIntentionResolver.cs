using Warehouse.Domain.Authentication;
using Warehouse.Domain.Authorization;
using Warehouse.Domain.Intentions;

namespace Warehouse.Domain.IntentionResolvers;

public class ItemIntentionResolver : IIntentionResolver<ItemIntention>
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

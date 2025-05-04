using Warehouse.Domain.Authentication;
using Warehouse.Domain.Authorization;
using Warehouse.Domain.Intentions;

namespace Warehouse.Domain.IntentionResolvers;

public class WarehouseIntentionResolver : IIntentionResolver<WarehouseIntention>
{
    public bool IsAllowed(IIdentity subject, WarehouseIntention intention)
    {
        return intention switch
        {
            WarehouseIntention.Open => subject.UserId != Guid.Empty,
            WarehouseIntention.Work => subject.UserId != Guid.Empty,//TODO не доделано. Нужно реализоватьс писок работников
            WarehouseIntention.Manage => subject.UserId != Guid.Empty,
            _ => false
        };
    }
}
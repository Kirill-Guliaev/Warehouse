using Warehouse.Domain.Authentication;

namespace Warehouse.Domain.Authorization;

public interface IIntentionResolver
{
}

public interface IIntentionResolver<TIntention> : IIntentionResolver
{
    bool IsAllowed(IIdentity subject, TIntention intention);
}
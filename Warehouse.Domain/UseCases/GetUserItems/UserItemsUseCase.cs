using FluentValidation;
using Warehouse.Domain.Authorization;
using Warehouse.Domain.Models;
using Warehouse.Domain.UseCases.RegisterItem;

namespace Warehouse.Domain.UseCases.GetUserItems;

public class UserItemsUseCase : IUserItemsUseCase
{
    private readonly IIntentionManager intentionManager;
    private readonly IUserItemsStorage userItemsStorage;
    private readonly IIdentityProvider identityProvider;

    public UserItemsUseCase(
        IIntentionManager intentionManager,
        IUserItemsStorage userItemsStorage,
        IIdentityProvider identityProvider)
    {
        this.intentionManager = intentionManager;
        this.userItemsStorage = userItemsStorage;
        this.identityProvider = identityProvider;
    }

    public async Task<IEnumerable<Item>> ExecuteAsync(UserItemsCommand command, CancellationToken cancellationToken)
    {
        intentionManager.ThrowIfForbidden(ItemIntention.Get);
        return await userItemsStorage.GetItemsAsync(identityProvider.Current.UserId, cancellationToken);
    }
}
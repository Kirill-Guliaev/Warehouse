using FluentValidation;
using System.Diagnostics;
using Warehouse.Domain.Authorization;
using Warehouse.Domain.Intentions;
using Warehouse.Domain.Models;

namespace Warehouse.Domain.UseCases.UnpaidItems;

public class UnpaidItemsUseCase : IUnpaidItemsUseCase
{
    private readonly IValidator<UnpaidItemsCommand> validator;
    private readonly IIntentionManager intentionManager;
    private readonly IUnpaidItemsStorage unpaidItemsStorage;

    public UnpaidItemsUseCase(
        IValidator<UnpaidItemsCommand> validator,
        IIntentionManager intentionManager,
        IUnpaidItemsStorage unpaidItemsStorage
        )
    {
        this.validator = validator;
        this.intentionManager = intentionManager;
        this.unpaidItemsStorage = unpaidItemsStorage;
    }

    public async Task<IEnumerable<UnpaidItem>> ExecuteAsync(UnpaidItemsCommand command, CancellationToken cancellationToken)
    {
        await validator.ValidateAndThrowAsync(command, cancellationToken);
        intentionManager.ThrowIfForbidden(ItemIntention.Get);
        var unpaidItems = await unpaidItemsStorage.GetUnpaidItems(command.UserId, cancellationToken);
        List<UnpaidItem> res = new();
        var groupedItems = unpaidItems.GroupBy(item => item.WarhouseId);
        foreach (var group in groupedItems)
        {
            int price = await unpaidItemsStorage.GetWarehousePriceAsync(group.Key);
            foreach (var item in group)
            {
                var hours =  item.CheckoutAt - item.ArrivedTime;
                if(!hours.HasValue)
                {
                    throw new Exception($"Can't count py for item {item.Id}");
                }
                res.Add(new UnpaidItem(item.Id, item.WarhouseId, item.Size * price * Convert.ToInt32(Math.Max(hours.Value.TotalHours, 1)))); 
            }
        }
        return res;
    }
}

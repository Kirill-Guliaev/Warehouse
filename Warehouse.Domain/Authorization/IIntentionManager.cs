namespace Warehouse.Domain.Authorization;

public interface IIntentionManager
{
    bool IsAllowed<TIntetion>(TIntetion intetion) where TIntetion : struct;
}
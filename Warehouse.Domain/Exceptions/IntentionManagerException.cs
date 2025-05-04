namespace Warehouse.Domain.Exceptions;

public class IntentionManagerException : Exception
{
    public IntentionManagerException() : base("Intention not allowed")
    {
    }
}

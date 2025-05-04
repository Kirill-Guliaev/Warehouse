using Microsoft.EntityFrameworkCore;
using Warehouse.Domain.Authentication;
using Warehouse.Domain.UseCases.SignIn;
using Warehouse.Storage.Mapper;

namespace Warehouse.Storage.Storages;

public class SignInStorage : ISignInStorage
{
    private readonly WarehouseDbContext dbContext;

    public SignInStorage(WarehouseDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<IIdentity?> FindUserAsync(string login, CancellationToken cancellationToken)
    {
        return (await dbContext.Persons.SingleOrDefaultAsync(u => u.Login == login, cancellationToken))?.ToUser();
    }
}

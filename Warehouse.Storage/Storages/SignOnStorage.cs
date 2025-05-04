using Microsoft.EntityFrameworkCore;
using Warehouse.Domain.Authentication;
using Warehouse.Domain.UseCases.SignOn;
using Warehouse.Storage.Mapper;

namespace Warehouse.Storage.Storages;

public class SignOnStorage : ISignOnStorage
{
    private readonly WarehouseDbContext dbContext;

    public SignOnStorage(WarehouseDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<Guid> CreateUserAsync(string login, CancellationToken cancellationToken)
    {
        var newPerson = await dbContext.Persons.AddAsync(new Entities.Person() { Login = login, PersonId = Guid.NewGuid() });
        await dbContext.SaveChangesAsync();
        return newPerson.Entity.PersonId;
    }

    public async Task<IIdentity?> FindUserAsync(string login, CancellationToken cancellationToken)
    {
        return (await dbContext.Persons.FirstOrDefaultAsync(u => u.Login == login, cancellationToken))?.ToUser();
    }
}

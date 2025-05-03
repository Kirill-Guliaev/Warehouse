using Warehouse.Domain.Models;
using Warehouse.Storage.Entities;

namespace Warehouse.Storage.Mapper;
internal static class MapperExtensions
{
    internal static User ToUser(this Person person)
    {
        return new User(person.PersonId, person.Login);
    }
}

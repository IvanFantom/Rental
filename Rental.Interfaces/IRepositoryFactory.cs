using Rental.Models.Entities;

namespace Rental.Interfaces
{
    public interface IRepositoryFactory
    {
        IRepository<Role, long> RoleRepository { get; }
        IRepository<User, long> UserRepository { get; }
        IRepository<Advert, long> AdvertRepository { get; }
        IRepository<Address, long> AddressRepository { get; }
    }
}

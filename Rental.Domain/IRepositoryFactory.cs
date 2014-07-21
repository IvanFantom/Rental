using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rental.Domain.Entities;
using Rental.Domain.Repositories;

namespace Rental.Domain
{
    public interface IRepositoryFactory
    {
        IRepository<Role, long> RoleRepository { get; }
        IRepository<User, long> UserRepository { get; }
        IRepository<Advert, long> AdvertRepository { get; }
        IRepository<Address, long> AddressRepository { get; }
    }
}

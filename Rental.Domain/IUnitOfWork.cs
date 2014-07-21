using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rental.Domain
{
    public interface IUnitOfWork : IRepositoryFactory, IDisposable
    {
        void Commit();
        void Rollback();
    }
}

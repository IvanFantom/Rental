using System;

namespace Rental.Interfaces
{
    public interface IUnitOfWork : IRepositoryFactory, IDisposable
    {
        void Commit();
        void Rollback();
    }
}

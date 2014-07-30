using System;
using Microsoft.AspNet.Identity;
using Rental.Models.Entities;

namespace Rental.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<TEntity> GetRepository<TEntity>() where TEntity : class;
        UserManager<User> UserManager { get; }
        void Commit();
        void Rollback();
    }
}

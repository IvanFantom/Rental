using System;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
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

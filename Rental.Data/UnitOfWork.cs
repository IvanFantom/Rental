using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rental.Interfaces;
using Rental.Models.Entities;
using Rental.Repositories;

namespace Rental.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;
        private IRepository<User, long> _userRepository;
        private IRepository<Role, long> _roleRepository;
        private IRepository<Advert, long> _advertRepository;
        private IRepository<Address, long> _addressRepository;
        private bool _isDisposed;

        public UnitOfWork()
        {
            _context = new DataContext();
            _isDisposed = false;
        }

        public IRepository<Role, long> RoleRepository
        {
            get { return _roleRepository ?? (_roleRepository = new Repository<Role, long>(_context)); }
        }
        public IRepository<User, long> UserRepository
        {
            get { return _userRepository ?? (_userRepository = new Repository<User, long>(_context)); }
        }
        public IRepository<Advert, long> AdvertRepository
        {
            get { return _advertRepository ?? (_advertRepository = new Repository<Advert, long>(_context)); }
        }
        public IRepository<Address, long> AddressRepository
        {
            get { return _addressRepository ?? (_addressRepository = new Repository<Address, long>(_context)); }
        }

        #region IUnitOfWork

        public void Commit()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
        }
        public void Rollback()
        {
            List<DbEntityEntry> changedEntries = _context.ChangeTracker.Entries().Where(x => x.State != EntityState.Unchanged).ToList();
            foreach (DbEntityEntry entry in changedEntries.Where(x => x.State == EntityState.Modified))
            {
                entry.CurrentValues.SetValues(entry.OriginalValues);
                entry.State = EntityState.Unchanged;
            }

            foreach (DbEntityEntry entry in changedEntries.Where(x => x.State == EntityState.Added))
            {
                entry.State = EntityState.Detached;
            }

            foreach (DbEntityEntry entry in changedEntries.Where(x => x.State == EntityState.Deleted))
            {
                entry.State = EntityState.Unchanged;
            }
        }

        #endregion

        #region IDisposable

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!this._isDisposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this._isDisposed = true;
        }
        ~UnitOfWork()
        {
            Dispose(false);
        }

        #endregion
    }
}

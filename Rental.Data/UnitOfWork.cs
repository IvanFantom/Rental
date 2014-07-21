using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rental.Data.Repositories;
using Rental.Domain;
using Rental.Domain.Entities;
using Rental.Domain.Repositories;

namespace Rental.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private DataContext _context;
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

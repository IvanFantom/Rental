using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rental.Data.Mappings;
using Rental.Models.Entities;

namespace Rental.Data
{
    public class DataContext : DbContext
    {
        public DataContext() : base("DataContextConnectionString")
        {
            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Advert> Adverts { get; set; }
        public DbSet<Address> Addresses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserMap());
            modelBuilder.Configurations.Add(new RoleMap());
            modelBuilder.Configurations.Add(new AdvertMap());
            modelBuilder.Configurations.Add(new AddressMap());
        }
    }
}

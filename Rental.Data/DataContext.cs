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
            modelBuilder.Configurations.Add<UserMap>(new EntityTypeConfiguration<UserMap>());
            modelBuilder.Configurations.Add<RoleMap>(new EntityTypeConfiguration<RoleMap>());
            modelBuilder.Configurations.Add<AdvertMap>(new EntityTypeConfiguration<AdvertMap>());
            modelBuilder.Configurations.Add<AddressMap>(new EntityTypeConfiguration<AddressMap>());
        }
    }
}

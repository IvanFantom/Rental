using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using Rental.Data.Mappings;
using Rental.Models.Entities;

namespace Rental.Data
{
    public class DataContext : IdentityDbContext<User>
    {
        public DataContext()
            : base("DataContextConnectionString")
        {
            Database.SetInitializer(new RentalDbInitializer());
            //Debug.Write(Database.Connection.ConnectionString);
            //Database.SetInitializer<DataContext>(new CreateDatabaseIfNotExists<DataContext>());
        }

        public DbSet<Advert> Adverts { get; set; }
        public DbSet<Address> Addresses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new UserMap());
            modelBuilder.Configurations.Add(new AdvertMap());
            modelBuilder.Configurations.Add(new AddressMap());
        }
    }
}

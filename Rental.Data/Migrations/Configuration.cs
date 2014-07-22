using System.Collections.Generic;
using Rental.Models.Entities;
using Rental.Models.Enums;

namespace Rental.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<Rental.Data.DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Rental.Data.DataContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            //var addresses = new List<Address>()
            //{
            //    new Address() { Country = "Country1", City = "City1", District = "District1", Street = "Street1" },
            //    new Address() { Country = "Country2", City = "City2", District = "District2", Street = "Street2" }
            //};
            //var adverts = new List<Advert>()
            //{
            //    new Advert(){ Header = "Header1", Content = "Content1", Footage = 1, Price = 1, IsReserved = false, Type = AdvertType.Rent },
            //    new Advert(){ Header = "Header2", Content = "Content2", Footage = 2, Price = 2, IsReserved = false, Type = AdvertType.Rent }
            //};
            //var users = new List<User>()
            //{
            //    new User(){Name = "Name1", Surname = "Surname1", Email = "1@gmail.com", Password = "1"},
            //    new User(){Name = "Name2", Surname = "Surname2", Email = "2@gmail.com", Password = "2"},
            //};
            //var roles = new List<Role>()
            //{
            //    new Role(){Name = "Admin"},
            //    new Role(){Name = "User"}
            //};

            //addresses[0].Advert = adverts[0];
            //adverts[0].Address = addresses[0];
            //addresses[1].Advert = adverts[1];
            //adverts[1].Address = addresses[1];

            //users[0].Adverts.Add(adverts[0]);
            //adverts[0].User = users[0];
            //users[1].Adverts.Add(adverts[1]);
            //adverts[1].User = users[1];

            //users[0].Roles = roles;
            //roles[0].Users.Add(users[0]);
            //roles[1].Users = users;
            //users[1].Roles.Add(roles[1]);

            //addresses.ForEach(a => context.Addresses.AddOrUpdate(x => x.Street, a));
            //adverts.ForEach(a => context.Adverts.AddOrUpdate(x => x.Header, a));
            //users.ForEach(u => context.Users.AddOrUpdate(x => x.Email, u));
            //roles.ForEach(r => context.Roles.AddOrUpdate(x => x.Name, r));

            //context.SaveChanges();
        }
    }
}

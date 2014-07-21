using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rental.Models.Entities;

namespace Rental.Data.Mappings
{
    public class AdvertMap : EntityTypeConfiguration<Advert>
    {
        public AdvertMap()
        {
            // Table & Column Mappings
            this.ToTable("Advert");
            this.Property(x => x.Id).HasColumnName("Id");

            // Primary Key
            this.HasKey(x => x.Id);

            // Properties
            this.Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(x => x.Header).HasMaxLength(64).IsRequired();
            this.Property(x => x.Content).HasMaxLength(null).IsRequired();
            this.Property(x => x.Footage).IsRequired();
            this.Property(x => x.IsReserved).IsRequired();

            // User one-to-many Advert
            this.HasRequired(a => a.User)
                .WithMany(u => u.Adverts);
        }
    }
}

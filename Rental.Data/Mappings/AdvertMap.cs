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
            ToTable("Advert");
            Property(x => x.Id).HasColumnName("Id");

            // Primary Key
            HasKey(x => x.Id);

            // Properties
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Header).HasMaxLength(64).IsOptional();
            Property(x => x.Content).HasMaxLength(null).IsOptional();
            Property(x => x.Footage).IsOptional();
            Property(x => x.IsReserved).IsOptional();

            // User one-to-many Advert
            HasRequired(a => a.User)
                .WithMany(u => u.Adverts)
                .HasForeignKey(a => a.UserId);
        }
    }
}

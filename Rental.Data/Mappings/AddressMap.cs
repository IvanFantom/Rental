using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Rental.Models.Entities;

namespace Rental.Data.Mappings
{
    public class AddressMap : EntityTypeConfiguration<Address>
    {
        public AddressMap()
        {
            // Table & Column Mappings
            ToTable("Address");
            Property(x => x.AdvertId).HasColumnName("AdvertId");

            // Primary Key
            HasKey(x => x.AdvertId);

            // Properties
            Property(x => x.AdvertId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.Country).HasMaxLength(64).IsRequired();
            Property(x => x.City).HasMaxLength(64).IsRequired();
            Property(x => x.District).HasMaxLength(128).IsRequired();
            Property(x => x.Street).HasMaxLength(128).IsRequired();

            // Advert one-to-one Address
            HasRequired(a => a.Advert)
                .WithRequiredDependent(a => a.Address)
                .WillCascadeOnDelete(true);
        }
    }
}

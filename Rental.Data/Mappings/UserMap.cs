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
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            // Table & Column Mappings
            ToTable("User");
            Property(x => x.Id).HasColumnName("Id");

            // Primary Key
            HasKey(x => x.Id);

            // Properties
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.LastName).HasMaxLength(64).IsOptional();
            Property(x => x.Email).HasMaxLength(128).IsOptional();
        }
    }
}

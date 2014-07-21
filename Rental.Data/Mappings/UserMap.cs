using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rental.Domain.Entities;

namespace Rental.Data.Mappings
{
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            // Table & Column Mappings
            this.ToTable("User");
            this.Property(x => x.Id).HasColumnName("Id");

            // Primary Key
            this.HasKey(x => x.Id);

            // Properties
            this.Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(x => x.Name).HasMaxLength(64).IsOptional();
            this.Property(x => x.Surname).HasMaxLength(64).IsOptional();
            this.Property(x => x.Email).HasMaxLength(128).IsRequired();
            this.Property(x => x.Password).HasMaxLength(128).IsRequired();

            // User many-to-many Role
            this.HasMany(u => u.Roles)
                .WithMany(r => r.Users)
                .Map(ur =>
                    {
                        ur.ToTable("UserRole");
                        ur.MapLeftKey("UserId");
                        ur.MapRightKey("RoleId");
                    });
        }
    }
}

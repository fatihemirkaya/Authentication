using Authentication.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Authentication.Persistence.Configs
{
    public class RoleConfiguration : BaseEntityConfiguration<Role>
    {
        public override void Configure(EntityTypeBuilder<Role> builder)
        {
            base.Configure(builder);
            builder.ToTable("Role");

            builder.Property(e => e.RoleName)
               .HasColumnName("RoleName")
               .HasColumnType("varchar(50)")
               .IsRequired();

            builder.Property(e => e.RoleDescription)
             .HasColumnName("RoleDescription")
             .HasColumnType("varchar(250)")
             .IsRequired();




        }

    }
}

using Authentication.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Authentication.Persistence.Configs
{
    public class RolePermissionConfiguration : BaseEntityConfiguration<RolePermission>
    {
        public override void Configure(EntityTypeBuilder<RolePermission> builder)
        {
            base.Configure(builder);
            builder.ToTable("RolePermission");

            builder.HasOne(bc => bc.Permission)
               .WithMany(b => b.RolePermission)
               .HasForeignKey(bc => bc.PermissionId).OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(bc => bc.Role)
              .WithMany(b => b.RolePermissions)
              .HasForeignKey(bc => bc.RoleId).OnDelete(DeleteBehavior.Restrict);

        }

    }
}

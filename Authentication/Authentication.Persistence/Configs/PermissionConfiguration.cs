using Authentication.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Authentication.Persistence.Configs
{
    public class PermissionConfiguration : BaseEntityConfiguration<Permission>
    {
        public override void Configure(EntityTypeBuilder<Permission> builder)
        {
            base.Configure(builder);
            builder.ToTable("Permission");

            builder.Property(e => e.PermissionName)
               .HasColumnName("PermissionName")
               .HasColumnType("varchar(50)")
               .IsRequired();

            builder.Property(e => e.PermissionDescription)
             .HasColumnName("PermissionDescription")
             .HasColumnType("varchar(250)")
             .IsRequired();

            builder.Property(e => e.ActionName)
           .HasColumnName("ActionName")
           .HasColumnType("varchar(20)")
           .IsRequired();


            builder.HasOne(bc => bc.Application)
               .WithMany(b => b.Permission)
               .HasForeignKey(bc => bc.ApplicationId).OnDelete(DeleteBehavior.Restrict);

        }

    }
}

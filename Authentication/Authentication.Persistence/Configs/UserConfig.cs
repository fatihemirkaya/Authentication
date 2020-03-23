using Authentication.Domain.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Text;

namespace Authentication.Persistence.Configs
{
    public class UserConfig : BaseEntityConfiguration<User>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            base.Configure(builder);
            builder.ToTable("User");

            builder.Property(e => e.UserName)
               .HasColumnName("UserName")
               .HasColumnType("varchar(50)")
               .IsRequired();

            builder.Property(e => e.Name)
             .HasColumnName("Name")
             .HasColumnType("varchar(50)")
             .IsRequired();

            builder.Property(e => e.SurName)
           .HasColumnName("SurName")
           .HasColumnType("varchar(50)")
           .IsRequired();

            builder.Property(e => e.Email)
          .HasColumnName("Email")
          .HasColumnType("varchar(50)")
          .IsRequired();


            builder.Property(e => e.Password)
          .HasColumnName("Password")
          .HasColumnType("nvarchar(400)")
          .IsRequired();

            builder.HasMany(bc => bc.UserApplications).WithOne(x => x.User).OnDelete(DeleteBehavior.Restrict);
        }
    }
}

using Authentication.Domain.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Text;

namespace Authentication.Persistence.Configs
{
    public class UserEntityConfig : BaseEntityConfiguration<User>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            base.Configure(builder);

            builder.Property(e => e.UserName).IsRequired(true).HasMaxLength(50);
            builder.Property(e => e.Name).IsRequired(true).HasMaxLength(50);
            builder.Property(e => e.SurName).IsRequired(true).HasMaxLength(50);
            builder.Property(e => e.Email).IsRequired(true).HasMaxLength(50);
        }
    }
}

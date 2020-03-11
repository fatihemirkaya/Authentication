using Authentication.Domain.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Text;

namespace Authentication.Persistence.Configs
{
    public class RoleGroupConfig : BaseEntityConfiguration<RoleGroup>
    {
        public override void Configure(EntityTypeBuilder<RoleGroup> builder)
        {
            base.Configure(builder);

            builder.HasOne(x => x.Group).WithMany(bc => bc.RoleGroups).HasForeignKey(b => b.GroupId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Role).WithMany(bc => bc.RoleGroup).HasForeignKey(b => b.RoleId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}

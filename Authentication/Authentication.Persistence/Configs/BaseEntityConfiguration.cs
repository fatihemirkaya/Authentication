using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Authentication.Persistence.Configs
{
    public abstract class BaseEntityConfiguration<Tentity> : IEntityTypeConfiguration<Tentity> where Tentity : class
    {
        public virtual void Configure(EntityTypeBuilder<Tentity> builder)
        {
            // TODO 
        }
    }
}

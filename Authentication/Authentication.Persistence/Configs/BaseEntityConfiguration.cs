using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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

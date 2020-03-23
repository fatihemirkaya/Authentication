using Authentication.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Authentication.Persistence.Configs
{
    public class UserTokenConfiguration : BaseEntityConfiguration<UserToken>
    {
        public override void Configure(EntityTypeBuilder<UserToken> builder)
        {
            base.Configure(builder);
            builder.ToTable("UserToken");
            builder.HasOne(bc => bc.User).WithOne(x => x.UserToken);


        }
    }
}

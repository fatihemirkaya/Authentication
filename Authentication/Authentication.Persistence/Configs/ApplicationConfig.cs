using Authentication.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Authentication.Persistence.Configs
{
    public class ApplicationConfiguration : BaseEntityConfiguration<Application>
    {
        public override void Configure(EntityTypeBuilder<Application> builder)
        {
            base.Configure(builder);
            builder.ToTable("Applications");

            builder.Property(e => e.ApplicationName)
               .HasColumnName("ApplicationName")
               .HasColumnType("nvarchar(50)")
               .IsRequired();

            builder.Property(e => e.Description)
               .HasColumnName("Description")
               .HasColumnType("nvarchar(250)")
               .IsRequired();

            builder.HasMany(bc => bc.UserApplications).WithOne(x => x.Application).OnDelete(DeleteBehavior.Restrict);


            builder.HasKey(x => x.Id).HasName("PrimaryKey_AppId");



        }

    }
}

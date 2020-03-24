using Authentication.Common.Entity;
using Authentication.Domain.Entity;
using Authentication.Domain.Manager;
using Authentication.Persistence.Configs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Authentication.Persistence.Context
{
    public class AuthenticationContext : DbContext
    {
        public AuthenticationContext(DbContextOptions<AuthenticationContext> options)
          : base(options)
        {
        }

        public override int SaveChanges()
        {
            var modifiedEntries = ChangeTracker.Entries()
                .Where(x => x.Entity is IAudit
                    && (x.State == EntityState.Added || x.State == EntityState.Modified));

            foreach (var entry in modifiedEntries)
            {
                IAudit entity = entry.Entity as IAudit;
                if (entity != null)
                {
                    var identityId = 1;
                    /*Thread.CurrentPrincipal.Identity.Name;*/
                    DateTime now = DateTime.UtcNow;

                    if (entry.State == EntityState.Added)
                    {
                        entity.CreatorUserId = identityId;
                        entity.CreationTime = now;
                    }
                    else
                    {
                        base.Entry(entity).Property(x => x.CreatorUserId).IsModified = false;
                        base.Entry(entity).Property(x => x.CreationTime).IsModified = false;
                    }

                    entity.ModifierUserId = identityId;
                    entity.LastModTime = now;
                }
            }

            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var modifiedEntries = ChangeTracker.Entries()
                .Where(x => x.Entity is IAudit
                    && (x.State == EntityState.Added || x.State == EntityState.Modified));

            foreach (var entry in modifiedEntries)
            {
                IAudit entity = entry.Entity as IAudit;
                if (entity != null)
                {
                    var identityId = UserManager.IsLoggin() ? UserManager.ActiveUserId : -1 ;
                    /*Thread.CurrentPrincipal.Identity.Name;*/
                    DateTime now = DateTime.UtcNow;

                    if (entry.State == EntityState.Added)
                    {
                        entity.CreatorUserId = identityId;
                        entity.CreationTime = now;
                    }
                    else
                    {
                        base.Entry(entity).Property(x => x.CreatorUserId).IsModified = false;
                        base.Entry(entity).Property(x => x.CreationTime).IsModified = false;
                    }

                    entity.ModifierUserId = identityId;
                    entity.LastModTime = now;
                }
            }

            return await base.SaveChangesAsync();
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserConfig).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PermissionConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(RoleConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(RoleGroupConfig).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(RolePermissionConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserTokenConfiguration).Assembly);
        }

        public DbSet<User> User { get; set; }
        public DbSet<Group> Group { get; set; }
        public DbSet<Menu> Menu { get; set; }
        public DbSet<Permission> Permission { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<RoleMenu> RoleMenu { get; set; }
        public DbSet<RoleGroup> RoleGroup { get; set; }
        public DbSet<RolePermission> RolePermission { get; set; }
        public DbSet<UserDetail> UserDetail { get; set; }
        public DbSet<UserRole> UserRole { get; set; }
        public DbSet<UserToken> UserToken { get; set; }
        public DbSet<Application> Application { get; set; }
        public DbSet<UserApplication> UserApplication { get; set; }
    }
}

using Authentication.Domain.Entity;
using Authentication.Persistence.Configs;
using Microsoft.EntityFrameworkCore;


namespace Authentication.Persistence.Context
{
    public class AuthenticationContext : DbContext
    {
        public AuthenticationContext(DbContextOptions<AuthenticationContext> options)
          : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserEntityConfig).Assembly);
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
    }
}

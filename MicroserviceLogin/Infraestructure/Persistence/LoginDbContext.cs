using Domain.Entities;
using Infraestructure.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Persistence
{
    public class LoginDbContext : DbContext
    {
        public LoginDbContext(DbContextOptions<LoginDbContext> options) : base(options) 
        {
     
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Rol> rols { get; set; }
        public DbSet<UserLog> UserLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new RolConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new UserLogConfiguration());
        }
    }
}


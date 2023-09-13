using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Persistence
{
    public class LoginDbContext : DbContext
    {
        public LoginDbContext(DbContextOptions<LoginDbContext> options) : base(options) 
        {
     
        }

        DbSet<User> Users { get; set; }
        DbSet<Rol> rols { get; set; }
        DbSet<UserLog> UserLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            
        }
    }
}


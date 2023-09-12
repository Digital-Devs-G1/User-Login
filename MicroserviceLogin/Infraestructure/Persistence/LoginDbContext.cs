using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Persistence
{
    public class LoginDbContext : DbContext
    {
        public LoginDbContext(DbContextOptions<LoginDbContext> options) : base(options) 
        {
     
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            
        }
    }
}

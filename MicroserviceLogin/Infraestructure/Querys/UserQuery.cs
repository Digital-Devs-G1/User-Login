using Application.Interfaces.Querys;
using Domain.Entities;
using Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Querys
{
    public class UserQuery : IUserQuery
    {
        private readonly LoginDbContext _context;

        public UserQuery(LoginDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return  _context.Users.Include(u => u.Rol).ToList();
        }

        public async Task<User> GetUserByEmail(string email)
        {
            return _context.Users
                .Include(u => u.Rol)
                .FirstOrDefault(x => x.Email == email);
        }
    }
}

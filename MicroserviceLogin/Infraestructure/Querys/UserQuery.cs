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


        public User GetUserByEmail(string email)
        {
            return _context.Users.FirstOrDefault(x => x.Email == email);
        }
    }
}

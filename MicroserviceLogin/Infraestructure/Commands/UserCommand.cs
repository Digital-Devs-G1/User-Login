using Application.Interfaces.Commands;
using Domain.Entities;
using Infraestructure.Persistence;

namespace Infraestructure.Commands
{
    public class UserCommand : IUserCommand
    {
        private readonly LoginDbContext _context;
        public UserCommand(LoginDbContext context)
        {
            _context = context;
        }
        public async Task<int>RegisterUser(User user)
        {
            _context.Add(user);

            return await _context.SaveChangesAsync();
        }
    }
}

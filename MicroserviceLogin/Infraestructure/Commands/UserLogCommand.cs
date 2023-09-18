using Application.Interfaces.Commands;
using Domain.Entities;
using Infraestructure.Persistence;

namespace Infraestructure.Commands
{
    public class UserLogCommand : IUserLogCommand
    {
        private readonly LoginDbContext _context;

        public UserLogCommand(LoginDbContext context)
        {
            _context = context;
        }

        public async Task InsertUserLog(UserLog userLog)
        {
            _context.UserLogs.Add(userLog);

            await _context.SaveChangesAsync();
        }
    }
}

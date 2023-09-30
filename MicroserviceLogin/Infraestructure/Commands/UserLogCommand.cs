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

        public async Task<int> InsertUserLog(UserLog userLog)
        {
            _context.UserLogs.Add(userLog);

            return await _context.SaveChangesAsync();
        }
    }
}

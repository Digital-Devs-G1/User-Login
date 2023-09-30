using Domain.Entities;

namespace Application.Interfaces.Commands
{
    public interface IUserLogCommand
    {
        Task<int> InsertUserLog(UserLog userLog);
    }
}

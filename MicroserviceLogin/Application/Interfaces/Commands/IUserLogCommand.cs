using Domain.Entities;

namespace Application.Interfaces.Commands
{
    public interface IUserLogCommand
    {
        Task InsertUserLog(UserLog userLog);
    }
}

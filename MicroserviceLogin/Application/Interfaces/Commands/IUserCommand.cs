using Domain.Entities;

namespace Application.Interfaces.Commands
{
    public interface IUserCommand
    {
        Task<int> RegisterUser(User user);
    }
}

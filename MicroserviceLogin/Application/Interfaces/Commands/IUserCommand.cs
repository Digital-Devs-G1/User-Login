using Domain.Entities;

namespace Application.Interfaces.Commands
{
    public interface IUserCommand
    {
        int RegisterUser(User user);
    }
}

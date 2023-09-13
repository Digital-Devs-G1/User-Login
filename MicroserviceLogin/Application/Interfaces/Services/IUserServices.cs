using Application.DTOs.Users;

namespace Application.Interfaces.Services
{
    public interface IUserServices
    {
        string RegisterUser(RegisterUser user);
    }
}

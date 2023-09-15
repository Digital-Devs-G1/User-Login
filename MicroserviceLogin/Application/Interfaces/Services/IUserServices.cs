using Application.DTOs.Token;
using Application.DTOs.Users;

namespace Application.Interfaces.Services
{
    public interface IUserServices
    {
        bool RegisterUser(RegisterUser user);
    }
}

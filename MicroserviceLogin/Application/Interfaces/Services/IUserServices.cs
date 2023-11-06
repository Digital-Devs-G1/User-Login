using Application.DTOs.Token;
using Application.DTOs.Users;

namespace Application.Interfaces.Services
{
    public interface IUserServices
    {
        Task RegisterUser(RegisterUser user);
        Task<TokenDto> Login(LoginUser user);
        Task<List<GetUser>> GetAllUsers();
    }
}

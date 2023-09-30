using Domain.Entities;

namespace Application.Interfaces.Querys
{
    public interface IUserQuery
    {
        Task<User> GetUserByEmail(string email);
        Task<IEnumerable<User>> GetAllUsers();
    }
}

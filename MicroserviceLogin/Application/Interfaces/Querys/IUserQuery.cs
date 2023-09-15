using Domain.Entities;

namespace Application.Interfaces.Querys
{
    public interface IUserQuery
    {
        User GetUserByEmail(string email);
    }
}

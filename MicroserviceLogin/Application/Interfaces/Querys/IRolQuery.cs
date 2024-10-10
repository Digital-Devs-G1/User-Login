using Domain.Entities;

namespace Application.Interfaces.Querys
{
    public interface IRolQuery
    {
        IEnumerable<Rol> GetAllRoles();
        bool ExistRol(int id);
    }
}

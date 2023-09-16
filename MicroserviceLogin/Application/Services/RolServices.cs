using Application.DTOs.Rol;
using Application.Interfaces.Querys;
using Application.Interfaces.Services;
using Domain.Entities;

namespace Application.Services
{
    public class RolServices : IRolServices
    {
        private readonly IRolQuery _rolQuery;

        public RolServices(IRolQuery rolQuery)
        {
            _rolQuery = rolQuery;
        }

        public List<GetRol> GetAllRoles()
        {
            IEnumerable<Rol> roles = _rolQuery.GetAllRoles();

            List<GetRol> list = roles.Select(r => new GetRol()
            {
                Id = r.Id,
                Description = r.Description
            }).ToList();

            return list;
        }

    }
}

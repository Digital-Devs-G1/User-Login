using Application.Interfaces.Querys;
using Domain.Entities;
using Infraestructure.Persistence;

namespace Infraestructure.Querys
{
    public class RolQuery : IRolQuery
    {
        private readonly LoginDbContext _context;

        public RolQuery(LoginDbContext context)
        {
            _context = context;
        }

        public bool ExistRol(int id)
        {
            return _context.rols.Any(r => r.Id == id);
        }

        public IEnumerable<Rol> GetAllRoles()
        {
            return _context.rols.Where(x => x.Description != "SuperAdmin").ToList();
        }
    }
}

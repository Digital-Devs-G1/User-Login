using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Querys
{
    public interface IRolQuery
    {
        IEnumerable<Rol> GetAllRoles();
        bool ExistRol(int id);
    }
}

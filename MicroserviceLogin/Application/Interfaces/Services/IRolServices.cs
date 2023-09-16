using Application.DTOs.Rol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Services
{
    public interface IRolServices
    {
        List<GetRol> GetAllRoles();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _EPAM_Forum.Entites;

namespace _EPAM_Forum.Intefases.BLL
{
    public interface IRoleBLL
    {
        IEnumerable<RoleDTO> GetAll();
        RoleDTO Get(int id);
        bool Create(RoleDTO role);
        bool Delete(int id);
        bool Update(RoleDTO role);
        int GetIdAnRoleName(string role_name);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _EPAM_Forum.Entites;

namespace _EPAM_Forum.Intefases.BLL
{
    public interface IUserRoleBLL
    {
        IEnumerable<UserRoleDTO> GetAll();
        UserRoleDTO Get(int id);
        bool Create(UserRoleDTO user_role);
        bool Delete(UserRoleDTO id);
        bool Update(UserRoleDTO user_role);
        bool IsWebUserInRole(string name, string role);
        string[] GetRolesForUser(string web_user_name);
    }
}


namespace _EPAM_Forum.Intefases.DAL
{
    using _EPAM_Forum.Entites;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IUserDAL
    {
        IEnumerable<UserDTO> GetAll();
        UserDTO Get(int id);
        bool Create(UserDTO user);
        bool Delete(int id);
        bool Update(UserDTO user);
        bool IsWebUser(string name, string password);
        int GetIdAnWebUserName(string web_user_name);
    }
}

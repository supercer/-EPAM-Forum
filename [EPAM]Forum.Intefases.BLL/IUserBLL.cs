
namespace _EPAM_Forum.Intefases.BLL
{
    using _EPAM_Forum.Entites;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IUserBLL
    {
        IEnumerable<UserDTO> GetAll();
        UserDTO Get(int id);
        bool Create(UserDTO user);
        bool Delete(int id);
        bool Update(UserDTO user);
        AvatarDTO GetAvatar(int id);
        int CreateAvatar(AvatarDTO user);
        bool SetAvatarToUser(int user_id, int avatar_id);
        bool IsWebUser(string name, string password);
        int GetIdAnWebUserName(string name);
    }
}

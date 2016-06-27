
namespace _EPAM_Forum.Interfases.DAL
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using _EPAM_Forum.Entites;

    public interface IUserMessageDAL
    {
        IEnumerable<UserMessageDTO> GetAll();
        UserMessageDTO Get(int id);
        bool Create(UserMessageDTO user_message);
        bool Delete(int id);
        bool Update(UserMessageDTO user_message);
        MessageDTO[] GetMessagesForUser(int user_id);
        int GetIdUserByIdMessage(int message_id);
    }
}

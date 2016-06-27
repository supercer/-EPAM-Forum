
namespace _EPAM_Forum.Intefases.BLL
{
    using _EPAM_Forum.Entites;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IUserMessageBLL
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


namespace _EPAM_Forum.Intefases.BLL
{
    using _EPAM_Forum.Entites;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface ITopicMessageBLL
    {
        IEnumerable<TopicMessageDTO> GetAll();
        TopicMessageDTO Get(int id);
        bool Create(TopicMessageDTO topic_message);
        bool Delete(int id);
        bool Update(TopicMessageDTO topic_message);
        MessageDTO[] GetMessagesForTopic(int topic_id);
    }
}

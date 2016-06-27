
namespace _EPAM_Forum.Interfases.DAL
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using _EPAM_Forum.Entites;

    public interface ITopicMessageDAL
    {
        IEnumerable<TopicMessageDTO> GetAll();
        TopicMessageDTO Get(int id);
        bool Create(TopicMessageDTO topic_message);
        bool Delete(int id);
        bool Update(TopicMessageDTO topic_message);
        MessageDTO[] GetMessagesForTopic(int topic_id);
    }
}

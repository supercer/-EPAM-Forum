
namespace _EPAM_Forum.Intefases.BLL
{
    using _EPAM_Forum.Entites;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IUserTopicBLL
    {
        IEnumerable<UserTopicDTO> GetAll();
        UserTopicDTO Get(int id);
        bool Create(UserTopicDTO user_topic);
        bool Delete(int id);
        bool Update(UserTopicDTO user_topic);
        int GetIdUserByIdTopic(int topic_id);
    }
}

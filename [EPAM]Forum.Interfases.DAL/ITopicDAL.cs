namespace _EPAM_Forum.Interfases.DAL
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using _EPAM_Forum.Entites;

    public interface ITopicDAL
    {
        IEnumerable<TopicDTO> GetAll();
        TopicDTO Get(int id);
        int Create(TopicDTO topic);
        bool Delete(int id);
        bool Update(TopicDTO topic);
    }
}

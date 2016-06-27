
namespace _EPAM_Forum.Intefases.BLL
{
    using _EPAM_Forum.Entites;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

   public interface ITopicBLL
    {
        IEnumerable<TopicDTO> GetAll();
        TopicDTO Get(int id);
        int Create(TopicDTO topic);
        bool Delete(int id);
        bool Update(TopicDTO topic);
    }
}

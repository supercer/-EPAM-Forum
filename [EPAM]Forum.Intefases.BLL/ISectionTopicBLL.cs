
namespace _EPAM_Forum.Intefases.BLL
{
    using _EPAM_Forum.Entites;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface ISectionTopicBLL
    {
        IEnumerable<SectionTopicDTO> GetAll();
        SectionTopicDTO Get(int id);
        bool Create(SectionTopicDTO section_topic);
        TopicDTO[] GetTopicsForSection(int section_topic_id);
        bool Delete(int id);
        bool Update(SectionTopicDTO section_topic);
        
    }
}

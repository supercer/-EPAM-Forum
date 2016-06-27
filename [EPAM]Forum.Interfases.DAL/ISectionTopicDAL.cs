
namespace _EPAM_Forum.Interfases.DAL
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using _EPAM_Forum.Entites;

    public interface ISectionTopicDAL
    {
        IEnumerable<SectionTopicDTO> GetAll();
        SectionTopicDTO Get(int id);
        bool Create(SectionTopicDTO section_topic);
        bool Delete(int id);
        bool Update(SectionTopicDTO section_topic);
        TopicDTO[] GetTopicsForSection(int section_id);
    }
}

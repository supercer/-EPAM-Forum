
namespace _EPAM_Forum.Entites
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class SectionTopicDTO
    {
        public int Id { get; set; }
        public int SectionId { get; set; }
        public int TopicId { get; set; }

        public SectionTopicDTO(int section_id, int topic_id)
        {
            this.SectionId = section_id;
            this.TopicId = topic_id;
        }

        public SectionTopicDTO(int id, int section_id, int topic_id)
        {
            this.Id = id;
            this.SectionId = section_id;
            this.TopicId = topic_id;
        }
    }
}

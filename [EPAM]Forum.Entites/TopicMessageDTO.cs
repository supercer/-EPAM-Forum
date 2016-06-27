
namespace _EPAM_Forum.Entites
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

   public class TopicMessageDTO
    {
        public int Id { get; set; }
        public int TopicId { get; set; }
        public int MessageId { get; set; }

        public TopicMessageDTO(int topic_id, int message_id)
        {
            this.TopicId = topic_id;
            this.MessageId = message_id;
        }

        public TopicMessageDTO(int id, int topic_id, int message_id)
        {
            this.Id = id;
            this.TopicId = topic_id;
            this.MessageId = message_id;
        }
    }
}

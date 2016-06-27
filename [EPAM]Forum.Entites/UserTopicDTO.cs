
namespace _EPAM_Forum.Entites
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class UserTopicDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int TopicId { get; set; }

        public UserTopicDTO(int user_id, int topic_id)
        {
            this.UserId = user_id;
            this.TopicId = topic_id;
        }

        public UserTopicDTO(int id, int user_id, int topic_id)
        {
            this.Id = id;
            this.UserId = user_id;
            this.TopicId = topic_id;
        }
    }
}


namespace _EPAM_Forum.Entites
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

   public class UserMessageDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int MessageId { get; set; }

        public UserMessageDTO(int user_id, int message_id)
        {
            this.UserId = user_id;
            this.MessageId = message_id;
        }

        public UserMessageDTO(int id, int user_id, int message_id)
        {
            this.Id = id;
            this.UserId = user_id;
            this.MessageId = message_id;
        }
    }
}

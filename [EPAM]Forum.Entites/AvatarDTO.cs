
namespace _EPAM_Forum.Entites
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class AvatarDTO
    {
        public byte[] Content { get; set; }

        public string ContentType { get; set; }

        public int Id { get; set; }

        public AvatarDTO()
        {

        }

        public AvatarDTO(int id, string content_type, byte[] content)
        {
            this.Id = id;
            this.ContentType = content_type;
            this.Content = content;
        }

        public AvatarDTO(string content_type, byte[] content)
        {
            this.ContentType = content_type;
            this.Content = content;
        }
    }
}

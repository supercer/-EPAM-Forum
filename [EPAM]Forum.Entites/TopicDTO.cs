
namespace _EPAM_Forum.Entites
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class TopicDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfCreation { get; set; }

        public TopicDTO(string name, DateTime date_of_creation)
        {
            this.Name = name;
            this.DateOfCreation = date_of_creation;
        }

        public TopicDTO(int id, string name, DateTime date_of_creation)
        {
            this.Id = id;
            this.Name = name;
            this.DateOfCreation = date_of_creation;
        }
    }
}

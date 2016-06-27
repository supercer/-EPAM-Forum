
namespace _EPAM_Forum.Entites
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class SectionDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public SectionDTO(string name)
        {
            this.Name = name;
        }

        public SectionDTO(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }
    }
}

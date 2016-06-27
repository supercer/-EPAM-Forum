
namespace _EPAM_Forum.Interfases.DAL
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using _EPAM_Forum.Entites;

    public interface ISectionDAL
    {
        IEnumerable<SectionDTO> GetAll();
        SectionDTO Get(int id);
        bool Create(SectionDTO section);
        bool Delete(int id);
        bool Update(SectionDTO section);
    }
}

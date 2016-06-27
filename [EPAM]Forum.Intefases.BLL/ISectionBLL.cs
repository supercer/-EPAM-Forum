
namespace _EPAM_Forum.Intefases.BLL
{
    using _EPAM_Forum.Entites;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface ISectionBLL
    {
        IEnumerable<SectionDTO> GetAll();
        SectionDTO Get(int id);
        bool Create(SectionDTO section);
        bool Delete(int id);
        bool Update(SectionDTO section);
    }
}

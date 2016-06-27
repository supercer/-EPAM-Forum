
namespace _EPAM_Forum.Interfases.DAL
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using _EPAM_Forum.Entites;

    public interface IMessageDAL
    {
        IEnumerable<MessageDTO> GetAll();
        MessageDTO Get(int id);
        int Create(MessageDTO message);
        bool Delete(int id);
        bool Update(MessageDTO message);
    }
}

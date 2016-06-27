
namespace _EPAM_Forum.Intefases.BLL
{
    using _EPAM_Forum.Entites;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IMessageBLL
    {
        IEnumerable<MessageDTO> GetAll();
        MessageDTO Get(int id);
        int Create(MessageDTO message);
        bool Delete(int id);
        bool Update(MessageDTO message);
    }
}

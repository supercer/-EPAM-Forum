
namespace _EPAM_Forum.Intefases.DAL
{
    using _EPAM_Forum.Entites;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IAvatarDAL
    {
        AvatarDTO Get(int id);
        int Create(AvatarDTO avatar);
    }
}

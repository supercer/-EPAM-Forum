
namespace _EPAM_Forum.Entites
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class UserRoleDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }

        public UserRoleDTO(int web_user_id, int role_id)
        {
            this.UserId = web_user_id;
            this.RoleId = role_id;
        }

        public UserRoleDTO(int id, int web_user_id, int role_id)
        {
            this.Id = id;
            this.UserId = web_user_id;
            this.RoleId = role_id;
        }
    }
}

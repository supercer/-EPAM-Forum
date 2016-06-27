using _EPAM_Forum.Intefases.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class Auth
    {
        public static bool CanLogin(string login, string password)
        {
            IUserBLL web_user_logic = new _EPAM_Forum.BLL.UserLogic();

            return web_user_logic.IsWebUser(login, password);
        }
    }
}
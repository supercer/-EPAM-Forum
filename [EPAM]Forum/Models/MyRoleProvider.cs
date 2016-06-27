using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using _EPAM_Forum.Intefases.BLL;

namespace Web.Models
{
    public class MyRoleProvider : RoleProvider
    {
        private IUserRoleBLL web_user_role_logic;
        public MyRoleProvider()
        {
            web_user_role_logic = new _EPAM_Forum.BLL.UserRoleLogic();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            return web_user_role_logic.IsWebUserInRole(username, roleName);

        }

        public override string[] GetRolesForUser(string username)
        {
            return web_user_role_logic.GetRolesForUser(username);
         
        }

        #region Note implemented
        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }



        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }



        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
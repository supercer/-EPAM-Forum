using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _EPAM_Forum.Entites;
using _EPAM_Forum.DALDATABASE;
using _EPAM_Forum.Intefases.BLL;
using _EPAM_Forum.Interfases.DAL;

namespace _EPAM_Forum.BLL
{
    public class UserRoleLogic : IUserRoleBLL
    {
        private _EPAM_Forum.Intefases.DAL.IUserRoleDAL dal_web_user_role;
        private _EPAM_Forum.Intefases.DAL.IRoleDAL dal_role;
        private _EPAM_Forum.Intefases.DAL.IUserDAL dal_web_user;

        public UserRoleLogic()
        {
            string mode;
            try
            {
                mode = ConfigurationManager.AppSettings["DataMode"];
            }

            catch (Exception e)
            {
                Logger.Logger.WriteLog(e);
                throw new Exception("Some problem with configuration file", e);
            }

            try
            {
                switch (mode)
                {
                    case "DATABASE":
                        {
                            dal_role = new RoleDAL();
                            dal_web_user = new UserDAL();
                            dal_web_user_role = new UserRoleDAL();
                        }

                        break;
                }
            }

            catch (Exception e)
            {
                Logger.Logger.WriteLog(e);
                throw e;
            }
        }

        public IEnumerable<UserRoleDTO> GetAll()
        {
            try
            {
                return dal_web_user_role.GetAll().ToArray();
            }

            catch (Exception e)
            {
                Logger.Logger.WriteLog(e);
                throw e;
            }
        }


        public bool Create(UserRoleDTO note)
        {
            try
            {
                return dal_web_user_role.Create(note);
            }

            catch (Exception e)
            {
                Logger.Logger.WriteLog(e);
                throw e;
            }
        }

        public bool Delete(UserRoleDTO note)
        {
            try
            {
                return dal_web_user_role.Delete(note);
            }

            catch (Exception e)
            {
                Logger.Logger.WriteLog(e);
                throw e;
            }
        }

        public bool Update(UserRoleDTO note)
        {
            try
            {
                dal_web_user_role.Update(note);
                return true;
            }

            catch (Exception e)
            {
                Logger.Logger.WriteLog(e);
                throw e;
            }
        }

        public UserRoleDTO Get(int id)
        {
            try
            {
                return dal_web_user_role.Get(id);
            }

            catch (Exception e)
            {
                Logger.Logger.WriteLog(e);
                throw e;
            }
        }

        public bool IsWebUserInRole(string name, string role)
        {
            try
            {
                return dal_web_user_role.IsWebUserInRole(name, role);
            }

            catch (Exception e)
            {
                Logger.Logger.WriteLog(e);
                throw e;
            }
        }

        public string[] GetRolesForUser(string web_user_name)
        {

            try
            {
                return dal_web_user_role.GetRolesForUser(web_user_name);
            }

            catch (Exception e)
            {
                Logger.Logger.WriteLog(e);
                throw e;
            }
        }
    }
}

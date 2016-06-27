
namespace _EPAM_Forum.BLL
{
    using _EPAM_Forum.Intefases.BLL;
    using _EPAM_Forum.Intefases.DAL;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using _EPAM_Forum.Entites;
    using System.Configuration;
    using System.IO;
    using _EPAM_Forum.DALDATABASE;

    public class UserLogic : IUserBLL
    {
        private _EPAM_Forum.Intefases.DAL.IUserDAL dal;
        private _EPAM_Forum.Intefases.DAL.IAvatarDAL dal_avatar;

        public UserLogic()
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
                            dal = new _EPAM_Forum.DALDATABASE.UserDAL();
                            dal_avatar = new _EPAM_Forum.DALDATABASE.AvatarDAL();
                        }

                        break;
                }
            }
            catch(Exception e)
            {
                Logger.Logger.WriteLog(e);
                throw e;
            }
            }

        public bool Create(UserDTO note)
        {
            try
            {
                return dal.Create(note);
            }

            catch (Exception e)
            {
                Logger.Logger.WriteLog(e);
                throw e;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                return dal.Delete(id);
            }

            catch (Exception e)
            {
                Logger.Logger.WriteLog(e);
                throw e;
            }
        }

        public UserDTO Get(int id)
        {
            try
            {
                return dal.Get(id);
            }

            catch (Exception e)
            {
                Logger.Logger.WriteLog(e);
                throw e;
            }
        }

        public AvatarDTO GetAvatar(int id)
        {
            try
            {
                return dal_avatar.Get(id);
            }

            catch (Exception e)
            {
                Logger.Logger.WriteLog(e);
                throw e;
            }
        }

        public int CreateAvatar(AvatarDTO note)
        {
            try
            {
                return dal_avatar.Create(note);
            }

            catch (Exception e)
            {
                Logger.Logger.WriteLog(e);
                throw e;
            }
        }

        public IEnumerable<UserDTO> GetAll()
        {
            return dal.GetAll().ToArray();
        }

        public bool Update(UserDTO user)
        {
            try
            {
                dal.Update(user);
                return true;
            }

            catch (Exception e)
            {
                Logger.Logger.WriteLog(e);
                throw e;
            }
        }

        public bool SetAvatarToUser(int user_id, int avatar_id)
        {
            UserDTO user;
            try
            {
                user = dal.Get(user_id);
                user.AvatarId = avatar_id;
                return dal.Update(user);
            }

            catch (Exception e)
            {
                Logger.Logger.WriteLog(e);
                throw e;
            }
        }


        public int GetIdAnWebUserName(string web_user_name)
        {
            try
            {
                return dal.GetIdAnWebUserName(web_user_name);
            }

            catch (Exception e)
            {
                Logger.Logger.WriteLog(e);
                throw e;
            }
        }

        public bool IsWebUser(string name, string password)
        {
            return dal.IsWebUser(name, password);
        }

    }
}

﻿namespace _EPAM_Forum.BLL
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

    public class TopicLogic: ITopicBLL
    {
        private _EPAM_Forum.Interfases.DAL.ITopicDAL dal;

        public TopicLogic()
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
                            dal = new _EPAM_Forum.DALDATABASE.TopicDAL();
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

        public int Create(TopicDTO note)
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

        public TopicDTO Get(int id)
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

        public IEnumerable<TopicDTO> GetAll()
        {
            return dal.GetAll().ToArray();
        }

        public bool Update(TopicDTO note)
        {
            try
            {
                dal.Update(note);
                return true;
            }

            catch (Exception e)
            {
                Logger.Logger.WriteLog(e);
                throw e;
            }
        }


    }
}

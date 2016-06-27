
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

    public class SectionTopicLogic : ISectionTopicBLL
    {
        private _EPAM_Forum.Interfases.DAL.ISectionTopicDAL dal;

        public SectionTopicLogic()
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
                            dal = new _EPAM_Forum.DALDATABASE.SectionTopicDAL();
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

        public bool Create(SectionTopicDTO note)
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

        public SectionTopicDTO Get(int id)
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

        public IEnumerable<SectionTopicDTO> GetAll()
        {
            return dal.GetAll().ToArray();
        }

        public TopicDTO[] GetTopicsForSection(int section_id)
        {
            try
            {
                return dal.GetTopicsForSection(section_id);
            }

            catch (Exception e)
            {
                Logger.Logger.WriteLog(e);
                throw e;
            }
        }

        public bool Update(SectionTopicDTO note)
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

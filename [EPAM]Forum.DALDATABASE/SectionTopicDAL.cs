
namespace _EPAM_Forum.DALDATABASE
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Data.SqlClient;
    using System.Configuration;
    using _EPAM_Forum.Entites;
    using _EPAM_Forum.Interfases.DAL;

    public class SectionTopicDAL : ISectionTopicDAL
    {
        private string connectionString;
        public SectionTopicDAL()
        {
            this.connectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;

        }

        public bool Create(SectionTopicDTO note)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var add_topic_section = connection.CreateCommand();
                add_topic_section.CommandText = $"INSERT INTO dbo.SectionTopic (SectionId, TopicId) VALUES (@SectionId, @TopicId)";
                add_topic_section.Parameters.AddWithValue("@SectionId", note.SectionId);
                add_topic_section.Parameters.AddWithValue("@TopicId", note.TopicId);
                connection.Open();
                var result = add_topic_section.ExecuteNonQuery();
                return result > 0;
            }
        }

        public bool Delete(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var delete_topic_section = connection.CreateCommand();
                delete_topic_section.CommandText = $"DELETE FROM dbo.SectionTopic WHERE Id = @Id";
                delete_topic_section.Parameters.AddWithValue("@Id", id);
                connection.Open();
                var result = delete_topic_section.ExecuteNonQuery();
                return result > 0;
            }
        }

        public SectionTopicDTO Get(int id)
        {
            int section_id;
            int topic_id;
            using (var connection = new SqlConnection(connectionString))
            {
                var get_topic_section = connection.CreateCommand();
                get_topic_section.CommandText = @"SELECT SectionId, TopicId FROM dbo.SectionTopic WHERE Id = @Id";
                get_topic_section.Parameters.AddWithValue("@Id", id);
                connection.Open();
                using (var reader = get_topic_section.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        section_id = (int)reader["SectionId"];
                        topic_id = (int)reader["TopicId"];
                        return new SectionTopicDTO(section_id, topic_id);
                    }

                }

                return null;
            }
        }

        public IEnumerable<SectionTopicDTO> GetAll()
        {
            int id;
            int section_id;
            int topic_id;
            List<SectionTopicDTO> sections = new List<SectionTopicDTO>();
            using (var connection = new SqlConnection(connectionString))
            {
                var get_all_section_topic = connection.CreateCommand();
                get_all_section_topic.CommandText = "SELECT Id, SectionId, TopicId FROM dbo.SectionTopic";
                connection.Open();
                using (var reader = get_all_section_topic.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        id = (int)reader["Id"];
                        section_id = (int)reader["SectionId"];
                        topic_id = (int)reader["TopicId"];
                        sections.Add(new SectionTopicDTO(id, section_id, topic_id));
                    }
                }
            }
            return sections;
        }

        public bool Update(SectionTopicDTO note)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var update_topic_section = connection.CreateCommand();
                update_topic_section.CommandText = $"UPDATE dbo.SectionTopic SET SectionId = @SectionId, TopicId = @TopicId WHERE Id = @Id";
                update_topic_section.Parameters.AddWithValue("@Id", note.Id);
                update_topic_section.Parameters.AddWithValue("@SectionId", note.SectionId);
                update_topic_section.Parameters.AddWithValue("@TopicId", note.TopicId);
                connection.Open();
                var result = update_topic_section.ExecuteNonQuery();
                return result > 0;
            }
        }


        public TopicDTO[] GetTopicsForSection(int section_id)
        {
            List<int> topics_id = new List<int>();
           
            using (var connection = new SqlConnection(connectionString))
            {
                var get_topic_id = connection.CreateCommand();
                get_topic_id.CommandText = @"SELECT TopicId FROM dbo.SectionTopic WHERE SectionId = @SectionId";
                get_topic_id.Parameters.AddWithValue("@SectionId", section_id);
                connection.Open();
                using (var reader = get_topic_id.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        topics_id.Add((int)reader["TopicId"]);
                    }
                }
            }

            int i = 0;
            int id;
            string name;
            DateTime date_of_creation;
            var topics = new TopicDTO[topics_id.Count];
            foreach (var topic_id in topics_id)
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    var get_topic = connection.CreateCommand();
                    get_topic.CommandText = @"SELECT Id, Name, DateOfCreation FROM dbo.Topic WHERE Id = @Id";
                    get_topic.Parameters.AddWithValue("@Id", topic_id);
                    connection.Open();
                    using (var reader = get_topic.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            id = (int)reader["Id"];
                            name = (string)reader["Name"];
                            date_of_creation = (DateTime)reader["DateOfCreation"];
                            topics[i] = new TopicDTO(id, name, date_of_creation);
                            i++;
                        }
                    }
                }
            }

            return topics;

        }
    }
}

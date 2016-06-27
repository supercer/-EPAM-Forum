
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

    public class TopicDAL: ITopicDAL
    {
        private string connectionString;
        public TopicDAL()
        {
            this.connectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;

        }

        public int Create(TopicDTO note)
        {
                int current_id;
                using (var connection = new SqlConnection(connectionString))
                {
                    var add_topic = connection.CreateCommand();
                    add_topic.CommandText = "Topic_Add";
                    add_topic.CommandType = System.Data.CommandType.StoredProcedure;
                    add_topic.Parameters.AddWithValue("@Name", note.Name);
                    add_topic.Parameters.AddWithValue("@DateOfCreation", note.DateOfCreation);
                    connection.Open();
                    current_id = (int)(decimal)add_topic.ExecuteScalar();
                    return current_id;
                }
            }

        public bool Delete(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var delete_role = connection.CreateCommand();
                delete_role.CommandText = $"DELETE FROM dbo.Topic WHERE Id = @Id";
                delete_role.Parameters.AddWithValue("@Id", id);
                connection.Open();
                var result = delete_role.ExecuteNonQuery();
                return result > 0;
            }
        }

        public TopicDTO Get(int id)
        {
            string text;
            DateTime date_of_creation;
            using (var connection = new SqlConnection(connectionString))
            {
                var get_topic = connection.CreateCommand();
                get_topic.CommandText = @"SELECT Name, DateOfCreation FROM dbo.Topic WHERE Id = @Id";
                get_topic.Parameters.AddWithValue("@Id", id);
                connection.Open();
                using (var reader = get_topic.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        text = (string)reader["Name"];
                        date_of_creation = (DateTime)reader["DateOfCreation"];
                        return new TopicDTO(id, text, date_of_creation);
                    }

                }

                return null;
            }
        }

        public IEnumerable<TopicDTO> GetAll()
        {
            int id;
            string text;
            DateTime date_of_creation;
            List<TopicDTO> topics = new List<TopicDTO>();
            using (var connection = new SqlConnection(connectionString))
            {
                var get_all_topics = connection.CreateCommand();
                get_all_topics.CommandText = "SELECT Id, Name, DateOfCreation FROM dbo.Topic";
                connection.Open();
                using (var reader = get_all_topics.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        id = (int)reader["Id"];
                        text = (string)reader["Name"];
                        date_of_creation = (DateTime)reader["DateOfCreation"];
                        topics.Add(new TopicDTO(id, text, date_of_creation));
                    }
                }
            }
            return topics;
        }

        public bool Update(TopicDTO note)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var update_topic = connection.CreateCommand();
                update_topic.CommandText = $"UPDATE dbo.Topic SET Name = @Name, DateOfCreation = @DateOfCreation WHERE Id = @Id";
                update_topic.Parameters.AddWithValue("@Id", note.Id);
                update_topic.Parameters.AddWithValue("@Name", note.Name);
                update_topic.Parameters.AddWithValue("@DateOfCreation", note.DateOfCreation);
                connection.Open();
                var result = update_topic.ExecuteNonQuery();
                return result > 0;
            }
        }
    }
}

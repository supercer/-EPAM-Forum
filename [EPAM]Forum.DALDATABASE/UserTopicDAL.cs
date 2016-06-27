
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

    public class UserTopicDAL : IUserTopicDAL
    {
        private string connectionString;
        public UserTopicDAL()
        {
            this.connectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;

        }

        public bool Create(UserTopicDTO note)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var add_user_topic = connection.CreateCommand();
                add_user_topic.CommandText = $"INSERT INTO dbo.UserTopic (UserId, TopicId) VALUES (@UserId, @TopicId)";
                add_user_topic.Parameters.AddWithValue("@UserId", note.UserId);
                add_user_topic.Parameters.AddWithValue("@TopicId", note.TopicId);
                connection.Open();
                var result = add_user_topic.ExecuteNonQuery();
                return result > 0;
            }
        }

        public bool Delete(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var delete_user_topic = connection.CreateCommand();
                delete_user_topic.CommandText = $"DELETE FROM dbo.UserTopic WHERE Id = @Id";
                delete_user_topic.Parameters.AddWithValue("@Id", id);
                connection.Open();
                var result = delete_user_topic.ExecuteNonQuery();
                return result > 0;
            }
        }

        public UserTopicDTO Get(int id)
        {
            int user_id;
            int topic_id;
            using (var connection = new SqlConnection(connectionString))
            {
                var get_user_topic = connection.CreateCommand();
                get_user_topic.CommandText = @"SELECT UserId, TopicId FROM dbo.UserTopic WHERE Id = @Id";
                get_user_topic.Parameters.AddWithValue("@Id", id);
                connection.Open();
                using (var reader = get_user_topic.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        user_id = (int)reader["UserId"];
                        topic_id = (int)reader["TopicId"];
                        return new UserTopicDTO(user_id, topic_id);
                    }

                }

                return null;
            }
        }

        public IEnumerable<UserTopicDTO> GetAll()
        {
            int id;
            int user_id;
            int topic_id;
            List<UserTopicDTO> users_topics = new List<UserTopicDTO>();
            using (var connection = new SqlConnection(connectionString))
            {
                var get_all_user_topic = connection.CreateCommand();
                get_all_user_topic.CommandText = "SELECT Id, SectionId, TopicId FROM dbo.UserTopic";
                connection.Open();
                using (var reader = get_all_user_topic.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        id = (int)reader["Id"];
                        user_id = (int)reader["SectionId"];
                        topic_id = (int)reader["TopicId"];
                        users_topics.Add(new UserTopicDTO(id, user_id, topic_id));
                    }
                }
            }
            return users_topics;
        }

        public bool Update(UserTopicDTO note)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var update_user_topic = connection.CreateCommand();
                update_user_topic.CommandText = $"UPDATE dbo.UserTopic SET UserId = @UserId, TopicId = @TopicId WHERE Id = @Id";
                update_user_topic.Parameters.AddWithValue("@Id", note.Id);
                update_user_topic.Parameters.AddWithValue("@SectionId", note.UserId);
                update_user_topic.Parameters.AddWithValue("@TopicId", note.TopicId);
                connection.Open();
                var result = update_user_topic.ExecuteNonQuery();
                return result > 0;
            }
        }
        public int GetIdUserByIdTopic(int topic_id)
        {

            int user_id = -1; ;

            using (var connection = new SqlConnection(connectionString))
            {
                var get_user_id = connection.CreateCommand();
                get_user_id.CommandText = @"SELECT UserId FROM dbo.UserTopic WHERE TopicId = TopicId";
                get_user_id.Parameters.AddWithValue("@TopicId", topic_id);
                connection.Open();
                using (var reader = get_user_id.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        user_id = (int)reader["UserId"];
                    }
                }
            }

            return user_id;
        }
    }
}


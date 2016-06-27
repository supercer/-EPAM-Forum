
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

    public class TopicMessageDAL : ITopicMessageDAL
    {
        private string connectionString;
        public TopicMessageDAL()
        {
            this.connectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;

        }

        public bool Create(TopicMessageDTO note)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var add_topic_message = connection.CreateCommand();
                add_topic_message.CommandText = $"INSERT INTO dbo.TopicMessage (MessageId, TopicId) VALUES (@MessageId, @TopicId)";
                add_topic_message.Parameters.AddWithValue("@MessageId", note.MessageId);
                add_topic_message.Parameters.AddWithValue("@TopicId", note.TopicId);
                connection.Open();
                var result = add_topic_message.ExecuteNonQuery();
                return result > 0;
            }
        }

        public bool Delete(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var delete_topic_message = connection.CreateCommand();
                delete_topic_message.CommandText = $"DELETE FROM dbo.TopicMessage WHERE Id = @Id";
                delete_topic_message.Parameters.AddWithValue("@Id", id);
                connection.Open();
                var result = delete_topic_message.ExecuteNonQuery();
                return result > 0;
            }
        }

        public TopicMessageDTO Get(int id)
        {
            int message_id;
            int topic_id;
            using (var connection = new SqlConnection(connectionString))
            {
                var get_topic_message = connection.CreateCommand();
                get_topic_message.CommandText = @"SELECT MessageId, TopicId FROM dbo.SectionTopic WHERE Id = @Id";
                get_topic_message.Parameters.AddWithValue("@Id", id);
                connection.Open();
                using (var reader = get_topic_message.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        message_id = (int)reader["MessageId"];
                        topic_id = (int)reader["TopicId"];
                        return new TopicMessageDTO(message_id, topic_id);
                    }

                }

                return null;
            }
        }

        public IEnumerable<TopicMessageDTO> GetAll()
        {
            int id;
            int message_id;
            int topic_id;
            List<TopicMessageDTO> sections = new List<TopicMessageDTO>();
            using (var connection = new SqlConnection(connectionString))
            {
                var get_all_topic_message = connection.CreateCommand();
                get_all_topic_message.CommandText = "SELECT Id, MessageId, TopicId FROM dbo.TopicMessage";
                connection.Open();
                using (var reader = get_all_topic_message.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        id = (int)reader["Id"];
                        message_id = (int)reader["MessageId"];
                        topic_id = (int)reader["TopicId"];
                        sections.Add(new TopicMessageDTO(id, message_id, topic_id));
                    }
                }
            }
            return sections;
        }

        public MessageDTO[] GetMessagesForTopic(int topic_id)
        {

            List<int> messages_id = new List<int>();

            using (var connection = new SqlConnection(connectionString))
            {
                var get_topic_id = connection.CreateCommand();
                get_topic_id.CommandText = @"SELECT MessageId FROM dbo.TopicMessage WHERE TopicId = @TopicId";
                get_topic_id.Parameters.AddWithValue("@TopicId", topic_id);
                connection.Open();
                using (var reader = get_topic_id.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        messages_id.Add((int)reader["MessageId"]);
                    }
                }
            }

            int i = 0;
            int id;
            string text;
            DateTime date_of_creation;
            var messages = new MessageDTO[messages_id.Count];
            foreach (var message_id in messages_id)
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    var get_message = connection.CreateCommand();
                    get_message.CommandText = @"SELECT Id, Text, DateOfCreation FROM dbo.Message WHERE Id = @Id";
                    get_message.Parameters.AddWithValue("@Id", message_id);
                    connection.Open();
                    using (var reader = get_message.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            id = (int)reader["Id"];
                            text = (string)reader["Text"];
                            date_of_creation = (DateTime)reader["DateOfCreation"];
                            messages[i] = new MessageDTO(id, text, date_of_creation);
                            i++;
                        }
                    }
                }
            }

            return messages;

        }

        public bool Update(TopicMessageDTO note)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var update_topic_message = connection.CreateCommand();
                update_topic_message.CommandText = $"UPDATE dbo.TopicMessage SET MessageId = @MessageId, TopicId = @TopicId WHERE Id = @Id";
                update_topic_message.Parameters.AddWithValue("@Id", note.Id);
                update_topic_message.Parameters.AddWithValue("@MessageId", note.MessageId);
                update_topic_message.Parameters.AddWithValue("@TopicId", note.TopicId);
                connection.Open();
                var result = update_topic_message.ExecuteNonQuery();
                return result > 0;
            }
        }

       
    }
}


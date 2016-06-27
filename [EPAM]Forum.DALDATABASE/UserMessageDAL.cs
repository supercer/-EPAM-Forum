
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

    public class UserMessageDAL : IUserMessageDAL
    {
        private string connectionString;
        public UserMessageDAL()
        {
            this.connectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;

        }

        public bool Create(UserMessageDTO note)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var add_user_message = connection.CreateCommand();
                add_user_message.CommandText = $"INSERT INTO dbo.UserMessage (UserId, MessageId) VALUES (@UserId, @MessageId)";
                add_user_message.Parameters.AddWithValue("@MessageId", note.MessageId);
                add_user_message.Parameters.AddWithValue("@UserId", note.UserId);
                connection.Open();
                var result = add_user_message.ExecuteNonQuery();
                return result > 0;
            }
        }

        public bool Delete(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var delete_user_message = connection.CreateCommand();
                delete_user_message.CommandText = $"DELETE FROM dbo.UserMessage WHERE Id = @Id";
                delete_user_message.Parameters.AddWithValue("@Id", id);
                connection.Open();
                var result = delete_user_message.ExecuteNonQuery();
                return result > 0;
            }
        }

        public UserMessageDTO Get(int id)
        {
            int user_id;
            int message_id;
            using (var connection = new SqlConnection(connectionString))
            {
                var get_user_message = connection.CreateCommand();
                get_user_message.CommandText = @"SELECT UserId, MessageId FROM dbo.UserMessage WHERE Id = @Id";
                get_user_message.Parameters.AddWithValue("@Id", id);
                connection.Open();
                using (var reader = get_user_message.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        user_id = (int)reader["UserId"];
                        message_id = (int)reader["MessageId"];
                        return new UserMessageDTO(user_id, message_id);
                    }

                }

                return null;
            }
        }

        public IEnumerable<UserMessageDTO> GetAll()
        {
            int id;
            int user_id;
            int message_id;
            List<UserMessageDTO> messages = new List<UserMessageDTO>();
            using (var connection = new SqlConnection(connectionString))
            {
                var get_all_section_topic = connection.CreateCommand();
                get_all_section_topic.CommandText = "SELECT Id, UserId, MessageId FROM dbo.UserMessage";
                connection.Open();
                using (var reader = get_all_section_topic.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        id = (int)reader["Id"];
                        user_id = (int)reader["UserId"];
                        message_id = (int)reader["MessageId"];
                        messages.Add(new UserMessageDTO(id, user_id, message_id));
                    }
                }
            }
            return messages;
        }

        public bool Update(UserMessageDTO note)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var update_user_message = connection.CreateCommand();
                update_user_message.CommandText = $"UPDATE dbo.UserMessage SET UserId = @UserId, MessageId = @MessageId WHERE Id = @Id";
                update_user_message.Parameters.AddWithValue("@Id", note.Id);
                update_user_message.Parameters.AddWithValue("@UserId", note.UserId);
                update_user_message.Parameters.AddWithValue("@MessageId", note.MessageId);
                connection.Open();
                var result = update_user_message.ExecuteNonQuery();
                return result > 0;
            }
        }

        public MessageDTO[] GetMessagesForUser(int user_id)
        {

            List<int> messages_id = new List<int>();

            using (var connection = new SqlConnection(connectionString))
            {
                var get_message_id = connection.CreateCommand();
                get_message_id.CommandText = @"SELECT MessageId FROM dbo.UserMessage WHERE UserId = @UserId";
                get_message_id.Parameters.AddWithValue("@UserId", user_id);
                connection.Open();
                using (var reader = get_message_id.ExecuteReader())
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
                    var get_topic = connection.CreateCommand();
                    get_topic.CommandText = @"SELECT Id, Text, DateOfCreation FROM dbo.Message WHERE Id = @Id";
                    get_topic.Parameters.AddWithValue("@Id", message_id);
                    connection.Open();
                    using (var reader = get_topic.ExecuteReader())
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

        public int GetIdUserByIdMessage(int message_id)
        {

            int user_id = -1; ;

            using (var connection = new SqlConnection(connectionString))
            {
                var get_user_id = connection.CreateCommand();
                get_user_id.CommandText = @"SELECT UserId FROM dbo.UserMessage WHERE MessageId = @MessageId";
                get_user_id.Parameters.AddWithValue("@MessageId", message_id);
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


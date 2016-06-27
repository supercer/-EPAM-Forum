
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

    public class MessageDAL: IMessageDAL
    {
        private string connectionString;
        public MessageDAL()
        {
            this.connectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;

        }

        public int Create(MessageDTO note)
        {
            int current_id;
            using (var connection = new SqlConnection(connectionString))
            {
                var add_message = connection.CreateCommand();
                add_message.CommandText = "Message_Add";
                add_message.CommandType = System.Data.CommandType.StoredProcedure;
                add_message.Parameters.AddWithValue("@Text", note.Text);
                add_message.Parameters.AddWithValue("@DateOfCreation", note.DateOfCreation);
                connection.Open();
                current_id = (int)(decimal)add_message.ExecuteScalar();
                return current_id;
            }
        }

        public bool Delete(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var delete_message = connection.CreateCommand();
                delete_message.CommandText = $"DELETE FROM dbo.Message WHERE Id = @Id";
                delete_message.Parameters.AddWithValue("@Id", id);
                connection.Open();
                var result = delete_message.ExecuteNonQuery();
                return result > 0;
            }
        }

        public MessageDTO Get(int id)
        {
            string text;
            DateTime date_of_creation;
            using (var connection = new SqlConnection(connectionString))
            {
                var get_message = connection.CreateCommand();
                get_message.CommandText = @"SELECT Text, DateOfCreation FROM dbo.Message WHERE Id = @Id";
                get_message.Parameters.AddWithValue("@Id", id);
                connection.Open();
                using (var reader = get_message.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        text = (string)reader["Text"];
                        date_of_creation = (DateTime)reader["DateOfCreation"];
                        return new MessageDTO(id, text, date_of_creation);
                    }

                }

                return null;
            }
        }

        public IEnumerable<MessageDTO> GetAll()
        {
            int id;
            string text;
            DateTime date_of_creation;
            List<MessageDTO> messages = new List<MessageDTO>();
            using (var connection = new SqlConnection(connectionString))
            {
                var get_messages = connection.CreateCommand();
                get_messages.CommandText = "SELECT Id, Text, DateOfCreation FROM dbo.Message";
                connection.Open();
                using (var reader = get_messages.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        id = (int)reader["Id"];
                        text = (string)reader["Text"];
                        date_of_creation = (DateTime)reader["DateOfCreation"];
                        messages.Add(new MessageDTO(id, text, date_of_creation));
                    }
                }
            }
            return messages;
        }

        public bool Update(MessageDTO note)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var update_message = connection.CreateCommand();
                update_message.CommandText = $"UPDATE dbo.Message SET Text = @Text, DateOfCreation = @DateOfCreation WHERE Id = @Id";
                update_message.Parameters.AddWithValue("@Id", note.Id);
                update_message.Parameters.AddWithValue("@Text", note.Text);
                update_message.Parameters.AddWithValue("@DateOfCreation", note.DateOfCreation);
                connection.Open();
                var result = update_message.ExecuteNonQuery();
                return result > 0;
            }
        }

    }
}


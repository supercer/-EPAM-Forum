namespace _EPAM_Forum.DALDATABASE
{
    using _EPAM_Forum.Intefases.DAL;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Data.SqlClient;
    using System.Configuration;
    using _EPAM_Forum.Entites;

    public class AvatarDAL : IAvatarDAL
    {
        private string connectionString;
        public AvatarDAL()
        {
            this.connectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;

        }

        public int Create(AvatarDTO note)
        {
            int current_id;
            using (var connection = new SqlConnection(connectionString))
            {
                var add_avatar = connection.CreateCommand();
                add_avatar.CommandText = "Avatar_Add";
                add_avatar.CommandType = System.Data.CommandType.StoredProcedure;
                add_avatar.Parameters.AddWithValue("@Content", note.Content);
                add_avatar.Parameters.AddWithValue("@ContentType", note.ContentType);
                connection.Open();      
                current_id = (int)(decimal)add_avatar.ExecuteScalar();
                return current_id;
            }
        }

        public AvatarDTO Get(int id)
        {
                byte[] content;
                string contentType;
                using (var connection = new SqlConnection(connectionString))
                {
                    var get_avatar = connection.CreateCommand();
                get_avatar.CommandText = @"SELECT [Content], ContentType FROM dbo.Avatar WHERE Id = @Id";
                get_avatar.Parameters.AddWithValue("@Id", id);
                    connection.Open();
                    using (var reader = get_avatar.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            content = (byte[])reader["Content"];
                            contentType = (string)reader["ContentType"];
                            return new AvatarDTO(id, contentType, content);
                        }

                    }

                    return null;
                }
            }
        }
    }


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _EPAM_Forum.Entites;
using System.Configuration;
using System.Data.SqlClient;
using _EPAM_Forum.Intefases.DAL;

namespace _EPAM_Forum.DALDATABASE
{
    public class RoleDAL : IRoleDAL
    {
        private string connectionString;
        public RoleDAL()
        {
            this.connectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;

        }

        public bool Create(RoleDTO note)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var add_roles = connection.CreateCommand();
                add_roles.CommandText = $"INSERT INTO dbo.Role (Name) VALUES (@Name)";
                add_roles.Parameters.AddWithValue("@Name", note.Name);
                connection.Open();
                var result = add_roles.ExecuteNonQuery();
                return result > 0;
            }
        }
        public bool Delete(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var delete_role = connection.CreateCommand();
                delete_role.CommandText = $"DELETE FROM dbo.Role WHERE Id = @Id";
                delete_role.Parameters.AddWithValue("@Id", id);
                connection.Open();
                var result = delete_role.ExecuteNonQuery();
                return result > 0;
            }
        }

        public RoleDTO Get(int id)
        {
            string name;
            using (var connection = new SqlConnection(connectionString))
            {
                var get_role = connection.CreateCommand();
                get_role.CommandText = @"SELECT Name FROM dbo.Role WHERE Id = @Id";
                get_role.Parameters.AddWithValue("@Id", id);
                connection.Open();
                using (var reader = get_role.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        name = (string)reader["Name"];
                        return new RoleDTO(id, name);
                    }

                }

                return null;
            }
        }

        public IEnumerable<RoleDTO> GetAll()
        {
            int id;
            string name;
            List<RoleDTO> roles = new List<RoleDTO>();
            using (var connection = new SqlConnection(connectionString))
            {
                var get_all_roles = connection.CreateCommand();
                get_all_roles.CommandText = "SELECT Id, Name FROM dbo.Role";
                connection.Open();
                using (var reader = get_all_roles.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        id = (int)reader["Id"];
                        name = (string)reader["Name"];
                        roles.Add(new RoleDTO(id, name));
                    }
                }
            }
            return roles;
        }

        public bool Update(RoleDTO note)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var update_role = connection.CreateCommand();
                update_role.CommandText = $"UPDATE dbo.Role SET Id = @Id , Name = @Name WHERE Id = @Id";
                update_role.Parameters.AddWithValue("@Id", note.Id);
                update_role.Parameters.AddWithValue("@Name", note.Name);
                connection.Open();
                var result = update_role.ExecuteNonQuery();
                return result > 0;
            }
        }

        public int GetIdAnRoleName(string role_name)
        {
            int web_role_id = -1;
            using (var connection = new SqlConnection(connectionString))
            {
                var get_role_id = connection.CreateCommand();
                get_role_id.CommandText = @"SELECT Id FROM dbo.Role WHERE Name = @Name";
                get_role_id.Parameters.AddWithValue("@Name", role_name);
                connection.Open();
                using (var reader = get_role_id.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        web_role_id = (int)reader["Id"];
                    }
                }
            }
            return web_role_id;
        }
    }
}



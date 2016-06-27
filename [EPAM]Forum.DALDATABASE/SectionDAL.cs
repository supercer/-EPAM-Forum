
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

    public class SectionDAL : ISectionDAL
    {
        private string connectionString;
        public SectionDAL()
        {
            this.connectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;

        }

        public bool Create(SectionDTO note)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var add_section = connection.CreateCommand();
                add_section.CommandText = $"INSERT INTO dbo.Section (Name) VALUES (@Name)";
                add_section.Parameters.AddWithValue("@Name", note.Name);
                connection.Open();
                var result = add_section.ExecuteNonQuery();
                return result > 0;
            }
        }

        public bool Delete(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var delete_section = connection.CreateCommand();
                delete_section.CommandText = $"DELETE FROM dbo.Section WHERE Id = @Id";
                delete_section.Parameters.AddWithValue("@Id", id);
                connection.Open();
                var result = delete_section.ExecuteNonQuery();
                return result > 0;
            }
        }

        public SectionDTO Get(int id)
        {
            string name;
            using (var connection = new SqlConnection(connectionString))
            {
                var get_section = connection.CreateCommand();
                get_section.CommandText = @"SELECT Name FROM dbo.Section WHERE Id = @Id";
                get_section.Parameters.AddWithValue("@Id", id);
                connection.Open();
                using (var reader = get_section.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        name = (string)reader["Name"];
                        return new SectionDTO(name);
                    }

                }

                return null;
            }
        }

        public IEnumerable<SectionDTO> GetAll()
        {
            int id;
            string name;
            List<SectionDTO> sections = new List<SectionDTO>();
            using (var connection = new SqlConnection(connectionString))
            {
                var get_all_sections = connection.CreateCommand();
                get_all_sections.CommandText = "SELECT Id, Name FROM dbo.Section";
                connection.Open();
                using (var reader = get_all_sections.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        id = (int)reader["Id"];
                        name = (string)reader["Name"];
                        sections.Add(new SectionDTO(id, name));
                    }
                }
            }
            return sections;
        }

        public bool Update(SectionDTO note)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var update_section = connection.CreateCommand();
                update_section.CommandText = $"UPDATE dbo.Section SET Name = @Name, WHERE Id = @Id";
                update_section.Parameters.AddWithValue("@Id", note.Id);
                update_section.Parameters.AddWithValue("@Name", note.Name);
                connection.Open();
                var result = update_section.ExecuteNonQuery();
                return result > 0;
            }
        }

    }
}


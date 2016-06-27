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
    public class UserDAL : IUserDAL
    {
        private string connectionString;
        public UserDAL()
        {
            this.connectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;

        }

        public bool Create(UserDTO user)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var add_user = connection.CreateCommand();
                if (user.AvatarId == null)
                {            
                    add_user.CommandText = $"INSERT INTO dbo.[User] (Login, PasswordHashCode, Name, Gender, DateOfBirth, RegistrationDate ) VALUES (@Login, @PasswordHashCode, @Name, @Gender, @DateOfBirth, @RegistrationDate)";
                    add_user.Parameters.AddWithValue("@Login", user.Login);
                    add_user.Parameters.AddWithValue("@PasswordHashCode", user.PasswordHashCode);
                    add_user.Parameters.AddWithValue("@Name", user.Name);
                    add_user.Parameters.AddWithValue("@Gender", user.Gender);
                    add_user.Parameters.AddWithValue("@DateOfBirth", user.DateOfBirth);
                    add_user.Parameters.AddWithValue("@RegistrationDate", user.RegistrationDate);
                }

                else
                {
                    add_user.CommandText = $"INSERT INTO dbo.[User] (Login, PasswordHashCode, Name, Gender, DateOfBirth, RegistrationDate, AvatarId ) VALUES (@Login, @PasswordHashCode, @Name, @Gender, @DateOfBirth, @RegistrationDate, @AvatarId)";
                    add_user.Parameters.AddWithValue("@Login", user.Login);
                    add_user.Parameters.AddWithValue("@PasswordHashCode", user.PasswordHashCode);
                    add_user.Parameters.AddWithValue("@Name", user.Name);
                    add_user.Parameters.AddWithValue("@Gender", user.Gender);
                    add_user.Parameters.AddWithValue("@DateOfBirth", user.DateOfBirth);
                    add_user.Parameters.AddWithValue("@RegistrationDate", user.RegistrationDate);
                    add_user.Parameters.AddWithValue("@AvatarId", user.AvatarId);
                }
       
                connection.Open();
                var result = add_user.ExecuteNonQuery();
                return result > 0;
            }
        }
        public bool Delete(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var delete_user = connection.CreateCommand();
                delete_user.CommandText = $"DELETE FROM dbo.[User] WHERE Id = @Id";
                delete_user.Parameters.AddWithValue("@Id", id);
                connection.Open();
                var result = delete_user.ExecuteNonQuery();
                return result > 0;
            }
        }

        public UserDTO Get(int id)
        {
            int? avatar_id;
            string login;
            int password_hash_code;
            DateTime registration_date;
            string name;
            string gender;
            DateTime date_of_birth;

            using (var connection = new SqlConnection(connectionString))
            {
                var get_user = connection.CreateCommand();
                get_user.CommandText = $@"SELECT Login, PasswordHashCode, Name, Gender, DateOfBirth, RegistrationDate, AvatarId  FROM dbo.[User] WHERE Id = @Id";
                get_user.Parameters.AddWithValue("@Id", id);
                connection.Open();
                using (var reader = get_user.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        login = (string)reader["Login"];
                        password_hash_code = (int)reader["PasswordHashCode"];
                        registration_date = (DateTime)reader["RegistrationDate"];
                        name = (string)reader["Name"];
                        gender = (string)reader["Gender"];
                        date_of_birth = (DateTime)reader["DateOfBirth"];
                        avatar_id = reader["AvatarId"] as int?;
                        if (avatar_id == null)
                        {
                            return new UserDTO(id, login, password_hash_code, registration_date,
                        name, gender, date_of_birth);
                        }

                        else
                        {
                            return new UserDTO(id, login, password_hash_code, registration_date,
                        name, gender, date_of_birth, avatar_id);
                        }
                    }
                }

                return null;
            }
        }

        public IEnumerable<UserDTO> GetAll()
        {
            int id;
            int? avatar_id;
            string login;
            int password_hash_code;
            DateTime registration_date;
            string name;
            string gender;
            DateTime date_of_birth;

            List<UserDTO> users = new List<UserDTO>();
            using (var connection = new SqlConnection(connectionString))
            {
                var get_all_users = connection.CreateCommand();
                get_all_users.CommandText = "SELECT Id, Login, PasswordHashCode, Name, Gender, DateOfBirth, RegistrationDate, AvatarId FROM dbo.[User]";
                connection.Open();
                using (var reader = get_all_users.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        id = (int)reader["Id"];
                        login = (string)reader["Login"];
                        password_hash_code = (int)reader["PasswordHashCode"];
                        registration_date = (DateTime)reader["RegistrationDate"];
                        name = (string)reader["Name"];
                        gender = (string)reader["Gender"];
                        date_of_birth = (DateTime)reader["DateOfBirth"];
                        avatar_id = reader["AvatarId"] as int?;
                        if (avatar_id == null)
                        {
                            users.Add(new UserDTO(id, login, password_hash_code, registration_date,
                        name, gender, date_of_birth));
                        }

                        else
                        {
                            users.Add(new UserDTO(id, login, password_hash_code, registration_date,
                        name, gender, date_of_birth, avatar_id));
                        }
                       
                    }
                }
            }
            return users;
        }

        public bool Update(UserDTO user)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var update_user = connection.CreateCommand();
                if (user.AvatarId == null)
                {
                    update_user.CommandText = $"UPDATE dbo.[User] SET Login = @Login, PasswordHashCode = @PasswordHashCode , Name = @Name, Gender = @Gender, DateOfBirth = @DateOfBirth, RegistrationDate = @RegistrationDate WHERE Id = @UId";
                    update_user.Parameters.AddWithValue("@Id", user.Id);
                    update_user.Parameters.AddWithValue("@Login", user.Login);
                    update_user.Parameters.AddWithValue("@PasswordHashCode", user.PasswordHashCode);
                    update_user.Parameters.AddWithValue("@Name", user.Name);
                    update_user.Parameters.AddWithValue("@Gender", user.Gender);
                    update_user.Parameters.AddWithValue("@DateOfBirth", user.DateOfBirth);
                    update_user.Parameters.AddWithValue("@RegistrationDate", user.RegistrationDate);
                }

                else
                {
                    update_user.CommandText = $"UPDATE dbo.[User] SET Login = @Login, PasswordHashCode = @PasswordHashCode , Name = @Name, Gender = @Gender, DateOfBirth = @DateOfBirth, RegistrationDate = @RegistrationDate, AvatarId = @AvatarId WHERE Id = @Id";
                    update_user.Parameters.AddWithValue("@Id", user.Id);
                    update_user.Parameters.AddWithValue("@Login", user.Login);
                    update_user.Parameters.AddWithValue("@PasswordHashCode", user.PasswordHashCode);
                    update_user.Parameters.AddWithValue("@Name", user.Name);
                    update_user.Parameters.AddWithValue("@Gender", user.Gender);
                    update_user.Parameters.AddWithValue("@DateOfBirth", user.DateOfBirth);
                    update_user.Parameters.AddWithValue("@RegistrationDate", user.RegistrationDate);
                    update_user.Parameters.AddWithValue("@AvatarId", user.AvatarId);
                }

                connection.Open();
                var result = update_user.ExecuteNonQuery();
                return result > 0;
            }
        }

        public bool IsWebUser(string name, string password)
        {
            int password_hash_code = password.GetHashCode();
            using (var connection = new SqlConnection(connectionString))
            {
                var get_web_user = connection.CreateCommand();
                get_web_user.CommandText = @"SELECT Login, PasswordHashCode FROM dbo.[User] WHERE Login = @Login AND PasswordHashCode = @PasswordHashCode";
                get_web_user.Parameters.AddWithValue("@Login", name);
                get_web_user.Parameters.AddWithValue("@PasswordHashCode", password_hash_code);
                connection.Open();
                using (var reader = get_web_user.ExecuteReader())
                {
                    return reader.HasRows;
                }
            }
        }

        public int GetIdAnWebUserName(string login)
        {
            int web_user_id = -1;
            using (var connection = new SqlConnection(connectionString))
            {
                var get_web_user_id = connection.CreateCommand();
                get_web_user_id.CommandText = @"SELECT Id FROM dbo.[User] WHERE Login = @Login";
                get_web_user_id.Parameters.AddWithValue("@Login", login);
                connection.Open();
                using (var reader = get_web_user_id.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        web_user_id = (int)reader["Id"];
                    }
                }
            }
            return web_user_id;
        }
    }
}

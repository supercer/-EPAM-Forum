
namespace _EPAM_Forum.Entites
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class UserDTO
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public int PasswordHashCode { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int? AvatarId { get; set; }
    
        public int Age
        {
            get { return TempAge(); }
        }

        public UserDTO(string login, int password_hash_code, DateTime registration_date,
                          string name, string gender, DateTime date_of_birth)
        {
            this.Login = login;
            this.PasswordHashCode = password_hash_code;
            this.RegistrationDate = registration_date;
            this.Name = name;
            this.Gender = gender;
            this.DateOfBirth = date_of_birth;
        }

        public UserDTO(string login, int password_hash_code, DateTime registration_date,
                          string name, string gender, DateTime date_of_birth, int? avatar_id)
        {
            this.Login = login;
            this.PasswordHashCode = password_hash_code;
            this.RegistrationDate = registration_date;
            this.Name = name;
            this.Gender = gender;
            this.DateOfBirth = date_of_birth;
            this.AvatarId = avatar_id;
        }

        public UserDTO(int id, string login, int password_hash_code, DateTime registration_date,
                          string name, string gender, DateTime date_of_birth)
        {
            this.Id = id;
            this.Login = login;
            this.PasswordHashCode = password_hash_code;
            this.RegistrationDate = registration_date;
            this.Name = name;
            this.Gender = gender;
            this.DateOfBirth = date_of_birth;
        }

        public UserDTO(int id, string login, int password_hash_code, DateTime registration_date,
                        string name, string gender, DateTime date_of_birth, int? avatar_id)
        {
            this.Id = id;
            this.Login = login;
            this.PasswordHashCode = password_hash_code;
            this.RegistrationDate = registration_date;
            this.Name = name;
            this.Gender = gender;
            this.DateOfBirth = date_of_birth;
            this.AvatarId = avatar_id;
        }

        public UserDTO()
        {

        }

       private int TempAge()
        {
            DateTime now = DateTime.Today;
            int temp_age = now.Year - this.DateOfBirth.Year;
            if ((temp_age >= 1) && ((now.Month < this.DateOfBirth.Month)
                 || ((now.Month == this.DateOfBirth.Month) && (now.Day < this.DateOfBirth.Day))))
            {
                --temp_age;
            }

            return temp_age;
        }
    }
}

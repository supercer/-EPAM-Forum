
namespace _EPAM_Forum.Entites
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class MessageDTO
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime DateOfCreation { get; set; }

        public MessageDTO(string text, DateTime date_of_creation)
        {
            this.Text = text;
            this.DateOfCreation = date_of_creation;
        }

        public MessageDTO(int id, string text, DateTime date_of_creation)
        {
            this.Id = id;
            this.Text = text;
            this.DateOfCreation = date_of_creation;
        }
    }
}

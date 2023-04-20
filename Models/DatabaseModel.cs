using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace LAB2.Models
{
    public class DatabaseModel
    {
        [Key]
        [DisplayName("ID")]
        public int ID { get; set; }

        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [DisplayName("Second Name")]
        public string SecondName { get; set; }

        [DisplayName("Age")]
        public int Age { get; set; }

        [DisplayName("Phone")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [DisplayName("Email")]
        public string Email { get; set; }
    }
}

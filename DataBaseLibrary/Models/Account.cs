using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataBaseLibrary.Models
{
    [Table("Account")]
    public class Account
    {
        [Key]
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int Mark { get; set; }
        public Account()
        {
            Mark = 0;
        }
    }
}

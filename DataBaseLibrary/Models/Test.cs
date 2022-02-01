using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataBaseLibrary.Models
{
    [Table("Test")]
    public class Test
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string NameTest { get; set; }
        public ICollection<Question> Questions { get; set; }
        public Test()
        {
            Questions = new List<Question>();
        }
    }
}

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataBaseLibrary.Models
{
    [Table("Answer")]
    public class Answer
    {
        [Key]
        public int Id { get; set; }
        public string TextAnswer { get; set; }
        public ICollection<Question> Questions { get; set; }
        public Answer()
        {
            Questions = new List<Question>();
        }
    }
}

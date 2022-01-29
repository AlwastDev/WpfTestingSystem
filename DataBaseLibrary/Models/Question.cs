using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataBaseLibrary.Models
{
    [Table("Question")]
    public class Question
    {
        [Key]
        public int Id { get; set; }
        public string TextQuestion { get; set; }
        public int? TestId { get; set; }
        public Test Test { get; set; }
        public ICollection<Answer> Answers { get; set; }
        public Question()
        {
            Answers = new List<Answer>();
        }
    }
}

using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace QuizManagement.Models
{
    [Table("QUIZZES")]
    public class Quizzes
    {
        [Key]
        [Column("QUIZ_ID")]
        public required string Id { get; set; }
        [Column("START_TIME")]
        public DateTime StartTime { get; set; }
        [Column("END_TIME")]
        public DateTime EndTime { get; set; }
        [Column("TIME_LIMIT")]
        public int TimeLimit { get; set; }
        [Column("QUESTIONS")]
        public int Questions { get; set; }

        public ICollection<Questions> QuestionsList { get; set; } = new List<Questions>();
    }
}

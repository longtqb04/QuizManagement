using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace QuizManagement.Models
{
    [Table("SCORES")]
    public class Scores
    {
        [Key]
        [Column("STUDENT_ID")]
        public required string StudentID { get; set; }

        [ForeignKey("StudentID")]
        public virtual Student Student { get; set; }

        [Column("QUIZ_ID")]
        public required string QuizID { get; set; }

        [ForeignKey("QuizID")]
        public virtual Quizzes Quiz { get; set; }

        [Column("QUESTIONS")]
        public int Questions { get; set; }

        [Column("CORRECT")]
        public int Correct { get; set; }

        [Column("SCORE")]
        public float Score { get; set; }
    }
}

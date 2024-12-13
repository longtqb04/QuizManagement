using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuizManagement.Models
{
    [Table("QUESTIONS")]
    public class Questions
    {
        
        [Column("QUIZ_ID")]
        public required string QuizId { get; set; }
        [Key]
        [Column("QUESTION_ID")]
        public required string QuestionId { get; set; }
        [Column("QUESTION")]
        public string? Question { get; set; }
        [Column("ANSWER_A")]
        public string? AnswerA { get; set; }
        [Column("ANSWER_B")]
        public string? AnswerB { get; set; }
        [Column("ANSWER_C")]
        public string? AnswerC { get; set; }
        [Column("ANSWER_D")]
        public string? AnswerD { get; set; }
        [Column("ANSWER_E")]
        public string? AnswerE { get; set; }
        [Column("CORRECT")]
        public char Correct { get; set; }

        [ForeignKey("QuizId")]
        public Quizzes Quiz { get; set; }
    }
}

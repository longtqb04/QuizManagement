using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace QuizManagement.Models
{
    [Table("STUDENT")]
    public class Student
    {
        [Column("STUDENTID")]
        public required string Id { get; set; }

        [Column("FULL_NAME")]
        public required string Name { get; set; }

        [Column("BDATE")]
        public DateTime DOB { get; set; }

        [Column("GENDER")]
        public char Gender { get; set; }

        [Column("ADDRESS")]
        public required string Address { get; set; }

        [Column("PHONE")]
        public string? Phone { get; set; }

        [Column("EMAIL")]
        public required string Email { get; set; }

        [Column("FACULTY")]
        public string? Faculty { get; set; }
    }
}
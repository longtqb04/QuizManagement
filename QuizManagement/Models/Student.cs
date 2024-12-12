using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace QuizManagement.Models
{
    [Table("STUDENT")]
    public class Student
    {
        [Column("STUDENTID")]  // Maps to the STUDENTID column in the database
        public required string Id { get; set; }

        [Column("FULL_NAME")]  // Maps to the FULL_NAME column in the database
        public required string Name { get; set; }

        [Column("BDATE")]  // Maps to the BDATE column in the database
        public DateTime DOB { get; set; }

        [Column("GENDER")]  // Maps to the GENDER column in the database
        public char Gender { get; set; }

        [Column("ADDRESS")]  // Maps to the ADDRESS column in the database
        public required string Address { get; set; }

        [Column("PHONE")]  // Maps to the PHONE column in the database
        public string? Phone { get; set; }

        [Column("EMAIL")]  // Maps to the EMAIL column in the database
        public required string Email { get; set; }

        [Column("FACULTY")]  // Maps to the FACULTY column in the database
        public string? Faculty { get; set; }
    }
}
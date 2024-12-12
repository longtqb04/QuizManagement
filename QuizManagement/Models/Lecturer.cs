using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace QuizManagement.Models
{
    [Table("LECTURER")]
    public class Lecturer
    {
        [Column("L_CITIZENID")]
        public required string Id { get; set; }
        [Column("L_FULL_NAME")]
        public required string Name { get; set; }
        [Column("L_BDATE")]
        public DateTime DOB { get; set; }
        [Column("L_GENDER")]
        public char Gender { get; set; }
        [Column("L_ADDRESS")]
        public required string Address { get; set; }
        [Column("L_PHONE")]
        public string? Phone { get; set; }
        [Column("L_EMAIL")]
        public required string Email { get; set; }
        [Column("L_FACULTY")]
        public string? Faculty { get; set; }
    }
}

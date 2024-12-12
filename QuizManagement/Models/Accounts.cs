using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuizManagement.Models
{
    [Table("ACCOUNTS")]
    public class Accounts
    {
        [Key]
        [Column("USERNAME")]
        public required string Username { get; set; }
        [Column("PASSWORD")]
        public required string Password { get; set; }
    }
}

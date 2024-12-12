using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace QuizManagement.Models
{
    [Table("ADMINISTRATOR")]
    public class Administrator
    {
        [Column("AD_ID")]
        public required string Id { get; set; }
        [Column("AD_NAME")]
        public required string Name { get; set; }
        [Column("AD_EMAIL")]
        public required string Email { get; set; }
        [Column("AD_ROLE")]
        public string? Role { get; set; }
    }
}

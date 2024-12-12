using Microsoft.AspNetCore.Mvc;
using QuizManagement.Models;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using AspNetCoreGeneratedDocument;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuizManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult EnterQuiz()
        {
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult LoginAdmin()
        {
            return View();
        }

        public IActionResult LoginLecturer()
        {
            return View();
        }

        public IActionResult MainPage()
        {
            return View();
        }

        public IActionResult MainPageAdmin()
        {
            return View();
        }

        public IActionResult MainPageLecturer()
        {
            return View();
        }

        public IActionResult ManageLecturers()
        {
            return View();
        }

        public IActionResult ManageScores()
        {
            return View();
        }

        public IActionResult ManageStudents()
        {
            return View();
        }

        public IActionResult ManageStudents_LecturerView()
        {
            return View();
        }

        public IActionResult ManageQuestions()
        {
            return View();
        }

        public IActionResult ManageQuizzes()
        {
            return View();
        }

        public IActionResult Profile()
        {
            return View();
        }

        public IActionResult ProfileAdmin()
        {
            return View();
        }

        public IActionResult ProfileLecturer()
        {
            return View();
        }

        public IActionResult QuizResult()
        {
            return View();
        }

        public IActionResult TakeQuiz()
        {
            return View();
        }

        public IActionResult ViewScores()
        {
            return View();
        }

        public IActionResult ViewQuizzes()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

    public class Student
    {
        [Key]
        [Column("studentid")]
        public required string Id { get; set; }

        [Column("full_name")]
        public required string Name { get; set; }

        [Column("bdate")]
        public DateTime DOB { get; set; }

        [Column("gender")]
        public char Gender { get; set; }

        [Column("address")]
        public required string Address { get; set; }

        [Column("phone")]
        public string? Phone { get; set; }

        [Column("email")]
        public required string Email { get; set; }

        [Column("faculty")]
        public string? Faculty { get; set; }
    }

    public class Lecturer
    {
        [Key]
        [Column("l_citizen_id")] // Ensure the column name matches in the database
        public required string Id { get; set; }

        [Column("l_full_name")] // Map the name to "lecturer_name" if it's different in the database
        public required string Name { get; set; }

        [Column("l_bdate")]
        public DateTime DOB { get; set; }

        [Column("l_gender")]
        public char Gender { get; set; }

        [Column("l_address")]
        public required string Address { get; set; }

        [Column("l_phone")]
        public string? Phone { get; set; }

        [Column("l_email")]
        public required string Email { get; set; }

        [Column("l_faculty")]
        public string? Faculty { get; set; }
    }

    public class Administrator
    {
        [Key]
        [Column("ad_id")]
        public required string Id { get; set; }

        [Column("ad_name")]
        public required string Name { get; set; }

        [Column("ad_email")]
        public required string Email { get; set; }

        [Column("ad_role")]
        public string? Role { get; set; }
    }

    public class Quizzes
    {
        [Key]
        [Column("quiz_id")] // Ensure the column name matches in the database
        public required string Id { get; set; }

        [Column("start_time")]
        public DateTime StartTime { get; set; }

        [Column("end_time")]
        public DateTime EndTime { get; set; }

        [Column("time_limit")]
        public int TimeLimit { get; set; }

        [Column("questions")]
        public int Questions { get; set; }
    }

    [PrimaryKey(nameof(QuizId), nameof(QuestionId))]
    public class Questions
    {
        [Column("quiz_id")]
        public required string QuizId { get; set; }

        [Column("question_id")]
        public required string QuestionId { get; set; }

        [Column("question")]
        public string? Question { get; set; }

        [Column("answer_a")]
        public string? AnswerA { get; set; }

        [Column("answer_b")]
        public string? AnswerB { get; set; }

        [Column("answer_c")]
        public string? AnswerC { get; set; }

        [Column("answer_d")]
        public string? AnswerD { get; set; }

        [Column("answer_e")]
        public string? AnswerE { get; set; }

        [Column("correct")]
        public char Correct { get; set; }
    }

    public class Scores
    {
        [Key]
        [Column("student_id")] // Ensure the column name matches in the database
        public required string StudentID { get; set; }

        [Column("quiz_id")]
        public required string QuizID { get; set; }

        [Column("questions")]
        public int Questions { get; set; }

        [Column("correct")]
        public int Correct { get; set; }

        [Column("score")]
        public float Score { get; set; }
    }

    public class Accounts
    {
        [Key]
        [Column("username")]
        public required string Username { get; set; }

        [Column("password")]
        public required string Password { get; set; }
    }

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Add DbSet properties for entities
        public DbSet<Student> Students { get; set; }
        public DbSet<Lecturer> Lecturers { get; set; }
        public DbSet<Administrator> Admins { get; set; }
        public DbSet<Quizzes> Quizzes { get; set; }
        public DbSet<Questions> Questions { get; set; }
        public DbSet<Scores> Scores { get; set; }
        public DbSet<Accounts> Accounts { get; set; }

        // Fluent API configuration for correct column mapping
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .ToTable("Student")
                .Property(s => s.Id).HasColumnName("studentid");

            modelBuilder.Entity<Lecturer>()
                .ToTable("Lecturer")
                .Property(l => l.Id).HasColumnName("l_citizen_id");


            modelBuilder.Entity<Administrator>()
                .ToTable("Administrator")
                .Property(a => a.Id).HasColumnName("ad_id");

            modelBuilder.Entity<Quizzes>()
                .ToTable("Quizzes")
                .Property(q => q.Id).HasColumnName("quiz_id");

            modelBuilder.Entity<Questions>()
                .ToTable("Questions")
                .Property(q => q.QuizId).HasColumnName("quiz_id");

            modelBuilder.Entity<Scores>()
                .ToTable("Scores")
                .Property(s => s.StudentID).HasColumnName("student_id");
        }
    }

    public class ManageStudentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ManageStudentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string searchString)
        {
            // Fetch all students or filter by search string
            var students = from s in _context.Students
                           select s;

            if (!string.IsNullOrEmpty(searchString))
            {
                students = students.Where(s => s.Name.Contains(searchString) || s.Id.Contains(searchString));
            }

            return View(await students.ToListAsync());
        }
    }
}

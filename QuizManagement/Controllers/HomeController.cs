using Microsoft.AspNetCore.Mvc;
using QuizManagement.Models;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using AspNetCoreGeneratedDocument;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Oracle.ManagedDataAccess.Client;

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

    public class OracleDbContext : DbContext { 
        public OracleDbContext(DbContextOptions<OracleDbContext> options) : base(options) { }
        public DbSet<Student> Students { get; set; }
        public DbSet<Lecturer> Lecturers { get; set; }
        public DbSet<Administrator> Admins { get; set; }
        public DbSet<Quizzes> Quizzes { get; set; }
        public DbSet<Questions> Questions { get; set; }
        public DbSet<Scores> Scores { get; set; }
        public DbSet<Accounts> Accounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Scores>()
                .HasOne(s => s.Student)
                .WithMany()
                .HasForeignKey(s => s.StudentID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Scores>()
                .HasOne(s => s.Quiz)
                .WithMany()
                .HasForeignKey(s => s.QuizID)
                .OnDelete(DeleteBehavior.Cascade);
        }

    }

    public class DatabaseController : Controller
    {
        private readonly OracleDbContext _context;

        public DatabaseController(OracleDbContext context)
        {
            _context = context;
        }

        // Index for Students
        public IActionResult IndexStudents_AdminView()
        {
            var students = _context.Students.ToList() ?? new List<Student>();
            return View("~/Views/Home/ManageStudents.cshtml", students);
        }

        public IActionResult IndexStudents_LecturerView()
        {
            var students = _context.Students.ToList() ?? new List<Student>();
            return View("~/Views/Home/ManageStudents_LecturerView.cshtml", students);
        }

        public IActionResult IndexLecturers()
        {
            var lecturers = _context.Lecturers.ToList() ?? new List<Lecturer>();
            return View("~/Views/Home/ManageLecturers.cshtml", lecturers);
        }

        public IActionResult IndexAdmins()
        {
            var admins = _context.Admins.ToList() ?? new List<Administrator>();
            return View("~/Views/Home/ManageAdmins.cshtml", admins);
        }

        public IActionResult IndexQuizzes()
        {
            var quizzes = _context.Quizzes.ToList();
            return View("~/Views/Home/ManageQuizzes.cshtml", quizzes);
        }

        public IActionResult IndexQuestions()
        {
            var questions = _context.Questions.ToList();
            return View("~/Views/Home/ManageQuestions.cshtml", questions);
        }

        public IActionResult IndexScores()
        {
            var scores = _context.Scores.ToList() ?? new List<Scores>();
            return View("~/Views/Home/ManageScores.cshtml", scores);
        }

        public IActionResult IndexScores_StudentView()
        {
            var scores = _context.Scores.ToList() ?? new List<Scores>();
            return View("~/Views/Home/ViewScores.cshtml", scores);
        }

        public IActionResult CreateStudent()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateStudent([Bind("StudentID,Full_Name,BDate,Gender,Address,Phone,Email,Faculty")] Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Add(student);
                _context.SaveChanges();
                return RedirectToAction(nameof(IndexStudents_AdminView));
            }
            return View(student);
        }

        public IActionResult CreateLecturer()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateLecturer([Bind("L_Citizen_ID,L_Full_Name,L_BDate,L_Gender,L_Address,L_Phone,L_Email,Faculty")] Lecturer lecturer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lecturer);
                _context.SaveChanges();
                return RedirectToAction(nameof(IndexLecturers));
            }
            return View(lecturer);
        }

        public IActionResult CreateAdmin()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateAdmin([Bind("AdminID,FullName,Email,Role")] Administrator admin)
        {
            if (ModelState.IsValid)
            {
                _context.Add(admin);
                _context.SaveChanges();
                return RedirectToAction(nameof(IndexAdmins));
            }
            return View(admin);
        }

        public IActionResult EditStudent(int id)
        {
            var student = _context.Students.Find(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditStudent(int id, [Bind("StudentID,Full_Name,BDate,Gender,Address,Phone,Email,Faculty")] Student student)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(student);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Students.Any(s => s.Id == student.Id))
                    {
                        return NotFound();
                    }
                    throw;
                }
                return RedirectToAction(nameof(IndexStudents_AdminView));
            }
            return View(student);
        }
    }

}

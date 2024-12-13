using Microsoft.AspNetCore.Mvc;
using QuizManagement.Models;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using AspNetCoreGeneratedDocument;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Oracle.ManagedDataAccess.Client;
using static System.Formats.Asn1.AsnWriter;
using Microsoft.EntityFrameworkCore.Storage.Json;

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
            var lect = _context.Lecturers.ToList() ?? new List<Lecturer>();
            return View("~/Views/Home/ManageLecturers.cshtml", lect);
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

        public IActionResult IndexViewQuizzes()
        {
            var quizzes = _context.Quizzes.ToList();
            return View("~/Views/Home/ViewQuizzes.cshtml", quizzes);
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

        public IActionResult CreateStudent_AdminView()
        {
            var student = _context.Students.ToList() ?? new List<Student>();
            return View("~/Views/Home/ManageStudents.cshtml", student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateStudent_AdminView([Bind("Id,Name,DOB,Gender,Address,Phone,Email,Faculty")] Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Add(student);
                _context.SaveChanges();
                return RedirectToAction(nameof(IndexStudents_AdminView));
            }
            return View("~/Views/Home/ManageStudents.cshtml", student);
        }

        public IActionResult CreateStudent_LecturerView()
        {
            var student = _context.Students.ToList() ?? new List<Student>();
            return View("~/Views/Home/ManageStudents_LecturerView.cshtml", student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateStudent_LecturerView([Bind("Id,Name,DOB,Gender,Address,Phone,Email,Faculty")] Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Add(student);
                _context.SaveChanges();
                return RedirectToAction(nameof(IndexStudents_LecturerView));
            }
            return View("~/Views/Home/ManageStudents_LecturerView.cshtml", student);
        }

        public IActionResult CreateQuizzes()
        {
            var quiz = _context.Quizzes.ToList() ?? new List<Quizzes>();
            return View("~/Views/Home/ManageQuizzes.cshtml", quiz);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateQuizzes([Bind("Id,StartTime,EndTime,TimeLimit,Questions")] Quizzes quiz)
        {
            if (ModelState.IsValid)
            {
                _context.Add(quiz);
                _context.SaveChanges();
                return RedirectToAction(nameof(IndexQuizzes));
            }
            return View("~/Views/Home/ManageQuizzes.cshtml", quiz);
        }

        public IActionResult CreateQuestions()
        {
            var question = _context.Questions.ToList() ?? new List<Questions>();
            return View("~/Views/Home/ManageQuestions.cshtml", question);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateQuestions([Bind("QuizId,QuestionId,Question,AnswerA,AnswerB,AnswerC,AnswerD,AnswerE,Correct")] Questions ques)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(ques);
                    _context.SaveChanges();
                    return RedirectToAction(nameof(IndexQuestions));
                }
                catch (Exception ex)
                {
                    // Log the exception and return error feedback
                    ModelState.AddModelError(string.Empty, $"An error occurred while saving the question: {ex.Message}");
                }
            }
            return View("~/Views/Home/ManageQuestions.cshtml", ques);
        }

        public IActionResult CreateLecturer()
        {
            var lecturer = _context.Lecturers.ToList() ?? new List<Lecturer>();
            return View("~/Views/Home/ManageLecturers.cshtml", lecturer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateLecturer([Bind("Id,Name,DOB,Gender,Address,Phone,Email,Faculty")] Lecturer lecturer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lecturer);
                _context.SaveChanges();
                return RedirectToAction(nameof(IndexLecturers));
            }
            return View("~/Views/Home/ManageLecturers.cshtml", lecturer);
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

        public IActionResult EditStudent_AdminView(int id)
        {
            var student = _context.Students.Find(id);
            if (student == null)
            {
                return NotFound();
            }
            return View("~/Views/Home/ManageStudents.cshtml", student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditStudent_AdminView(int id, [Bind("Id,Name,DOB,Gender,Address,Phone,Email,Faculty")] Student student)
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
            return View("~/Views/Home/ManageStudents.cshtml", student);
        }

        public IActionResult EditStudent_LecturerView(int id)
        {
            var student = _context.Students.Find(id);
            if (student == null)
            {
                return NotFound();
            }
            return View("~/Views/Home/ManageStudents.cshtml", student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditStudent_LecturerView(int id, [Bind("Id,Name,DOB,Gender,Address,Phone,Email,Faculty")] Student student)
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
                return RedirectToAction(nameof(IndexStudents_LecturerView));
            }
            return View("~/Views/Home/ManageStudents_LecturerView.cshtml", student);
        }

        public IActionResult EditLecturer(string id)
        {
            var lect = _context.Lecturers.Find(id);
            if (lect == null)
            {
                return NotFound();
            }
            return View("~/Views/Home/ManageLecturers.cshtml", lect);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditLecturer(string id, [Bind("Id,Name,DOB,Gender,Address,Phone,Email,Faculty")] Lecturer lect)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lect);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Lecturers.Any(l => l.Id == lect.Id))
                    {
                        return NotFound();
                    }
                    throw;
                }
                return RedirectToAction(nameof(IndexLecturers));
            }
            return View("~/Views/Home/ManageLecturers.cshtml", lect);
        }

        public IActionResult EditQuiz(int id)
        {
            var quiz = _context.Quizzes.Find(id);
            if (quiz == null)
            {
                return NotFound();
            }
            return View("~/Views/Home/ManageQuizzes.cshtml", quiz);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditQuiz(int id, [Bind("Id,StartTime,EndTime,TimeLimit,Questions")] Quizzes quiz)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(quiz);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Quizzes.Any(q => q.Id == quiz.Id))
                    {
                        return NotFound();
                    }
                    throw;
                }
                return RedirectToAction(nameof(IndexQuizzes));
            }
            return View("~/Views/Home/ManageQuizzes.cshtml", quiz);
        }

        // Add actions for editing questions
        public IActionResult EditQuestion(string id)
        {
            var question = _context.Questions.Find(id);
            if (question == null)
            {
                return NotFound();
            }
            return View("~/Views/Home/ManageQuestions.cshtml", question);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditQuestion(string id, [Bind("QuizId,QuestionId,Question,AnswerA,AnswerB,AnswerC,AnswerD,AnswerE,Correct")] Questions ques)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ques);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Questions.Any(q => q.QuestionId == ques.QuestionId))
                    {
                        return NotFound();
                    }
                    throw;
                }
                return RedirectToAction(nameof(IndexQuestions));
            }
            return View("~/Views/Home/ManageQuestions.cshtml", ques);
        }

        public IActionResult SearchStudents_AdminView(string searchQuery)
        {
            var students = string.IsNullOrWhiteSpace(searchQuery)
                ? _context.Students.ToList()
                : _context.Students.Where(s => s.Name.Contains(searchQuery)).ToList();
            return View("~/Views/Home/ManageStudents.cshtml", students);
        }

        public IActionResult SearchStudents_LecturerView(string searchQuery)
        {
            var students = string.IsNullOrWhiteSpace(searchQuery)
                ? _context.Students.ToList()
                : _context.Students.Where(s => s.Name.Contains(searchQuery)).ToList();
            return View("~/Views/Home/ManageStudents_LecturerView.cshtml", students);
        }

        public IActionResult SearchLecturers(string searchQuery)
        {
            var lecturers = string.IsNullOrWhiteSpace(searchQuery)
                ? _context.Lecturers.ToList()
                : _context.Lecturers.Where(l => l.Name.Contains(searchQuery)).ToList();
            return View("~/Views/Home/ManageLecturers.cshtml", lecturers);
        }

        public IActionResult SearchAdmins(string searchQuery)
        {
            var admins = string.IsNullOrWhiteSpace(searchQuery)
                ? _context.Admins.ToList()
                : _context.Admins.Where(a => a.Name.Contains(searchQuery)).ToList();
            return View("~/Views/Home/ManageAdmins.cshtml", admins);
        }

        public IActionResult SearchScores_LecturerView(string searchQuery)
        {
            var admins = string.IsNullOrWhiteSpace(searchQuery)
                ? _context.Scores.ToList()
                : _context.Scores.Where(s => s.StudentID.Contains(searchQuery)).ToList();
            return View("~/Views/Home/ManageScores.cshtml", admins);
        }

        public IActionResult SearchScores_StudentView(string searchQuery)
        {
            var admins = string.IsNullOrWhiteSpace(searchQuery)
                ? _context.Scores.ToList()
                : _context.Scores.Where(s => s.StudentID.Contains(searchQuery)).ToList();
            return View("~/Views/Home/ViewScores.cshtml", admins);
        }
        public IActionResult EnterQuiz(string id)
        {
            // Fetch the quiz details using the provided ID
            var quiz = _context.Quizzes.FirstOrDefault(q => q.Id == id);
            if (quiz == null)
            {
                return NotFound();
            }

            return View("~/Views/Home/EnterQuiz.cshtml", quiz);
        }

        [HttpGet]
        public IActionResult TakeQuiz(string quizId)
        {
            var questions = _context.Questions
                .Where(q => q.QuizId == quizId)
                .ToList();

            if (!questions.Any())
            {
                return NotFound("No questions found for this quiz.");
            }
            ViewData["Score"] = null;
            ViewBag.QuizId = quizId;
            return View("~/Views/Home/TakeQuiz.cshtml", questions);
        }

        [HttpPost]
        public IActionResult QuizResult(IFormCollection form)
        {
            var questions = _context.Questions.ToList();
            int totalQuestions = 0;
            int correctAnswers = 0;

            foreach (var question in questions)
            {
                string answer = form[$"question-{question.QuestionId}"];

                if (!string.IsNullOrEmpty(answer))
                {
                    totalQuestions++;
                    char userAnswer = answer[0];
                    if (userAnswer == question.Correct)
                    {
                        correctAnswers++;
                    }
                }
            }

            double score = ((double)correctAnswers / totalQuestions) * 10;
            score = Math.Round(score, 2);

            ViewData["Score"] = score;
            ViewData["StartTime"] = DateTime.Now.ToString("dd/MM/yyyy");
            ViewData["EndTime"] = DateTime.Now.ToString("dd/MM/yyyy");

            return View("~/Views/Home/QuizResult.cshtml");
        }
    }


}

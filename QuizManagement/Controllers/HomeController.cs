using Microsoft.AspNetCore.Mvc;
using QuizManagement.Models;
using System.Diagnostics;

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
}

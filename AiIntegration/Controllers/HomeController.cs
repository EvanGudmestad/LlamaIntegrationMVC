using GroqSharp;
using AiIntegration.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AiIntegration.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IGroqClient _groqClient;

        public HomeController(ILogger<HomeController> logger, IGroqClient groqClient)
        {
            _logger = logger;
            _groqClient = groqClient;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(string question)
        {
            question = String.Concat(question, " Please answer in 50 characters or less with a Chamath Palihapitiya impersonation.");
            string answer = await _groqClient.CreateChatCompletionAsync(new GroqSharp.Models.Message { Content = question });
            ViewBag.Answer = answer;
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

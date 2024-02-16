using Microsoft.AspNetCore.Mvc;
using UniversalChatRoom.Models;
using System.Diagnostics;
using UniversalChatRoom.Models;

namespace UniversalChatRoom.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        TextTranslator tt = new TextTranslator(); // this needs to be passed into any view that uses the translator

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Public()
        {
            return View();
        }

        public IActionResult Test()
        {
            return View(tt);
        }

        public IActionResult Chat(Message add)
        {
            //add message to database
            return RedirectToAction("Public", "Home");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

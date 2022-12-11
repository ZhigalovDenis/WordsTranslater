using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WordsTranslater.Models;
using WordsTranslater.Domain.Models;

namespace WordsTranslater.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            Word word = new Word();
            word.WordId = 1;
            word.SrcWord = "Привет";
            word.DstWord = "Hellow";
            return View(word);
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
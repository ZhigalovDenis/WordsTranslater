using Microsoft.AspNetCore.Mvc;
using System;
using WordsTranslater.DAL.Repositories;
using WordsTranslater.Domain.Models;
using WordsTranslater.Service.Interfaces;

namespace WordsTranslater.Controllers
{
    public class WordController : Controller
    {
        private readonly IWordService _wordService;
        public WordController(IWordService wordService)
        {
            _wordService = wordService;
        }
        public async Task<IActionResult> GetWords()
        {
            var response = await _wordService.GetWords();
            return View(response.Data);
        }
    }
}

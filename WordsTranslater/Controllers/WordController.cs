using Microsoft.AspNetCore.Mvc;
using System;
using WordsTranslater.DAL.Repositories;
using WordsTranslater.Domain.Models;
using WordsTranslater.Domain.ViewModel;
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
        [HttpGet]
        public async Task<IActionResult> GetWords()
        {
            var response = await _wordService.GetWords();
            return View(response.Data);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var response = await _wordService.GetWords();
            return View();
		}

        [HttpPost]
        public async Task<IActionResult> Create(WordViewModel wordViewModel)
        {
            await _wordService.CreateWord(wordViewModel);
            await _wordService.SaveWord();
            TempData["success"] = "Новая запись создана успешно";
            return RedirectToAction("GetWords");
        }

		[HttpGet]
		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}
			var word = await _wordService.GetWord((int)id);
			if (word == null)
			{
				return NotFound();
			}
			return View(word.Data);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(WordViewModel wordViewModel)
		{
			await _wordService.EditWord(wordViewModel);
			await _wordService.SaveWord();
			TempData["success"] = "Запись успешно изменена";
			return RedirectToAction("GetWords");
		}

		[HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var word = await _wordService.GetWord((int)id);
            if (word == null)
            {
                return NotFound();
            }
            return View(word.Data);
        }

		[HttpPost, ActionName("Delete")]
		public async Task<IActionResult> DeletePOST(int id)
		{
            await _wordService.DeleteWord(id);
			await _wordService.SaveWord();
			TempData["success"] = "Запись удалена";
			return RedirectToAction("GetWords");
		}
	}
}


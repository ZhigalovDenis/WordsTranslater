using WordsTranslater.Domain.Models;
using WordsTranslater.Domain.Response;
using WordsTranslater.Domain.ViewModel;

namespace WordsTranslater.Service.Interfaces
{
    public interface IWordService
    {
        Task<IBaseResponse<IEnumerable<WordViewModel>>> GetWords();

        Task<IBaseResponse<WordViewModel>> GetWord(int id);

		Task<IBaseResponse<WordViewModel>> CreateWord(WordViewModel wordViewModel);

		Task<IBaseResponse<WordViewModel>> EditWord(WordViewModel model);
		Task<IBaseResponse<bool>> DeleteWord(int id);

		Task<IBaseResponse<bool>> SaveWord();

		//Task<IBaseResponse<WordViewModel>> CreateWord(WordViewModel carViewModel);

		//Task<IBaseResponse<bool>> DeleteWord(int id);

		//Task<IBaseResponse<Word>> EditWord(int id, WordViewModel model);
	}
}

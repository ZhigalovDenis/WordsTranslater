using WordsTranslater.Domain.Models;
using WordsTranslater.Domain.Response;

namespace WordsTranslater.Service.Interfaces
{
    public interface IWordService
    {
        Task<IBaseResponse<IEnumerable<Word>>> GetWords();
    }
}

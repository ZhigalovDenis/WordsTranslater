
using WordsTranslater.DAL.Repositories;
using WordsTranslater.Domain.Models;
using WordsTranslater.Domain.Response;
using WordsTranslater.Service.Interfaces;

namespace WordsTranslater.Service.Implementation
{
    public class WordService : IWordService
    {
        private readonly IWordRepository _wordRepository;

        public WordService(IWordRepository wordRepository)
        {
            _wordRepository = wordRepository;
        }

        public async Task<IBaseResponse<IEnumerable<Word>>> GetWords()
        {
            var baseResponce = new BaseResponse<IEnumerable<Word>>();
                var words = await _wordRepository.GetAll();
                //всякий дикий код
                baseResponce.Data = words;
                return baseResponce;          
        }
    }
}


using System.Security.Cryptography.X509Certificates;
using WordsTranslater.DAL.Repositories;
using WordsTranslater.Domain.Enum;
using WordsTranslater.Domain.Models;
using WordsTranslater.Domain.Response;
using WordsTranslater.Domain.ViewModel;
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

        public async Task<IBaseResponse<IEnumerable<WordViewModel>>> GetWords()
        {
            List<WordViewModel> wordViewModels = new List<WordViewModel>();
            var baseResponse = new BaseResponse<IEnumerable<WordViewModel>>();
            var words = await _wordRepository.GetAll();
            if(words.Count() == 0)
            {
                baseResponse.Description = "Нет объектов";
                baseResponse.StatusCode = StatusCode.OK;
                return baseResponse;
            }

            foreach (var item in words)
            {
                var data = new WordViewModel()
                {
                    WordId= item.WordId,    
                    SrcWord = item.SrcWord,
                    DstWord = item.DstWord
                };
                wordViewModels.Add(data);
            }

            baseResponse.Data = wordViewModels;
            baseResponse.StatusCode = StatusCode.OK;
            return baseResponse;
        }

        public async Task<IBaseResponse<WordViewModel>> GetWord(int id)
        {
            var baseResponse = new BaseResponse<WordViewModel>();
            var word = await _wordRepository.GetById(id);
            if (word == null)
            {
                baseResponse.Description = "Слово не найдено";
                baseResponse.StatusCode = StatusCode.WordNotFound;
                return baseResponse;
            }

            var data = new WordViewModel()
            {
                WordId = word.WordId,
                SrcWord = word.SrcWord,
                DstWord = word.DstWord
            };

			baseResponse.StatusCode = StatusCode.OK;
			baseResponse.Data = data;
            return baseResponse;
        }

		public async Task<IBaseResponse<WordViewModel>> CreateWord(WordViewModel wordViewModel)
		{
			var baseResponse = new BaseResponse<WordViewModel>();

				var word = new Word()
				{
                    SrcWord = wordViewModel.SrcWord,
                    DstWord = wordViewModel.DstWord 
				};

				await _wordRepository.Insert(word);
			
			return baseResponse;
		}


		public async Task<IBaseResponse<WordViewModel>> EditWord(WordViewModel wordViewModel)
		{
			var baseResponse = new BaseResponse<WordViewModel>();
			var word = new Word()
			{
                WordId = wordViewModel.WordId,
				SrcWord = wordViewModel.SrcWord,
				DstWord = wordViewModel.DstWord
			};

            await _wordRepository.Edit(word);
            return baseResponse;
		}
		public async Task<IBaseResponse<bool>> DeleteWord(int id)
		{
			var baseResponse = new BaseResponse<bool>();
            await _wordRepository.Delete(id);
            baseResponse.Data = true;
            return baseResponse;
		}
		public async Task<IBaseResponse<bool>> SaveWord()
		{
            var baseResponse = new BaseResponse<bool>();
            await _wordRepository.Save();
            baseResponse.Data = true;
            return baseResponse;
		}
	}
}

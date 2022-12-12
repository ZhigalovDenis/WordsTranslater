using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordsTranslater.DAL.Repositories;
using WordsTranslater.Domain.Enum;
using WordsTranslater.Domain.Response;
using WordsTranslater.Domain.ViewModel;
using WordsTranslater.Service.Support;

namespace WordsTranslater.Service.Implementation
{
    public class TranslateService : ITranslateService
	{
		private readonly ITranslateService _translateService;

		public TranslateService(ITranslateService translateService) 
		{ 

			_translateService = translateService;
		}

		TranslateRUtoEN translateRUtoEN = TranslateRUtoEN.getInstance();

		public async Task<IBaseResponse<WordViewModel>> Translate(string word)
		{
			var baseResponse = new BaseResponse<WordViewModel>();
			var data = new WordViewModel()
			{
			   TranslateWord = await translateRUtoEN.Translate(word)
			};
			baseResponse.StatusCode = StatusCode.OK;
			baseResponse.Data = data;
			return baseResponse;
		}
	}
}

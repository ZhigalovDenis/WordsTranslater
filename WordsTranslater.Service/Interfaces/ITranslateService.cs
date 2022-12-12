using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordsTranslater.Domain.Response;
using WordsTranslater.Domain.ViewModel;

namespace WordsTranslater.Service.Implementation
{
	public interface ITranslateService
	{ 
		Task<IBaseResponse<WordViewModel>> Translate(string  word);
	}
}

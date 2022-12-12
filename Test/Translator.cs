using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
	internal class Translator : IAPITranslate<TranslateRUtoEN, string>
	{
		public string  _word { get; set; }
		public async Task<string> SetAPI(TranslateRUtoEN api, string word)
		{
			_word = word;
			return await api.Translate(_word);
		}
	}
}

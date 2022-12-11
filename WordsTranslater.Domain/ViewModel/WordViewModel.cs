using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordsTranslater.Domain.ViewModel
{
    public class WordViewModel
    {
        public int WordId { get; set; }

		[Required(ErrorMessage = "Поле <Оригинал> пустое, заполните!!!")]
		[DisplayName("Оригинал")]
		public string? SrcWord { get; set; }

		[Required(ErrorMessage = "Поле <Оригинал> пустое, заполните!!!")]
		[DisplayName("Перевод")]
		public string? DstWord { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordsTranslater.Domain.Models
{
    public class Word
    {
        public int WordId { get; set; } 
        public string? SrcWord { get; set; }
        public string? DstWord { get; set; }
    }
}

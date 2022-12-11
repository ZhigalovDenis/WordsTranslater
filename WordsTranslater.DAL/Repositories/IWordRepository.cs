using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using WordsTranslater.Domain.Models;

namespace WordsTranslater.DAL.Repositories
{
    public interface IWordRepository : IBaseRepository<Word, int>
    {
    }
}

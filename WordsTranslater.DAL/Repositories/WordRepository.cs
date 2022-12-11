using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordsTranslater.Domain.Models;

namespace WordsTranslater.DAL.Repositories
{
    public class WordRepository : IWordRepository//IBaseRepository<Word, int>
    {
        private readonly ApplicationDbContext _db;
        public WordRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task Delete(int id)
        {
            var WordFromDb = await _db.Words.FindAsync(id);
            if (WordFromDb != null)
            {
                _db.Remove(WordFromDb);
            }
        }

        public async Task<Word> Edit(Word entity)
        {
            _db.Words.Update(entity);
            return entity;
        }

        public async Task<IEnumerable<Word>> GetAll()
        {
            return await _db.Words.ToListAsync();
        }

        public async Task<Word> GetById(int id)
        {
            return await _db.Words.FindAsync(id);
        }

        public async Task<Word> Insert(Word entity)
        {
            await _db.Words.AddAsync(entity);
            return entity;
        }

        public async Task Save()
        {
            await _db.SaveChangesAsync();
        }
    }
}

using System.Collections.Generic;
using System;
using Microsoft.EntityFrameworkCore;
using WordsTranslater.Domain.Models;

namespace WordsTranslater.DAL
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Word> Words { get; set; }
    }
}
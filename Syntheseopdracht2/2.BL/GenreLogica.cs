using Syntheseopdracht2._3.DA;
using Syntheseopdracht2._4.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace Syntheseopdracht2._2.BL
{
    public class GenreLogica : IGenreLogica
    {
        private readonly IBoekenDatabase _database;

        public GenreLogica(IBoekenDatabase database)
        {
            _database = database;
        }

        public Task<List<Genre>> NeemAlleGenres()
        {
            return _database.Genres.ToListAsync();
        }
    }
}

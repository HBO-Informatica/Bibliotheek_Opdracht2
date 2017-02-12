
using Syntheseopdracht2.DA;
using Syntheseopdracht2.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace Syntheseopdracht2.BL
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

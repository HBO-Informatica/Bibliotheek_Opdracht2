﻿
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

        public Task GenreOpslaan(Genre genre)
        {
            _database.Genres.Add(genre);
            return _database.SaveChangesAsync();
        }

        public Task<Genre> GeefGenre(Int32 id)
        {
            // meerdere genres
            return _database.Genres.SingleOrDefaultAsync(x => x.Id == id);
            
        }

        public async Task GenreWijzigen(Genre genre)
        {
            var huidigGenre = await _database.Genres.SingleOrDefaultAsync(x => x.Id == genre.Id);
            if (huidigGenre != null)
            {
                huidigGenre.Omschrijving = genre.Omschrijving;
            }
            await _database.SaveChangesAsync();
        }

        public async Task GenreVerwijderen(Int32 id)
        {
            var huidigGenre = await _database.Genres.SingleOrDefaultAsync(x => x.Id == id);
            if (huidigGenre != null)
            {
                _database.Genres.Remove(huidigGenre);
            }
            await _database.SaveChangesAsync();
        }

    }
}

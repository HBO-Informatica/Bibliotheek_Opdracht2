using Syntheseopdracht2.DA;
using Syntheseopdracht2.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Syntheseopdracht2.BL
{
    public class BoekLogica : IBoekLogica
    {
        private readonly IBoekenDatabase _database;

        public BoekLogica(IBoekenDatabase database)
        {
            _database = database;
        }


        public Task<List<Boek>> NeemAlleBoeken()
        {
            return _database.Boeken.ToListAsync();
        }

        public Task BewaarBoek(Int32 code)
                    {

            var huidigBoek = _database.Boeken.SingleOrDefault(x => x.Id == code);

            if (huidigBoek != null)
            {
                _database.Boeken.Add(huidigBoek);
                
            }
            return _database.SaveChangesAsync();
        }

        public Task BewaarBoek(Boek boek)
        {
            _database.Boeken.Add(boek);
            return _database.SaveChangesAsync();
        }


        public Task WijzigBoek(Boek boek, List<int> genreIds = null)
        {
            genreIds = genreIds ?? new List<int>();

            // genres leegmaken in boek
            boek.Genres = new List<Genre>();

            // boek referenties weghalen uit "genre" objecten
            var previousGenres = _database.Genres
                .Where(g => g.Boeken.Any(b => b.Id == boek.Id))
                .ToListAsync().GetAwaiter().GetResult();
            foreach (var previousGenre in previousGenres)
            {
                previousGenre.Boeken.Remove(boek);
            }

            // boek toevoegen aan de nieuwe genres
            var newGenres = _database.Genres.Where(g => genreIds.Contains(g.Id)).ToList();
            foreach (var genre in newGenres)
            {
                genre.Boeken.Add(boek);
            }

            // bewaren
            return _database.SaveChangesAsync();

        }

        public Task VerwijderBoek(Int32 code)
        {
            var huidigBoek = _database.Boeken.SingleOrDefault(x => x.Id == code);

            if (huidigBoek != null)
            {
                _database.Boeken.Remove(huidigBoek);
            }

            return _database.SaveChangesAsync();
        }

       
        public Task<Boek> NeemBoek(Int32 code)
        {
            return _database.Boeken.SingleOrDefaultAsync(x => x.Id == code);
        }
    }
}

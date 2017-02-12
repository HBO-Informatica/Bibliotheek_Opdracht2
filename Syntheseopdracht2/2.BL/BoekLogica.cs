using Syntheseopdracht2._3.DA;
using Syntheseopdracht2._4.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace Syntheseopdracht2._2.BL
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

        public Task BewaarBoek(Boek boek)
        {
            _database.Boeken.Add(boek);
            return _database.SaveChangesAsync();
        }

        public Task WijzigBoek(Boek boek)
        {
            return _database.SaveChangesAsync();
        }

        public Task VerwijderBoek(Boek boek)
        {
            _database.Boeken.Remove(boek);
            return _database.SaveChangesAsync();
        }
    }
}

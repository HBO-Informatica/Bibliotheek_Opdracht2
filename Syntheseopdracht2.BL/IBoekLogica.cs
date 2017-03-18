using Syntheseopdracht2.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Syntheseopdracht2.BL
{
    public interface IBoekLogica
    {
        Task<List<Boek>> NeemAlleBoeken();

        Task BewaarBoek(Int32 code);
        Task BewaarBoek(Boek boek);

        Task WijzigBoek(Boek boek, List<int> genreIds = null);

        Task VerwijderBoek(Int32 code);
    }
}

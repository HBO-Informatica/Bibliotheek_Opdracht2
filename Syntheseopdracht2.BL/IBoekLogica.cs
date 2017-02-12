using Syntheseopdracht2.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Syntheseopdracht2.BL
{
    public interface IBoekLogica
    {
        Task<List<Boek>> NeemAlleBoeken();

        Task BewaarBoek(Boek boek);
        
        Task WijzigBoek(Boek boek);

        Task VerwijderBoek(Boek boek);

        //Task NeemGeselecteerdBoek(Boek boek);

        //Task IsGeldigBoek(Boek boek);
    }
}

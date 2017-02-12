
using Syntheseopdracht2.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Syntheseopdracht2.BL
{
    public interface IGenreLogica
    {
        Task<List<Genre>> NeemAlleGenres();

        //Task<List<Genre>> NeemGeselecteerdeGenres();
    }
}

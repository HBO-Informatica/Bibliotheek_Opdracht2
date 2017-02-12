using Syntheseopdracht2._4.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Syntheseopdracht2._2.BL
{
    public interface IGenreLogica
    {
        Task<List<Genre>> NeemAlleGenres();

        //Task<List<Genre>> NeemGeselecteerdeGenres();
    }
}

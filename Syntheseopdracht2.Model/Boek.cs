using System;
using System.Collections.Generic;

namespace Syntheseopdracht2.Model
{
    public class Boek
    {
        public Int32 Id { get; set; }
        public String Titel { get; set; }
        public String Auteur { get; set; }
        public Int32 AantalPaginas { get; set; }
        public virtual ICollection<Genre> Genres { get; set; }

        public override String ToString()
        {
            return $"[{Id}] {Titel}, {Auteur} ({AantalPaginas} pagina's)";
        }
    }
}

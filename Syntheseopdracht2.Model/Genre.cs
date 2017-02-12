using System;
using System.Collections.Generic;

namespace Syntheseopdracht2.Model
{
    public class Genre
    {
        public Int32 Id { get; set; }
        public String Omschrijving { get; set; }
        public virtual ICollection<Boek> Boeken { get; set; }

        public override String ToString()
        {
            return $"{Omschrijving}";
        }
    }
}

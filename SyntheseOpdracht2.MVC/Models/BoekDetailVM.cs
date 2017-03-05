using Syntheseopdracht2.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace SyntheseOpdracht2.MVC.Models
{
    public class BoekDetailVM
    {
        public Int32 Id { get; set; }
        public String Titel { get; set; }
        public String Auteur { get; set; }

        [DisplayName("Aantal pagina's")]
        public Int32 AantalPaginas { get; set; }

        [DisplayName("Genres")]
        public Int32 GenreId { get; set; }
        public List<Genre> Genres { get; set; }

    }
}
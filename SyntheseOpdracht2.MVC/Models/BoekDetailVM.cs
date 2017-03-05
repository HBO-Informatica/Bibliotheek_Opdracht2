using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web.Mvc;

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
        public MultiSelectList Genres { get; set; }

        public List<Int32> GenreIds { get; set; }
    }
}
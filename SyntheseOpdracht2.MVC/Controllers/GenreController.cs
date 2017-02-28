using Syntheseopdracht2.BL;
using Syntheseopdracht2.DA;
using Syntheseopdracht2.Model;
using SyntheseOpdracht2.MVC.Models;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SyntheseOpdracht2.MVC.Controllers
{
    public class GenreController : Controller
    {
        //TO DO Unity
        private readonly GenreLogica _genreLogica = new GenreLogica(new BoekenDatabase());


        public async Task<ActionResult> Index()
        {
            var genres = await _genreLogica.NeemAlleGenres();
            return View(new GenreLijstVM { Genres = genres });
        }

        public ActionResult Toevoegen()
        {
            return View(new GenreDetailVM());
        }

        [HttpPost]
        public async Task<ActionResult> Toevoegen(GenreDetailVM vm)
        {
            var nieuwGenre = new Genre
            {
                Omschrijving = vm.Omschrijving,
            };
            await _genreLogica.GenreOpslaan(nieuwGenre);
            return RedirectToAction("Index");
        }


        public async Task<ActionResult> Bewerken(Int32 code)
        {
            var genre = await _genreLogica.GeefGenre(code);
            var vm = new GenreDetailVM
            {
               Omschrijving = genre.Omschrijving
            };
            return View(vm);
        }

        [HttpPost]
        public async Task<ActionResult> Bewerken(Int32 code, GenreDetailVM vm)
        {
            var genre = await _genreLogica.GeefGenre(code);
            genre.Omschrijving = vm.Omschrijving;
            await _genreLogica.GenreWijzigen(genre);
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Verwijderen(Int32 code)
        {
            await _genreLogica.GenreVerwijderen(code);
            return RedirectToAction("Index");
        }

    }
}
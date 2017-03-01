using Syntheseopdracht2.BL;
using Syntheseopdracht2.DA;
using Syntheseopdracht2.Model;
using SyntheseOpdracht2.MVC.Models;
using System.Threading.Tasks;
using System.Web.Mvc;
using System;

namespace SyntheseOpdracht2.MVC.Controllers
{
    public class BoekController : Controller
    {
        //TO DO Unity
        private readonly GenreLogica _genreLogica = new GenreLogica(new BoekenDatabase());
        private readonly BoekLogica _boekLogica = new BoekLogica(new BoekenDatabase());

        public async Task<ActionResult> Index()
        {
            var boeken = await _boekLogica.NeemAlleBoeken();
            return View(new BoekLijstVM { Boeken=boeken });
        }

        public async Task<ActionResult> Toevoegen()
        {
            var genres = await _genreLogica.NeemAlleGenres();
            return View(new BoekDetailVM { Genres = genres });
        }

        [HttpPost]
        public async Task<ActionResult> Toevoegen(BoekDetailVM vm)
        {
            var nieuwBoek = new Boek
            {
                Titel = vm.Titel,
                Auteur = vm.Auteur,
                AantalPaginas = vm.AantalPaginas,
             //TO DO  Genres = await _genreLogica.GeefGenre(vm.Id)
            };

            await _boekLogica.BewaarBoek(nieuwBoek);
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Bewerken(Int32 code)
        {
            var genres = await _genreLogica.NeemAlleGenres();
            var boek = await _boekLogica.NeemBoek(code);
            var vm = new BoekDetailVM
            {
                Titel = boek.Titel,
                Auteur = boek.Auteur,
                AantalPaginas = boek.AantalPaginas,
                //TO DO   Genres = await _genreLogica.GeefGenre(vm.GenreId)
            };
            return View(vm);
        }

        [HttpPost]
        public async Task<ActionResult> Bewerken(Int32 code, BoekDetailVM vm)
        {
            var boek = await _boekLogica.NeemBoek(code);
            boek.Titel = vm.Titel;
            boek.Auteur = vm.Auteur;
            boek.AantalPaginas = vm.AantalPaginas;
            // TO DO  boek.Genres = await _genreLogica.GeefGenre(vm.GenreId);
            await _boekLogica.WijzigBoek(boek);
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Verwijderen(Int32 code)
        {
            await _boekLogica.VerwijderBoek(code);
            return RedirectToAction("Index");
        }

    }
}
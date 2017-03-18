using Syntheseopdracht2.BL;
using Syntheseopdracht2.DA;
using Syntheseopdracht2.Model;
using SyntheseOpdracht2.MVC.Models;
using System.Threading.Tasks;
using System.Web.Mvc;
using System;
using System.Linq;
using System.Collections.Generic;

namespace SyntheseOpdracht2.MVC.Controllers
{
    public class BoekController : Controller
    {
        //TO DO Unity
        //private readonly BoekenDatabase _boekenDatabase;

        private readonly IGenreLogica _genreLogica;
        private readonly IBoekLogica _boekLogica;

        public BoekController(IGenreLogica genreLogica, IBoekLogica boekLogica)
        {
            _genreLogica = genreLogica;
            _boekLogica = boekLogica;
        }

        public async Task<ActionResult> Index()
        {
            var boeken = await _boekLogica.NeemAlleBoeken();
            return View(new BoekLijstVM { Boeken = boeken });
        }

        public async Task<ActionResult> Toevoegen()
        {
            var genres = await _genreLogica.NeemAlleGenres();

            return View(new BoekDetailVM
            {
                Genres = new MultiSelectList(genres, "Id", "Omschrijving"),
                GenreIds = genres.Select(g => g.Id).Take(1).ToList()
            });
        }

        [HttpPost]
        public async Task<ActionResult> Toevoegen(BoekDetailVM vm)
        {
            var nieuwBoek = new Boek
            {
                Titel = vm.Titel,
                Auteur = vm.Auteur,
                AantalPaginas = vm.AantalPaginas,
                Genres = new List<Genre>()
            };

            foreach (var genreId in vm.GenreIds)
            {
                nieuwBoek.Genres.Add(await _genreLogica.GeefGenre(genreId));
            }

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

                Genres = new MultiSelectList(genres, "Id", "Omschrijving"),
                GenreIds = boek.Genres.Select(g => g.Id).ToList()


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

            await _boekLogica.WijzigBoek(boek, vm.GenreIds);
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Verwijderen(Int32 code)
        {
            await _boekLogica.VerwijderBoek(code);
            return RedirectToAction("Index");
        }

    }
}
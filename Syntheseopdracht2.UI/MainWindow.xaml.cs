using Microsoft.Practices.Unity;
using Syntheseopdracht2.BL;
using Syntheseopdracht2.UI.Unity;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Syntheseopdracht2.Model;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Syntheseopdracht2.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private readonly UnityContainer _diContainer = new UnityContainer();

        private readonly IGenreLogica _genreLogica;
        private readonly IBoekLogica _boekLogica;

        public MainWindow()
        {
            InitializeComponent();

            _diContainer.AddExtension(new UnityPresentatieConfiguratie());
            _genreLogica = _diContainer.Resolve<IGenreLogica>();
            _boekLogica = _diContainer.Resolve<IBoekLogica>();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            await LijstenUpdaten();
        }

        private async Task LijstenUpdaten()
        {
            lsbGenre.ItemsSource = await _genreLogica.NeemAlleGenres();
            lsbBoeken.ItemsSource = await _boekLogica.NeemAlleBoeken();
        }


        private async void btnBoekToevoegen_Click(object sender, RoutedEventArgs e)
        {
            if (IsGeldigBoek())
            {
                Boek boek = new Boek()
                {
                    Titel = txtTitel.Text,
                    Auteur = txtAuteur.Text,
                    AantalPaginas = Convert.ToInt32(txtAantalPaginas.Text),
                    Genres = new List<Genre>()
                };

                boek.Genres = NeemGeselecteerdeGenres();

               await _boekLogica.BewaarBoek(boek);
               await LijstenUpdaten();
            }
            else
            {
                MessageBox.Show("Controleer of je alle velden correct hebt ingevuld.", "Fout tijdens bewaren van het boek", MessageBoxButton.OK, MessageBoxImage.Error);
            }


        }

        private async void btnBoekBewerken_Click(object sender, RoutedEventArgs e)
        {

            var geselecteerdBoek = lsbBoeken.SelectedItem as Boek;

            if (geselecteerdBoek!= null)
            {
                geselecteerdBoek.AantalPaginas = Convert.ToInt32(txtAantalPaginas.Text);
                geselecteerdBoek.Auteur = txtAuteur.Text;
                geselecteerdBoek.Titel = txtTitel.Text;
                geselecteerdBoek.Genres = NeemGeselecteerdeGenres();
            }



            //if (true)
            //{
            //    await _boekLogica.WijzigBoek(geselecteerdBoek);

            //}
            //else
            //{
            //    MessageBox.Show("Het lijkt erop dat een andere collega het boek, dat u wenste te bewerken, heeft verwijderd.", "Fout tijdens bewerken van het boek.", MessageBoxButton.OK, MessageBoxImage.Error);
            //}



            await LijstenUpdaten();

        }

        private async void btnBoekVerwijderen_Click(object sender, RoutedEventArgs e)
        {
            var geselecteerdBoek = lsbBoeken.SelectedItem as Boek;
            if (geselecteerdBoek != null)
            {
                await _boekLogica.VerwijderBoek(geselecteerdBoek);
                await LijstenUpdaten();
            }
        }

        private void lsbBoeken_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            var geselecteerdBoek = lsbBoeken.SelectedItem as Boek;

            if (geselecteerdBoek != null)
            {
                txtAantalPaginas.Text = geselecteerdBoek.AantalPaginas.ToString();
                txtAuteur.Text = geselecteerdBoek.Auteur;
                txtTitel.Text = geselecteerdBoek.Titel;

                lsbGenre.SelectedItems.Clear();

                foreach (var genre in geselecteerdBoek.Genres)
                {
                    foreach (var item in lsbGenre.Items.Cast<Genre>())
                    {
                        if (item.Id == genre.Id)
                        {
                            lsbGenre.SelectedItems.Add(item);
                        }
                    }
                }
            }

        }

        private void MaakVeldenLeeg()
        {
            txtTitel.Text = "";
            txtAuteur.Text = "";
            txtAantalPaginas.Text = "";
            lsbGenre.SelectedItems.Clear();
        }

        public bool IsGeldigBoek()
        {
            if (string.IsNullOrEmpty(txtTitel.Text))
            {
                return false;
            }

            if (string.IsNullOrEmpty(txtAuteur.Text))
            {
                return false;
            }

            if (string.IsNullOrEmpty(txtAantalPaginas.Text))
            {
                return false;
            }

            try
            {
                Convert.ToInt32(txtAantalPaginas.Text);
            }
            catch (Exception)
            {
                return false;
            }

            return true;

        }

        public List<Genre> NeemGeselecteerdeGenres()
        {
            return lsbGenre.SelectedItems.Cast<Genre>().ToList();
        }
    }
}

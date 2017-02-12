using Microsoft.Practices.Unity;
using Syntheseopdracht2.BL;
using Syntheseopdracht2.UI.Unity;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Syntheseopdracht2.Model;
using System;
using System.Collections.Generic;

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


        private void btnBoekToevoegen_Click(object sender, RoutedEventArgs e)
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

            }



        }

        private void btnBoekBewerken_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnBoekVerwijderen_Click(object sender, RoutedEventArgs e)
        {

        }

        private void lsbBoeken_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

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

    }
}

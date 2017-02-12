using Microsoft.Practices.Unity;
using Syntheseopdracht2.BL;
using Syntheseopdracht2.UI.Unity;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Syntheseopdracht2.Model;

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


    }
}

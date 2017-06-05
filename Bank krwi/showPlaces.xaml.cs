using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Bank_krwi
{
    /// <summary>
    /// Interaction logic for showPlaces.xaml
    /// </summary>
    public partial class ShowPlaces : Window
    {
        public ShowPlaces()
        {
            InitializeComponent();
        }

        private void GizyckoButtonClick(object sender, RoutedEventArgs e)
        {

            TargerPlaces tarPlace = new TargerPlaces(3);
            tarPlace.Show();
        }

        private void DzialdowoButtonClick(object sender, RoutedEventArgs e)
        {
            TargerPlaces tarPlace = new TargerPlaces(2);
            tarPlace.Show();
        }

        private void OlsztynButtonClick(object sender, RoutedEventArgs e)
        {
            TargerPlaces tarPlace = new TargerPlaces(1);
            tarPlace.Show();
        }
    }
}

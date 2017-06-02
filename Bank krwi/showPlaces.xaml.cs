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
    public partial class showPlaces : Window
    {
        public showPlaces()
        {
            InitializeComponent();
        }

        private void gizyckoButton_Click(object sender, RoutedEventArgs e)
        {

            targerPlaces tarPlace = new targerPlaces(3);
            tarPlace.Show();
        }

        private void dzialdowoButton_Click(object sender, RoutedEventArgs e)
        {
            targerPlaces tarPlace = new targerPlaces(2);
            tarPlace.Show();
        }

        private void olsztynButton_Click(object sender, RoutedEventArgs e)
        {
            targerPlaces tarPlace = new targerPlaces(1);
            tarPlace.Show();
        }
    }
}

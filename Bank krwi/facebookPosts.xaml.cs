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
    /// Interaction logic for facebookPosts.xaml
    /// </summary>
    public partial class facebookPosts : Window
    {
        public facebookPosts(FacebookPost fbook)
        {
            InitializeComponent();
            PostGrid.DataContext = fbook;
        }
    }
}

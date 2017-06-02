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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.CSharp;
using System.Data;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using System.Threading;
using Bank_krwi.Authors;

namespace Bank_krwi
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            newUser newUser = new newUser();
            newUser.Show();
          //  this.Close();

           
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            showPlaces showPlaces = new showPlaces();
            showPlaces.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
           /* showUser showUser = new showUser();
            showUser.Show();*/
            showGroup showGroup = new showGroup();
            showGroup.Show();
           

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            string token = getToken();
            var request = (HttpWebRequest)WebRequest.Create("https://graph.facebook.com/v2.9/wetbankkrwi/feed?access_token=" + token);
            var response = (HttpWebResponse)request.GetResponse();
            FacebookPost fbPost = getFacebookPost(response);
            facebookPosts facebookPost = new facebookPosts(fbPost);
            facebookPost.Show();
        }

        private string getToken()
        {
            var tokenRequest = (HttpWebRequest)WebRequest.Create("https://graph.facebook.com/v2.9/oauth/access_token?client_id=1066391300160675&client_secret=529c6b46acc37b676b6bc438c7691291&grant_type=client_credentials");
            var tokenResponse = (HttpWebResponse)tokenRequest.GetResponse();
            var responseTokenString = new StreamReader(tokenResponse.GetResponseStream()).ReadToEnd();
            dynamic y = JsonConvert.DeserializeObject(responseTokenString);

            return y.access_token;
        }

        private FacebookPost getFacebookPost(HttpWebResponse response)
        {
            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
            dynamic x = JsonConvert.DeserializeObject(responseString);
            var data = x.data;
            string message = data[0].message;
            string created_time = data[0].created_time;
            string id = data[0].id;
            FacebookPost fbPost = new FacebookPost(created_time, message, id);
            return fbPost;
        }

        private void authorsBtn_Click(object sender, RoutedEventArgs e) {
            List<Author> listaAutorow = AuthorsSingleton.Instance.listaAutorow;
            StringBuilder sb = new StringBuilder();
            sb.Append("Autorzy:");
            sb.Append(Environment.NewLine);
            sb.Append(Environment.NewLine);
            foreach(Author author in listaAutorow) {
                sb.Append(author.Imie + " " + author.Nazwisko + ", grupa: " + author.Grupa);
                sb.Append(Environment.NewLine);
            }
            MessageBox.Show(sb.ToString());
        }
    }
}

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



        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            NewUser newUser = new NewUser();
            newUser.Show();
          //  this.Close();

           
        }

        private void ButtonClick_1(object sender, RoutedEventArgs e)
        {
            ShowPlaces showPlaces = new ShowPlaces();
            showPlaces.Show();
        }

        private void ButtonClick2(object sender, RoutedEventArgs e)
        {
           /* showUser showUser = new showUser();
            showUser.Show();*/
            ShowGroup showGroup = new ShowGroup();
            showGroup.Show();
           

        }

        private void ButtonClick3(object sender, RoutedEventArgs e)
        {
            string token = GetToken();
            var request = (HttpWebRequest)WebRequest.Create("https://graph.facebook.com/v2.9/wetbankkrwi/feed?access_token=" + token);
            var response = (HttpWebResponse)request.GetResponse();
            FacebookPost fbPost = GetFacebookPost(response);
            FacebookPosts facebookPost = new FacebookPosts(fbPost);
            facebookPost.Show();
        }

        private string GetToken()
        {
            var tokenRequest = (HttpWebRequest)WebRequest.Create("https://graph.facebook.com/v2.9/oauth/access_token?client_id=1066391300160675&client_secret=529c6b46acc37b676b6bc438c7691291&grant_type=client_credentials");
            var tokenResponse = (HttpWebResponse)tokenRequest.GetResponse();
            var responseTokenString = new StreamReader(tokenResponse.GetResponseStream()).ReadToEnd();
            dynamic y = JsonConvert.DeserializeObject(responseTokenString);

            return y.access_token;
        }

        private FacebookPost GetFacebookPost(HttpWebResponse response)
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

        private void AuthorsButtonClick(object sender, RoutedEventArgs e) {
            List<Author> listaAutorow = AuthorsSingleton.Instance.AuthorList;
            StringBuilder sb = new StringBuilder();
            sb.Append("Autorzy:");
            sb.Append(Environment.NewLine);
            sb.Append(Environment.NewLine);
            foreach(Author author in listaAutorow) {
                sb.Append(author.FirstName + " " + author.Surname + ", grupa: " + author.BloodGr);
                sb.Append(Environment.NewLine);
            }
            MessageBox.Show(sb.ToString());
        }
    }
}

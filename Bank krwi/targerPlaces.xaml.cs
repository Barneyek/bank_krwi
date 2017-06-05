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
using System.Data.SQLite;
using System.Data;

namespace Bank_krwi {
    /// <summary>
    /// Interaction logic for targerPlaces.xaml
    /// </summary>
    public partial class TargerPlaces : Window {
        public SQLiteDataAdapter m_oDataAdapter = null;
        public DataSet m_oDataSet = null;
        public DataTable m_oDataTable = null;
        string street, city;

        public TargerPlaces(int id) {
            InitializeComponent();
            InitBinding(id);
            SearchPlace(id);
        }

        private void InitBinding(int id) {
            SQLiteConnection oSQLiteConnection =
                new SQLiteConnection("Data Source=BazaDanych.s3db");
            SQLiteCommand oCommand = oSQLiteConnection.CreateCommand();

            // oCommand.CommandText = "SELECT * FROM Person WHERE BloodGroup = "+'"+group+"'";
            oCommand.CommandText = "SELECT * FROM Places WHERE Id = " + id;
            m_oDataAdapter = new SQLiteDataAdapter(oCommand.CommandText,
                oSQLiteConnection);
            SQLiteCommandBuilder oCommandBuilder =
                new SQLiteCommandBuilder(m_oDataAdapter);
            m_oDataSet = new DataSet();
            m_oDataAdapter.Fill(m_oDataSet);
            m_oDataTable = m_oDataSet.Tables[0];
            ShowPlaceList.DataContext = m_oDataTable.DefaultView;


        }

        private void SearchPlace(int id) {

            if(id == 1) {
                street = "Malborska 2";
                city = "Olsztyn";
            }
            if(id == 2) {
                street = "Lesna 1";
                city = "Działdowo";
            }
            if(id == 3) {
                street = "Giżycko";
                city = "Bohaterów Westerplatte 4";
            } 

            try {
                StringBuilder queryadress = new StringBuilder();
                queryadress.Append("http://maps.google.com/maps?q=");

                if(street != string.Empty) {
                    queryadress.Append(street + "," + "+");
                }
                if(city != string.Empty) {
                    queryadress.Append(city + "," + "+");
                }

                webBrowser.Navigate(queryadress.ToString());
            } catch(Exception ex) {

                MessageBox.Show(ex.Message.ToString(), "Error");
            }
        }

    }
}

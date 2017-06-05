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


namespace Bank_krwi
{
    /// <summary>
    /// Interaction logic for showUser.xaml
    /// </summary>
    public partial class ShowUser : Window
    {
     //   private List<ShowUserClass> m_oPersonList = null;

        public SQLiteDataAdapter m_oDataAdapter = null;
        public DataSet m_oDataSet = null;
        public DataTable m_oDataTable = null;


        public ShowUser(string group)
        {
            InitializeComponent();
            InitBinding(group);

        }

        private void InitBinding(string group)
        {
            SQLiteConnection oSQLiteConnection =
                new SQLiteConnection("Data Source=BazaDanych.s3db");
            SQLiteCommand oCommand = oSQLiteConnection.CreateCommand();

           // oCommand.CommandText = "SELECT * FROM Person WHERE BloodGroup = "+'"+group+"'";
                oCommand.CommandText = "SELECT * FROM Person WHERE BloodGroup = '"+group+"'";
            m_oDataAdapter = new SQLiteDataAdapter(oCommand.CommandText,
                oSQLiteConnection);
            SQLiteCommandBuilder oCommandBuilder =
                new SQLiteCommandBuilder(m_oDataAdapter);
            m_oDataSet = new DataSet();
            m_oDataAdapter.Fill(m_oDataSet);
            m_oDataTable = m_oDataSet.Tables[0];
            ShowUserList.DataContext = m_oDataTable.DefaultView;

            //   0Rh− 	0Rh+ 	BRh− 	BRh+ 	ARh− 	ARh+ 	ABRh− 	ABRh+

        }

    }
}

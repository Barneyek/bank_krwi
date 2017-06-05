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
using System.Text.RegularExpressions;

namespace Bank_krwi {
    /// <summary>
    /// Interaction logic for newUser.xaml
    /// </summary>
    public partial class NewUser : Window {
        private SQLiteDataAdapter m_oDataAdapter = null;
        private DataSet m_oDataSet = null;
        private DataTable m_oDataTable = null;

        private IDonatorValidation donatorValidation = new DonatorValidationImplentation();

        public NewUser() {
            InitializeComponent();
            InitBinding();  
        }

        private void InitBinding() {
            SQLiteConnection oSQLiteConnection =
                new SQLiteConnection("Data Source=BazaDanych.s3db");
            SQLiteCommand oCommand = oSQLiteConnection.CreateCommand();
            oCommand.CommandText = "SELECT * FROM Person";
            m_oDataAdapter = new SQLiteDataAdapter(oCommand.CommandText,
                oSQLiteConnection);
            SQLiteCommandBuilder oCommandBuilder =
                new SQLiteCommandBuilder(m_oDataAdapter);
            m_oDataSet = new DataSet();
            m_oDataAdapter.Fill(m_oDataSet);
            m_oDataTable = m_oDataSet.Tables[0];
            lstItems.DataContext = m_oDataTable.DefaultView;
        }

        private void ButtonAddClick(object sender, RoutedEventArgs e) {
            string firstName = firstNameBox.Text;
            string surname = surnameBox.Text;
            string age = ageBox.Text;
            string bloodGr = comboGr.Text;
            string sex = sexBox.Text;
            string address = addressBox.Text;
            string phoneNumber = phoneNumberBox.Text;
            string amountOfBlood = amountOfBloodBox.Text;

            if(!amountOfBlood.All(char.IsDigit)) {
                throw new FormatException("Ilość musi być cyfrą całkowitą");
            }

            Donator donator = new Donator(firstName, surname, Int32.Parse(String.IsNullOrEmpty(age) ? "0" : age), bloodGr, sex, address, Int32.Parse(String.IsNullOrEmpty(phoneNumber) ? "0" : phoneNumber), amountOfBlood);
            AddDonator(donator);
            InitBinding();
        }

        private void AddDonator(Donator donator) {

            try {
                donatorValidation.AddDonatorValidate(donator);
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
                return;
            }
            
            DataRow oDataRow = m_oDataTable.NewRow();
            oDataRow[1] = donator.FirstName;
            oDataRow[2] = donator.Surname;
            oDataRow[3] = donator.Age;
            oDataRow[4] = donator.BloodGr;
            oDataRow[5] = donator.Sex;
            oDataRow[6] = donator.Address;
            oDataRow[7] = donator.PhoneNumber;
            oDataRow[8] = donator.AmountOfBlood;
            oDataRow[9] = "BRAK";
            m_oDataTable.Rows.Add(oDataRow);
            m_oDataAdapter.Update(m_oDataSet);
}

        private void EditDonator(Donator donator) {
            donatorValidation.AddDonatorValidate(donator);

            DataRow oDataRow = m_oDataTable.NewRow();
            oDataRow[0] = m_oDataTable.Rows.Count + 1;
            oDataRow[1] = donator.FirstName;
            oDataRow[2] = donator.Surname;
            oDataRow[3] = donator.Age;
            oDataRow[4] = donator.BloodGr;
            oDataRow[5] = donator.Sex;
            oDataRow[6] = donator.Address;
            oDataRow[7] = donator.PhoneNumber;
            oDataRow.EndEdit();
            m_oDataAdapter.Update(m_oDataSet);
        }

        private void ButtonEditClick(object sender, RoutedEventArgs e) {
            string firstName = firstNameBox.Text;
            string surname = surnameBox.Text;
            string age = ageBox.Text;
            string bloodGr = comboGr.Text;
            string sex = sexBox.Text;
            string address = addressBox.Text;
            string phoneNumber = phoneNumberBox.Text;
            string amountOfBlood = amountOfBloodBox.Text;

            if(!amountOfBlood.All(char.IsDigit)) {
                throw new FormatException("Ilość musi być cyfrą całkowitą");
            }

            if(0 == lstItems.SelectedItems.Count) {
                return;
            }
            DataRow oDataRow = ((DataRowView)lstItems.SelectedItem).Row;
            oDataRow.BeginEdit();
            oDataRow[1] = firstName;
            oDataRow[2] = surname;
            oDataRow[3] = age;
            oDataRow[4] = bloodGr;
            oDataRow[5] = sex;
            oDataRow[6] = address;
            oDataRow[7] = phoneNumber;
            oDataRow[8] = amountOfBlood;
            oDataRow[9] = "BRAK";
            oDataRow.EndEdit();
            m_oDataAdapter.Update(m_oDataSet);
        }


        private void ButtonDeleteClick(object sender, RoutedEventArgs e) {
            if(0 == lstItems.SelectedItems.Count) {
                return;
            }
            DataRow oDataRow = ((DataRowView)lstItems.SelectedItem).Row;
            oDataRow.Delete();
            m_oDataAdapter.Update(m_oDataSet);
        }

        private void WindowClosing(object sender,
            System.ComponentModel.CancelEventArgs e) {
        }

        private void ComboBoxLoaded(object sender, RoutedEventArgs e) {
            List<string> data = new List<string>();
            data.Add("Wybierz");
            data.Add("0Rh-");
            data.Add("0Rh+");
            data.Add("ARh-");
            data.Add("ARh+");
            data.Add("BRh-");
            data.Add("BRh+");
            data.Add("ABRh-");
            data.Add("ABRh+");
            var combo = sender as ComboBox;
            combo.ItemsSource = data;
            combo.SelectedIndex = 0;
        }

        private void ComboBoxSelectionChanged(object sender, SelectionChangedEventArgs e) {

        }

        private void TextBoxTextChanged(object sender, TextChangedEventArgs e) {

        }

        private void AddBloodButtonClick(object sender, RoutedEventArgs e) {
            string addBlood = bloodToGive.Text;

            if(String.IsNullOrWhiteSpace(addBlood) || addBlood.All(char.IsDigit)) { // sprawdzamy, czy uzytkownik wpisal jakaś wartość i czy wszystkie znaki są cyfrą 
                if(0 == lstItems.SelectedItems.Count) { // Jeżeli nie wybrano zadnego dawcy - nie rob nic
                    return;
                }

                DataRow oDataRow = ((DataRowView)lstItems.SelectedItem).Row; //wybiera obiekt z listy i zamienia go na typ DataRowView
                oDataRow.BeginEdit();
                oDataRow[8] = Convert.ToInt32(oDataRow[8]) + Int32.Parse(addBlood); // Dodaje wpisana ilosc do ogolnej wartosci krwi

                int amountOfBlood = Convert.ToInt32(oDataRow[8]);
                try {
                    var test = (string)oDataRow[9];
                } catch (Exception exception) {
                    oDataRow[9] = "BRAK";
                }
                if(amountOfBlood >= 5800 && (string)oDataRow[9] == "BRAK") {
                    MessageBox.Show(oDataRow[1] + " " + oDataRow[2] + " uzyskał odznakę brązową!");
                    oDataRow[9] = "BRAZAWA";
                } else if(amountOfBlood >= 12000 && ((string)oDataRow[9] == "BRAZAWA" || (string)oDataRow[9] == "BRAK")) {
                    MessageBox.Show(oDataRow[1] + " " + oDataRow[2] + " uzyskał odznakę srebrną!");
                    oDataRow[9] = "SREBRNA";
                } else if(amountOfBlood >= 20000 && ((string)oDataRow[9] == "SREBRNA" || (string)oDataRow[9] == "BRAZAWA" || (string)oDataRow[9] == "BRAK")) {
                    MessageBox.Show(oDataRow[1] + " " + oDataRow[2] + " uzyskał odznakę złotą!");
                    oDataRow[9] = "ZLOTA";
                }

                oDataRow.EndEdit();
                m_oDataAdapter.Update(m_oDataSet); // zapisuje do bazy
                bloodToGive.Clear();
            } else {
                throw new FormatException("Ilość musi być cyfrą całkowitą");
            }
        }

        private void lstItemsSelectionChanged(object sender, SelectionChangedEventArgs e) {
            DataRowView index = (DataRowView)lstItems.SelectedItem; //wybiera obiekt z listy i zamienia go na typ DataRowView
            if(index == null) { // Jeżeli nie znaleziono indeksu, to powróć(nie wykonuj reszty kodu)
                return;
            }

            object[] selectedItemData = index.Row.ItemArray; // pobiera wszystkie dane z danego wiersza i przypisuje je do tablicy obiektow

            firstNameBox.Text = (string)selectedItemData[1];
            surnameBox.Text = (string)selectedItemData[2];
            ageBox.Text = (string)selectedItemData[3];
            comboGr.SelectedItem = (string)selectedItemData[4];
            sexBox.Text = (string)selectedItemData[5];
            addressBox.Text = (string)selectedItemData[6];
            phoneNumberBox.Text = (string)selectedItemData[7];
            amountOfBloodBox.Text = ((long)selectedItemData[8]).ToString();
        }
    }
}

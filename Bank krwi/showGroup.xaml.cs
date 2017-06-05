using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Bank_krwi
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class ShowGroup : Window
    {
        private List<Donator> donators = new List<Donator>();

        public ShowGroup()
        {
            InitializeComponent();
        }

        private void Click0Rh0(object sender, RoutedEventArgs e)
        {
            string a = "0Rh-";
            ShowUser showUser = new ShowUser(a);
            ReadDonators(showUser);
            showUser.Show();
        }

        private void Click0Rh1(object sender, RoutedEventArgs e)
        {
            string a = "0Rh+";
            ShowUser showUser = new ShowUser(a);
            ReadDonators(showUser);
            showUser.Show();
        }

        private void ClickBRh1(object sender, RoutedEventArgs e)
        {
            string a = "BRh+";
            ShowUser showUser = new ShowUser(a);
            ReadDonators(showUser);
            showUser.Show();
        }

        private void ClickBRh0(object sender, RoutedEventArgs e)
        {
            string a = "BRh-";
            ShowUser showUser = new ShowUser(a);
            ReadDonators(showUser);
            showUser.Show();

        }

        private void ClickARh1(object sender, RoutedEventArgs e)
        {
            string a = "ARh+";
            ShowUser showUser = new ShowUser(a);
            ReadDonators(showUser);
            showUser.Show();
        }

        private void ClickARh0(object sender, RoutedEventArgs e)
        {
            string a = "ARh-";
            ShowUser showUser = new ShowUser(a);
            ReadDonators(showUser);
            showUser.Show();

        }

        private void ClickABRh1(object sender, RoutedEventArgs e)
        {
            string a = "ABRh+";
            ShowUser showUser = new ShowUser(a);
            ReadDonators(showUser);
            showUser.Show();
        }

        private void ClickABRh0(object sender, RoutedEventArgs e)
        {
            string a = "ABRh-";
            ShowUser showUser = new ShowUser(a);
            ReadDonators(showUser);
            showUser.Show();
        }

        /// <summary>
        /// Zapisuje wszystkich dawców krwi do listy
        /// </summary>
        /// <param name="showUser">dane o wybranych dawcach</param>
        private void ReadDonators(ShowUser showUser) {
            donators.Clear();
            //for po wszystkich kolumnach z showUser
            for(int i = 0; i < showUser.m_oDataTable.Rows.Count; i++) {
                //dane o konkretnym dawcy jako lista obiektów
                var zawartoscTabeli = showUser.m_oDataTable.Rows[i].ItemArray;

                var imie = zawartoscTabeli[1].ToString();
                var nazwisko = zawartoscTabeli[2].ToString();
                //jeżeli podczas parsowania wystąpi błąd(np to nie jest liczba), to przypisuje wiek jako 0
                int wiek;
                try {
                    wiek = Int32.Parse(zawartoscTabeli[3].ToString());
                } catch(System.FormatException) {
                    wiek = 0;
                }
                var grupaKrw = zawartoscTabeli[4].ToString();
                var plec = zawartoscTabeli[5].ToString();
                var adres = zawartoscTabeli[6].ToString();
                int telefon;
                try {
                    telefon = Int32.Parse(zawartoscTabeli[7].ToString());
                } catch(System.FormatException) {
                    telefon = 0;
                }
                var iloscKrwii = zawartoscTabeli[8].ToString();

                try {
                    Donator donator = new Donator(imie, nazwisko, wiek, grupaKrw, plec, adres, telefon, iloscKrwii);
                    donators.Add(donator);
                } catch (Exception ex) {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void BpdfClick(object sender, RoutedEventArgs e)
        {
            try {
                Document doc = new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35);
                PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream("Test.pdf", FileMode.Create));
                doc.Open(); // otworz dokument
                            //Zaawartosc dokumentu
                if(donators.Count() > 0) {
                    foreach(var donator in donators) {
                        doc.Add(CreateParagraphFromDonator(donator));
                    }
                } else {
                    doc.Add(new Paragraph("Brak danych"));
                }


                doc.Close();
            } catch (Exception ex) {
                MessageBox.Show("Nie udało się wygenerować PDF");
            }
        }
       
        private Paragraph CreateParagraphFromDonator(Donator donator) {
            String paragraphText = "";
            paragraphText += donator.Imie + " ";
            paragraphText += donator.Nazwisko + " ";
            paragraphText += donator.Wiek + " ";
            paragraphText += donator.GrupaKrw + " ";
            paragraphText += donator.Plec + " ";
            paragraphText += donator.Adres + " ";
            paragraphText += donator.Telefon + " ";
            paragraphText += donator.IloscOddanejKrwi + " ";

            return new Paragraph(paragraphText);
        }
    }
}

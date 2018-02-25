using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows.Forms;

namespace SPOZ
{
    public partial class Aktualizacja : Form
    {
        public static DialogResult instalacja = DialogResult.No;
        public static string Aktualizacja_setup = null, Aktualizacja_FTP = null;
        public static double WERJSA__FTP;
        public static double POSIADANA =                        0.071; //TODO## Aktualna wersja

        public Aktualizacja()
        {
            InitializeComponent();
            Pobieranie_listy_zmian(richTextBox1);
        }                         

        private void Ladowanie_okna_Aktualizacja(object sender, EventArgs e)
        {
            Size = new Size(490, 200);
            richTextBox1.Visible = false;
            if (File.Exists(Sciezki.aktualizacje + @"\Setup_SPOZ_" + WERJSA__FTP + ".exe"))            
                label2.Text = "Chcesz teraz zainstalować aktualizację " + WERJSA__FTP + "?";            
            else
                label2.Text = "Chcesz teraz pobrać aktualizację " + WERJSA__FTP + "?";            
        }

        public static void Sprawdzenie_wersji()
        {
            try
            {
                WebRequest prosba = WebRequest.Create("http://spoz.pl/pub/app/Aktualna_wersja.txt");
                prosba.Credentials = CredentialCache.DefaultCredentials;
                HttpWebResponse odpowiedz = (HttpWebResponse)prosba.GetResponse();
                Stream stream = odpowiedz.GetResponseStream();
                StreamReader odczyt = new StreamReader(stream);
                WERJSA__FTP = Convert.ToDouble(odczyt.ReadToEnd());
                Aktualizacja_setup = Sciezki.aktualizacje + @"\Setup_SPOZ_" + WERJSA__FTP + ".exe";
                Aktualizacja_FTP = "http://spoz.pl/pub/app/Setup_SPOZ_" + WERJSA__FTP + ".exe";
            }
            catch (Exception)
            {
                MessageBox.Show("Nie można połączyć się z serwerem aktualizacji.", "Aktualizacja SPOZ", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            }
        }

        public void Pobieranie_listy_zmian(RichTextBox RTB)
        {
            try
            {
                WebRequest prosba = WebRequest.Create("http://spoz.pl/pub/app/Lista_zmian.txt");
                prosba.Credentials = CredentialCache.DefaultCredentials;
                HttpWebResponse odpowiedz = (HttpWebResponse)prosba.GetResponse();
                Stream stream = odpowiedz.GetResponseStream();
                StreamReader odczyt = new StreamReader(stream);
                string zmiany = Convert.ToString(odczyt.ReadToEnd());
                int ile = zmiany.IndexOf("\n-");
                zmiany = zmiany.Substring(0, ile);
                RTB.Text = zmiany;
            }
            catch (Exception ) { }
        }

        private void Nie_Click(object sender, EventArgs e)
        {
            Okno_glowne.Akt_pytanie = DialogResult.No;
            Close();
        }

        private void Tak_Click(object sender, EventArgs e)
        {
            Pobieranie_aktualizacji();
            Tak.Enabled = false;
            Nie.Enabled = false;
            //Zmiana rozmiaru okna dla progress bar
            postep_pobierania.Visible = true;
            if (Szczegoly.Text == "Ukryj szczegóły")
                Size = new Size(490, 355);
            if (Szczegoly.Text == "Pokaż szczegóły")
                Size = new Size(490, 230);
            if (File.Exists(Sciezki.aktualizacje + @"\Setup_SPOZ_" + WERJSA__FTP + ".exe") && label2.Text == "Chcesz teraz zainstalować aktualizację " + WERJSA__FTP + "?")
                Environment.Exit(0);
        }

        private void Szczegoly_Click(object sender, EventArgs e)
        {
            if (Szczegoly.Text == "Pokaż szczegóły")
            {
                Szczegoly.Text = "Ukryj szczególy";
                richTextBox1.Visible = true;
                Size = new Size(490, 355);
            }
            else if (Szczegoly.Text == "Ukryj szczególy")
            {
                Szczegoly.Text = "Pokaż szczegóły";
                richTextBox1.Visible = false;
                Size = new Size(490, 230);
            }
        }

        public void Pytanie_czy_zaktualizowac()
        {
            Kultura.Kropka();
            Sprawdzenie_wersji();
            if (POSIADANA < WERJSA__FTP)
            {
                Okno_glowne.aktualizacja.ShowInTaskbar=true;
                Okno_glowne.aktualizacja.Show();
            }
        }

        public void Pobieranie_aktualizacji()
        { 
            try
            {
                WebClient client = new WebClient();

                if (!File.Exists(Aktualizacja_setup))
                {
                    client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(Klient_pobieranie);
                    client.DownloadFileAsync(new Uri(Aktualizacja_FTP), Aktualizacja_setup);//pobieranie
                    client.DownloadFileCompleted += new AsyncCompletedEventHandler(Ukonczono_pobieranie);//Pobieranie zakończone
                }
                else
                    Process.Start(Aktualizacja_setup);                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Pobieranie_aktualizacji");
            }
        }

        public void Klient_pobieranie(object sender, DownloadProgressChangedEventArgs e)
        {
            postep_pobierania.Maximum = (int)e.TotalBytesToReceive;
            postep_pobierania.Value = (int)e.BytesReceived;
        }

        public void Ukonczono_pobieranie(object sender, AsyncCompletedEventArgs e)
        {
            instalacja = (MessageBox.Show("Chcesz teraz zainstalować aktualizację?", "Pobieranie zakończone", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1));
            if (instalacja == DialogResult.Yes)
            {
                Process.Start(Aktualizacja_setup);
                Environment.Exit(0);
            }
            else if (instalacja == DialogResult.No)
            {
                try
                {
                    Okno_glowne.aktualizacja.Close();
                    Opcje opcje = Application.OpenForms.OfType<Opcje>().FirstOrDefault();
                    opcje.button_spr_aktualizacje.Text = "Zainstaluj aktualizację.";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }              
            }
        }

        private void Pelna_lista_zmian_Click(object sender, EventArgs e)
        {
            Lista_zmian Lz = new Lista_zmian();
            Lz.Show();
        }
    }
}
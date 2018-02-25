using System;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace SPOZ
{
    public partial class Logowanie : Form
    {
        Okno_glowne okno_Glowne;

        public Logowanie(Okno_glowne okno_glowne)
        {
            InitializeComponent();

            okno_Glowne = okno_glowne;
            okno_Glowne.Opacity = 0;
            okno_Glowne.ShowInTaskbar = false;
            if (Properties.Settings.Default.ostatnio_zalogowany != "")
                textBox_mail.Text = Properties.Settings.Default.ostatnio_zalogowany;
        }

        private void Logowanie_Load(object sender, EventArgs e)
        {}

        bool zamykanie = false;
        private void PictureBox1_Click(object sender, EventArgs e)
        {
            zamykanie = true;
            Environment.Exit(0);          
        }

        public static bool zalogowany = false;
        private void PictureBox_zaloguj_Click(object sender, EventArgs e)
        {
            Log();
        }

        private void TextBox_haslo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                Log();
            }
        }
        
        private void Log()
        {
            if (Metody_bazy.Czy_mail_jest_w_bazie(textBox_mail) == true)
            {
                if (Metody_bazy.Czy_pierwsze_logowanie(textBox_mail) == false)
                {
                    if (Metody_bazy.Logowanie_do_programu(textBox_mail, textBox_haslo) == true)
                    {
                        okno_Glowne.Opacity = 100;
                        Opacity = 0;
                        okno_Glowne.ShowInTaskbar = true;
                        okno_Glowne.BringToFront();
                        okno_Glowne.label_uzytkownik.Text = "Zalogowano jako: " + Metody_bazy.imie_nazwisko_uzytkownika;
                        Metody_bazy.Uzupelnij_dataGrid_zamowienia(okno_Glowne.dataGridView_zamowienia, okno_Glowne.dateTimePicker_od.Text, okno_Glowne.dateTimePicker_do.Text, "nr_zamowienia", "DESC");
                        Close();
                    }
                }
                else
                {
                    Zmiana_hasla zhp1l = new Zmiana_hasla();
                    zhp1l.ShowDialog();
                }
            }
            else
                MessageBox.Show("Nie ma takiego użytkownika.", "Logowanie nie powidło się", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static bool przypomnienie_hasla = false;
        private void PictureBox_zapomnialem_hasla_Click(object sender, EventArgs e)
        {
            przypomnienie_hasla = true;
            Generowanie_kodu();
            Thread thr = new Thread(() => Metody_lokalne.Wyslij_kod_resetu(textBox_mail));
            thr.Start();
            Zmiana_hasla zmiana_Hasla = new Zmiana_hasla();
            zmiana_Hasla.ShowDialog();
        }
        public static int kod;

        int Generowanie_kodu()
        {
            Random rand_kod = new Random();
            kod = rand_kod.Next(100000,999999);
            return kod;
        }       


        private void Logowanie_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Aktualizacja.POSIADANA < Aktualizacja.WERJSA__FTP && zamykanie==false)
            {
                Aktualizacja aktu = Application.OpenForms.OfType<Aktualizacja>().FirstOrDefault();
                aktu.ShowInTaskbar = true;
            }
        }
    }
}
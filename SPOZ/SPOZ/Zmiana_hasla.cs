using System;
using System.Linq;
using System.Windows.Forms;

namespace SPOZ
{
    public partial class Zmiana_hasla : Form
    {
        public Zmiana_hasla()
        {
            InitializeComponent();
        }

        private void Zmiana_hasla_przy_1_logowaniu_Load(object sender, EventArgs e)
        {
            if (SPOZ.Logowanie.przypomnienie_hasla==true)
            {
                label_kod.Visible = true ;
                textBox_kod_z_maila.Visible = true ;
            }
            else
            {
                label_kod.Visible = false ;
                textBox_kod_z_maila.Visible = false ;
            }
        }

        Okno_glowne okno_Glowne = Application.OpenForms.OfType<Okno_glowne>().FirstOrDefault();
        Logowanie log = Application.OpenForms.OfType<Logowanie>().FirstOrDefault();

        private void button_zmien_haslo_Click(object sender, EventArgs e)
        {
            if (SPOZ.Logowanie.przypomnienie_hasla == true)
            {
                if (textBox_kod_z_maila.Text == SPOZ.Logowanie.kod.ToString())
                {
                    Metody_bazy.Reset_hasla(textBox_nowe_haslo);
                }
                else
                    MessageBox.Show("Wprowadzony kod różni się od kodu wysłanego na maila.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                Logowanie();

            Close();
           
        }
        void Logowanie()
        {
            if (textBox_nowe_haslo.Text == textBox_nowe_haslo_2.Text)
            {
                if (textBox_nowe_haslo.Text != log.textBox_haslo.Text)
                {
                    Metody_bazy.Zmiana_hasla_1_logowanie(log.textBox_haslo, textBox_nowe_haslo);

                    if (Metody_bazy.Logowanie_do_programu(log.textBox_mail, textBox_nowe_haslo) == true)
                    {
                        okno_Glowne.Opacity = 100;
                        Opacity = 0;
                        okno_Glowne.ShowInTaskbar = true;
                        okno_Glowne.BringToFront();
                        okno_Glowne.ShowIcon = false;
                        okno_Glowne.label_uzytkownik.Text = "Zalogowano jako: " + Metody_bazy.imie_nazwisko_uzytkownika;
                        Metody_bazy.Uzupelnij_dataGrid_zamowienia(okno_Glowne.dataGridView_zamowienia, okno_Glowne.dateTimePicker_od.Text, okno_Glowne.dateTimePicker_do.Text, "nr_zamowienia", "DESC");
                        log.Close();
                        Close();
                    }
                }
                else
                    MessageBox.Show("Nowe hasło nie może być takie samo jak poprzednie.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("Podane hasła nie są jednakowe.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

       
    }
}

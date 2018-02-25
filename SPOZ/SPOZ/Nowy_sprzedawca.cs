using System;
using System.Windows.Forms;

namespace SPOZ
{
    public partial class Nowy_sprzedawca : Form
    {
        public Nowy_sprzedawca()
        {
            InitializeComponent();
            Metody_bazy.Wczytanie_listy_sklepow_do_combobox(comboBox_sklepy);
        }      

        private void button_dodaj_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt16(comboBox_sklepy.Text.Substring(0, comboBox_sklepy.Text.IndexOf(".")));
            if (Metody_bazy.Czy_mail_jest_w_bazie(textBox_mail) == false)
            {
                if (textBox_haslo.Text == textBox_haslo_2.Text)
                {
                    Metody_bazy.Nowy_sprzedawca(textBox_imie, textBox_nazwisko, textBox_mail, textBox_haslo, id);
                }
                else
                {
                    MessageBox.Show("Podane hasła nie są jednakowe.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            else
            {
                MessageBox.Show("Podane adres e-mail jest już w użyciu.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }
    }
}
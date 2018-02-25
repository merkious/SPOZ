using SPOZ.PDF;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SPOZ
{
    public partial class Generowanie_Faktury_Firma : Form
    {
        private DateTimePicker data_rozliczenia;
        public Generowanie_Faktury_Firma()
        {
            InitializeComponent();
        }

        public Generowanie_Faktury_Firma(DateTimePicker data_roz, string kwota)
        {
            InitializeComponent();
            data_rozliczenia = data_roz;
            
        }

        private void button_zapisz_Click(object sender, EventArgs e)
        {
            if (wypelnienie_pol() == true)
            {
                Druk_fv druk = new Druk_fv(data_rozliczenia.Text.ToString(), textBox_nazwa_firmy.Text, maskedTextBox_kod_pocztowy.Text + " " + textBox_miejscowosc.Text, textBox_adres.Text, textBox_nip.Text);
                if (MessageBox.Show("Czy klient potwierdził zgodnosć danych na fakturze? Po zatwierdzeniu nie będzie możliwości Edycji faktury.", "Wymagane potwierdzenie", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Metody_bazy.Rozliczanie_zamowienia_z_menuDGV(data_rozliczenia);
                    Metody_bazy.Dodaj_firme(Sciezki.numer_tworzonej_faktury, textBox_nazwa_firmy.Text, textBox_miejscowosc.Text, maskedTextBox_kod_pocztowy.Text, textBox_adres.Text, textBox_nip.Text);
                    Close();
                }

            }
            else MessageBox.Show("Należy poprawnie wypełnić brakujące pola");
            
        }

        private bool wypelnienie_pol()
        {
            bool wypelnione = true;
            if (textBox_nazwa_firmy.Text.Length<=2)
            {
                textBox_nazwa_firmy.BackColor = Color.IndianRed;
                wypelnione = false;
            }
            if (textBox_miejscowosc.Text.Length <= 2)
            {
                textBox_miejscowosc.BackColor = Color.IndianRed;
                wypelnione = false;
            }
            if (textBox_adres.Text.Length <= 2)
            {
                textBox_adres.BackColor = Color.IndianRed;
                wypelnione = false;
            }
            if (textBox_nip.Text.Length <= 9)
            {
                textBox_nip.BackColor = Color.IndianRed;
                wypelnione = false;
            }
            if (maskedTextBox_kod_pocztowy.MaskCompleted==false)
            {
                maskedTextBox_kod_pocztowy.BackColor = Color.IndianRed;
                wypelnione = false;
            }
            return wypelnione;
        }

        private void button_anuluj_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {
            (sender as TextBox).BackColor = Color.White;
        }

        private void maskedTextBox_kod_pocztowy_TextChanged(object sender, EventArgs e)
        {
            (sender as MaskedTextBox).BackColor = Color.White;
        }
    }
}

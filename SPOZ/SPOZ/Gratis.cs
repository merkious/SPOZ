using System;
using System.Linq;
using System.Windows.Forms;

namespace SPOZ
{
    public partial class Gratis : Form
    {
        Opcje opcje;
        public Gratis()
        {
            InitializeComponent();
            opcje = Application.OpenForms.OfType<Opcje>().FirstOrDefault();

            if (opcje.edycja==true)
            {
                Text = "Edycja gratisu";
                Metody_bazy.Wczytanie_gratisu_do_edycji(opcje.comboBox_gratis);
                textBox_nazwa_gratisu.Text = Metody_bazy.nazwa_gratisu;
                textBox_cena_gratisu.Enabled = false;
                textBox_rabat.Enabled = false;
                textBox_cena_po_rabacie.Enabled = false;
                checkBox1.Visible = true;
                checkBox1.Checked = Metody_bazy.aktywny;
            }
        }

        private void Gratis_Load(object sender, EventArgs e)
        {
          
        }

        private void button_gratis_Click(object sender, EventArgs e)
        {
            if (opcje.edycja == true)
            {
                Metody_bazy.Edycja_gratisu(textBox_nazwa_gratisu, checkBox1 , opcje.comboBox_gratis);
                Close();
            }
            else
                Metody_bazy.Dodaj_gratis(textBox_nazwa_gratisu, textBox_cena_gratisu, textBox_rabat);

            textBox_cena_gratisu.Text = null;
            textBox_nazwa_gratisu.Text = null;
            textBox_rabat.Text = null;
        }

        void Licz_rabat()
        {

            if (textBox_cena_gratisu.Text != "" && textBox_cena_po_rabacie.Text != "")
            {
                decimal cena = Convert.ToDecimal(textBox_cena_gratisu.Text);
                decimal cena_po_rabacie = Convert.ToDecimal(textBox_cena_po_rabacie.Text);
                decimal rabat = (cena - cena_po_rabacie) / cena * 100;
                textBox_rabat.Text = string.Format("{0:N8}", rabat.ToString("N8"));
            }
            else
                textBox_rabat.Text = "0.00000000";
        }
        private void textBox_cena_po_rabacie_KeyUp(object sender, KeyEventArgs e)
        {
            Licz_rabat();
        }

        private void textBox_cena_gratisu_KeyUp(object sender, KeyEventArgs e)
        {
            Licz_rabat();
        }

        private void Gratis_FormClosed(object sender, FormClosedEventArgs e)
        {
            opcje.BringToFront();
        }
    }
}
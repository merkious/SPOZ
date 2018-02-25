using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace SPOZ
{
    public partial class Doplata : Form
    {
        Okno_glowne okno_Glowne;
        public Doplata(Okno_glowne okno_glowne )
        {
            InitializeComponent();
            okno_Glowne = okno_glowne;
            Location = Cursor.Position;
            label_nr_zamowienia.Text = Text = Metody_bazy.biezacy_nr_zamowienia;
        }

        private void Anuluj_Click(object sender, EventArgs e)
        { Close(); }

        private void Doplata_Click(object sender, EventArgs e)
        {
            if (Metody_bazy.Doplata_do_zamowienia_z_menuDGV(textBox_kwota_doplaty, okno_Glowne.dataGridView_zamowienia) == true)
            {
                Metody_bazy.Uzupelnij_dataGrid_zamowienia(okno_Glowne.dataGridView_zamowienia, okno_Glowne.dateTimePicker_od.Text, okno_Glowne.dateTimePicker_do.Text, "nr_zamowienia", "DESC");
                Close();
            }
        }

        private void TextBox_kwota_doplaty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(sender as TextBox).Text.Contains("."))
            {
                Metody_lokalne.Kropka_w_locie((sender as TextBox), e);
            }

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && ((e.KeyChar != '.') || (e.KeyChar != ',')))
            {
                e.Handled = true;
            }

            if (Regex.IsMatch((sender as TextBox).Text, @"\.\d\d") && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }
    }
}

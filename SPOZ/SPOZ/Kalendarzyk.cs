using SPOZ.PDF;
using System;
using System.Windows.Forms;

namespace SPOZ
{
    public partial class Kalendarzyk : Form
    {
        private string kwota_laczna_wybranego_zk;
        Okno_glowne okno_Glowne;
        public Kalendarzyk(Okno_glowne okno_glowne,string kwota_zamowienia)
        {
            InitializeComponent();
            okno_Glowne = okno_glowne;
            kwota_laczna_wybranego_zk = kwota_zamowienia;
            comboBox_fv.SelectedIndex = 0;
            Location = Cursor.Position;
            dateTimePicker_data_rozliczenia.Value = DateTime.Today;
            label_nr_zamowienia.Text = Text =  Metody_bazy.biezacy_nr_zamowienia;
        }

        private void Button2_Click(object sender, EventArgs e)
        {Close();}

        private void Button1_Click(object sender, EventArgs e)
        {            
            if (comboBox_fv.SelectedIndex == 1)
            {
                if (MessageBox.Show("Czy wygenerować fakturę do zamówienia: " + Metody_bazy.biezacy_nr_zamowienia + "? Po zatwierdzeniu nie będzie możliwości Edycji faktury.", "Wymagane potwierdzenie", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Metody_bazy.Rozliczanie_zamowienia_z_menuDGV(dateTimePicker_data_rozliczenia);
                    Druk_fv druk = new Druk_fv(dateTimePicker_data_rozliczenia.Text.ToString());
                    Metody_bazy.Uzupelnij_dataGrid_zamowienia(okno_Glowne.dataGridView_zamowienia, okno_Glowne.dateTimePicker_od.Text.ToString(), okno_Glowne.dateTimePicker_do.Text.ToString(), "nr_zamowienia", "DESC");
                    Close();
                }
                // faktura os prywatna
            }
            else if (comboBox_fv.SelectedIndex == 2)
            {
                Generowanie_Faktury_Firma generuj_fv_firma = new Generowanie_Faktury_Firma(dateTimePicker_data_rozliczenia, kwota_laczna_wybranego_zk);
                this.Visible = false;
                generuj_fv_firma.ShowDialog();
                Metody_bazy.Uzupelnij_dataGrid_zamowienia(okno_Glowne.dataGridView_zamowienia, okno_Glowne.dateTimePicker_od.Text.ToString(), okno_Glowne.dateTimePicker_do.Text.ToString(), "nr_zamowienia", "DESC");
                Close();
                //faktura firma
            }
            else
            {
                Metody_bazy.Rozliczanie_zamowienia_z_menuDGV(dateTimePicker_data_rozliczenia);
                Metody_bazy.Uzupelnij_dataGrid_zamowienia(okno_Glowne.dataGridView_zamowienia, okno_Glowne.dateTimePicker_od.Text.ToString(), okno_Glowne.dateTimePicker_do.Text.ToString(), "nr_zamowienia", "DESC");
                Close();
            }      
        }
    }
}

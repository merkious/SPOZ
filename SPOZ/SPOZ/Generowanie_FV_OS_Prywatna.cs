using SPOZ.PDF;
using System;
using System.Windows.Forms;

namespace SPOZ
{
    public partial class Generowanie_FV_OS_Prywatna : Form
    {
        private DateTimePicker data_rozliczenia;

        public Generowanie_FV_OS_Prywatna()
        {
            InitializeComponent();
        }

        public Generowanie_FV_OS_Prywatna(DateTimePicker data_roz, string kwota)
        {
            InitializeComponent();
            data_rozliczenia = data_roz;
            label_kwota.Text = kwota;
           
        }

        private void button_zapisz_Click(object sender, EventArgs e)
        {
            
        }

        private void button_anuluj_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

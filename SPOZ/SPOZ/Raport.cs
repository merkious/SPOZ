using System;
using System.Windows.Forms;

namespace SPOZ
{
    public partial class Raport : Form
    {
     
        public Raport()
        {
            InitializeComponent();
            dateTimePicker_od.Value = DateTime.Today.AddMonths(-1);
            dateTimePicker_do.Value = DateTime.Today;
            this.CenterToParent();
            this.TopMost = true;
        }


        private void button_drukuj_Click(object sender, EventArgs e)
        {
                Druk_raport_pdf drukuj = new Druk_raport_pdf(dateTimePicker_od.Text.ToString(), dateTimePicker_do.Text.ToString());                
         
            this.Close();

        }
    }
}

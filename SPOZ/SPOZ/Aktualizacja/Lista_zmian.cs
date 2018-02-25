using System;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace SPOZ
{
    public partial class Lista_zmian : Form
    {
        public Lista_zmian()
        {
            InitializeComponent();
        }

        private void Lista_zmian_Load(object sender, EventArgs e)
        {
            try
            {
                WebRequest prosba = WebRequest.Create("http://spoz.pl/pub/app/Lista_zmian.txt");
                prosba.Credentials = CredentialCache.DefaultCredentials;
                HttpWebResponse odpowiedz = (HttpWebResponse)prosba.GetResponse();
                Stream stream = odpowiedz.GetResponseStream();
                StreamReader odczyt = new StreamReader(stream);

                string tresc= Convert.ToString(odczyt.ReadToEnd());

                //byte[] bytes = Encoding.Default.GetBytes(tresc);
                //tresc = Encoding.BigEndianUnicode.GetString(bytes);


                richTextBox1.Text = tresc;// Convert.ToString(odczyt.ReadToEnd());
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lista_zmian_Load");
            }
        }
    }
}

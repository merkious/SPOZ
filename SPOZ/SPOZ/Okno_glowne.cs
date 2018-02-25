using SPOZ.PDF;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace SPOZ
{
    public partial class Okno_glowne : Form
    {
        private Double wybrana_kwota_laczna;
        public static Aktualizacja aktualizacja = new Aktualizacja();
        Logowanie log = Application.OpenForms.OfType<Logowanie>().FirstOrDefault();

        public static Boolean czy_edycja = false, wykorzystanie_danych = false;
        public static DialogResult Akt_pytanie = DialogResult.None;
 
        public Okno_glowne()
        {
            InitializeComponent();

            if (Properties.Settings.Default.Autostart=true && !System.IO.File.Exists(Sciezki.autostart))
                Opcje.Utworz_skrot();
            
            log = new Logowanie(this);
            log.FormClosed += Log_FormClosed;
            Metody_lokalne.Foldery();
            
            Kultura.Kropka();
            dateTimePicker_od.Value = DateTime.Today.AddMonths(-1);
            label_wersja.Text = "Wersja programu: " + Aktualizacja.POSIADANA.ToString();

            if (Screen.PrimaryScreen.WorkingArea.Width < 1230)
            {
                WindowState = FormWindowState.Maximized;
                MaximumSize = new Size(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);
            }
        }

        private void Log_FormClosed(object sender, FormClosedEventArgs e)
        {
            aktualizacja = new Aktualizacja();
            aktualizacja.Pytanie_czy_zaktualizowac();

            Metody_bazy.Pobranie_maila_menadzera();
        }

        
        private void Okno_glowne_Load(object sender, EventArgs e)
        {
            timer_status_polaczenia.Start();
            Size = Properties.Settings.Default.Rozmiar_okna_glownego;
            try {Location = Properties.Settings.Default.Pozycja_okna_glownego;}
            catch(Exception){}
            WindowState = Properties.Settings.Default.Status_okna_glownego;

            if (WindowState == FormWindowState.Minimized)
                WindowState = FormWindowState.Normal;
           
            Metody_lokalne.Sprawdzanie_statusu_polaczenia(label_status_polaczenia_z_baza, pictureBox_status_polaczenie_z_baza_g, pictureBox_status_polaczenie_z_baza_r);
            Metody_lokalne.Usuwanie_starych_aktualizacji();
            log.ShowDialog();

            Thread thr = new Thread(() => Metody_bazy.Dane_sklepu_z_bazy());
            thr.Start();

        }

        private void Button_nowe_zk_Click(object sender, EventArgs e)
        {
            Nowe_zamowienie nowe_zk = new Nowe_zamowienie(this);
            nowe_zk.ShowDialog();
        } //otwieranie okna nowego zamówienia

        private void Okno_glowne_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                Properties.Settings.Default.Rozmiar_okna_glownego = Size;
                Properties.Settings.Default.Pozycja_okna_glownego = Location;
            }
            Properties.Settings.Default.Status_okna_glownego = WindowState;
            Properties.Settings.Default.Save();

            if (MessageBox.Show("Czy zakończyć działanie programu?", "Koniec pracy na dziś?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                e.Cancel = true;
            else
                Environment.Exit(0);
        } //zamykanie programu

        private void OpcjeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Opcje opcja = new Opcje(this);
            opcja.Show();
        }

        private void Okno_glowne_Activated(object sender, EventArgs e)
        {
            aktualizacja.BringToFront();
            label_wybrny_sklep.Text = "Wybrany sklep: " + Properties.Settings.Default.aktualne_miasto_PL;
        }

        private void Timer_status_polaczenia_Tick(object sender, EventArgs e)
        {
            Metody_lokalne.Sprawdzanie_statusu_polaczenia(label_status_polaczenia_z_baza, pictureBox_status_polaczenie_z_baza_g, pictureBox_status_polaczenie_z_baza_r);
        }

        private void TextBox_szukaj_zk_KeyUp(object sender, KeyEventArgs e)
        {
            checkBox_rozliczone.Checked = false;
            checkBox_nierozliczone.Checked = false;

            if (e.KeyCode == Keys.Enter)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    Metody_bazy.Szukanie_dynamiczne_texbox(dataGridView_zamowienia, textBox_szukaj_zk, "nr_zamowienia", "DESC");
                }
                if (textBox_szukaj_zk.TextLength == 0)
                {

                    Metody_bazy.Uzupelnij_dataGrid_zamowienia(dataGridView_zamowienia, dateTimePicker_od.Text, dateTimePicker_do.Text, "nr_zamowienia", "DESC");
                }

                //try
                //{
                //    for (int i = dataGridView_zamowienia.RowCount - 1; i > -1; i--)
                //    {
                //        bool nr_zk= dataGridView_zamowienia.Rows[i].Cells[0].Value.ToString().ToLower().Contains(textBox_szukaj_zk.Text.ToLower());
                //        bool imie = dataGridView_zamowienia.Rows[i].Cells[1].Value.ToString().ToLower().Contains(textBox_szukaj_zk.Text.ToLower());
                //        bool tele = dataGridView_zamowienia.Rows[i].Cells[3].Value.ToString().ToLower().Contains(textBox_szukaj_zk.Text.ToLower());
                //        if (imie == true || nr_zk == true || tele == true)
                //            dataGridView_zamowienia.Rows[i].Visible = true;
                //        else
                //            dataGridView_zamowienia.Rows[i].Visible = false;                       
                //    }
                //    Kolorowanie_DGV(dataGridView_zamowienia);
                //}
                //catch (Exception)
                //{
                //    dataGridView_zamowienia.Rows[0].Cells[0].Value = null;
                //    dataGridView_zamowienia.Rows[0].Cells[1].Value = null;
                //    dataGridView_zamowienia.Rows[0].Cells[2].Value = null;
                //    dataGridView_zamowienia.Rows[0].Cells[3].Value = 0;
                //    dataGridView_zamowienia.Rows[0].Cells[4].Value = null;
                //    dataGridView_zamowienia.Rows[0].Cells[5].Value = null;
                //    dataGridView_zamowienia.Rows[0].Cells[6].Value = null;
                //    dataGridView_zamowienia.Rows[0].Cells[7].Value = 0;
                //    dataGridView_zamowienia.Rows[0].Cells[8].Value = null;
                //    dataGridView_zamowienia.Rows[0].Cells[9].Value = null;
                //    dataGridView_zamowienia.Rows[0].Cells[10].Value = false;
                //    dataGridView_zamowienia.Rows[0].Cells[11].Value = 0;
                //    MessageBox.Show("BRAK WPISÓW SPEŁNIĄJĄCYCH PODANE KRYTERIA");
                //}
            }
        }

        private void CheckBox_nierozliczone_CheckedChanged(object sender, EventArgs e)
        {
            textBox_szukaj_zk.Text = null;
            if (checkBox_nierozliczone.Checked == true)
            {
                checkBox_rozliczone.Checked = false;
                Metody_bazy.Szukanie_dynamiczne_nie_rozliczone(dataGridView_zamowienia, "0", dateTimePicker_od.Text.ToString(), dateTimePicker_do.Text.ToString(), "nr_zamowienia", "DESC");
            }
            else
                Metody_bazy.Uzupelnij_dataGrid_zamowienia(dataGridView_zamowienia, dateTimePicker_od.Text, dateTimePicker_do.Text, "nr_zamowienia", "DESC");
        }

        private void CheckBox_rozliczone_CheckedChanged(object sender, EventArgs e)
        {
            textBox_szukaj_zk.Text = null;
            if (checkBox_rozliczone.Checked == true)
            {
                checkBox_nierozliczone.Checked = false;
                Metody_bazy.Szukanie_dynamiczne_nie_rozliczone(dataGridView_zamowienia, "1", dateTimePicker_od.Text.ToString(), dateTimePicker_do.Text.ToString(), "nr_zamowienia", "DESC");
            }
            else
                Metody_bazy.Uzupelnij_dataGrid_zamowienia(dataGridView_zamowienia, dateTimePicker_od.Text.ToString(), dateTimePicker_do.Text.ToString(), "nr_zamowienia", "DESC");
        }

        bool towar_check = false;
        private void DataGridView_zamowienia_MouseClick(object sender, MouseEventArgs e)
        {
            towar_check = false;
            try
            {              
                if (e.Button == MouseButtons.Right)
                {
                    var hti = dataGridView_zamowienia.HitTest(e.X, e.Y);
                    if (dataGridView_zamowienia.Rows[hti.RowIndex].Cells[15].Value.ToString() == "True")
                        towar_check = true;

                    ToolStripMenuItem towar = new ToolStripMenuItem("Towar jest na stanie")
                    {Checked = towar_check};
                    dataGridView_zamowienia.ClearSelection();
                    dataGridView_zamowienia.Rows[hti.RowIndex].Selected = true;
                    ContextMenuStrip menu = new ContextMenuStrip();

                    menu.Items.Add("Edytuj").Name = "Edytuj";

                    ToolStripMenuItem  submenu;
                    submenu = new ToolStripMenuItem
                    {Text = "Otworz"};

                    submenu.DropDownItems.Add("Zamówienie",null, (s, d) =>  Zamowienie(dataGridView_zamowienia.Rows[hti.RowIndex].Cells[0].Value.ToString())).Name="Zamówienie";
                    if (dataGridView_zamowienia.Rows[hti.RowIndex].Cells[16].Value.ToString().Length >= 2)
                        submenu.DropDownItems.Add("Faktura", null, (s, d) => Faktura(dataGridView_zamowienia.Rows[hti.RowIndex].Cells[16].Value.ToString(), dataGridView_zamowienia.Rows[hti.RowIndex].Cells[8].Value.ToString())).Name = "Faktura";
                    menu.Items.Add(submenu);

                    wybrana_kwota_laczna = Convert.ToDouble(dataGridView_zamowienia.Rows[hti.RowIndex].Cells[11].Value.ToString());
                    
                    if (dataGridView_zamowienia.Rows[hti.RowIndex].Cells[13].Value.ToString() == "False"  )
                        menu.Items.Add("Dopłata").Name = "Dopłata";
                    if (dataGridView_zamowienia.Rows[hti.RowIndex].Cells[1].Value.ToString() != "Sprzedaż z ekspozycji")
                    {
                        if (dataGridView_zamowienia.Rows[hti.RowIndex].Cells[16].Value.ToString().Length <= 2)
                            menu.Items.Add("Rozlicz").Name = "Rozlicz";
                        menu.Items.Add("Nowe zamówienie dla tego klienta").Name = "Użyj";
                        menu.Items.Add(towar);
                    }

                    Metody_bazy.biezacy_wiersz_tabeli = dataGridView_zamowienia.HitTest(e.X, e.Y).RowIndex;
                    menu.Show(dataGridView_zamowienia, new Point(e.X, e.Y));                                       
                    menu.ItemClicked += Menu_ItemClicked;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void Zamowienie(string nr_zk)
        {
            //TopMost = true;
            Metody_bazy.biezacy_nr_zamowienia = dataGridView_zamowienia.Rows[Metody_bazy.biezacy_wiersz_tabeli].Cells[0].Value.ToString();
            Metody_bazy.Pobranie_ID_z_nr_zamowienia();
            Metody_bazy.Wyciaganie_nazw_zamowionych_produktow();
            Metody_lokalne.Otwieranie_zamowienia(nr_zk);
            //TopMost = false;
        }

        private void Faktura(string nr_fv, string data_roz)
        {
            Metody_bazy.biezacy_nr_zamowienia = dataGridView_zamowienia.Rows[Metody_bazy.biezacy_wiersz_tabeli].Cells[0].Value.ToString();
            Metody_bazy.Pobranie_ID_z_nr_zamowienia();
            Metody_lokalne.Otwieranie_faktury(nr_fv, data_roz);
        }

            private void Menu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
            {
                Metody_bazy.biezacy_nr_zamowienia = dataGridView_zamowienia.Rows[Metody_bazy.biezacy_wiersz_tabeli].Cells[0].Value.ToString();
                Metody_bazy.Pobranie_ID_z_nr_zamowienia();
            
                switch (e.ClickedItem.Text.ToString())
                {
                    case "Edytuj":
                        Metody_bazy.Wyciaganie_nazw_zamowionych_produktow();
                        czy_edycja = true;
                        Nowe_zamowienie nowe_zk = new Nowe_zamowienie(this);
                        nowe_zk.Show();
                        break;

                    case "Rozlicz":
                        Kalendarzyk K = new Kalendarzyk(this,wybrana_kwota_laczna.ToString("##,##0.00" + " zł"));
                        K.ShowDialog();
                        break;

                    case "Dopłata":
                        Doplata D = new Doplata(this);
                        D.ShowDialog();
                        break;      
                    
                    case "Nowe zamówienie dla tego klienta":
                        wykorzystanie_danych = true;
                        nowe_zk = new Nowe_zamowienie(this);                   
                        nowe_zk.Show();
                        break;

                    case "Towar jest na stanie":
                        if (towar_check == true)
                        {
                            Thread thr = new Thread(() => Metody_bazy.Zmien_towar_na_stanie(0));
                            thr.Start();
                            dataGridView_zamowienia.Rows[Metody_bazy.biezacy_wiersz_tabeli].Cells[15].Value = false ;
                            dataGridView_zamowienia.Rows[Metody_bazy.biezacy_wiersz_tabeli].DefaultCellStyle.BackColor = Color.White;
                        }
                        else
                        {
                            Thread thr = new Thread(() => Metody_bazy.Zmien_towar_na_stanie(1));
                            thr.Start();

                            dataGridView_zamowienia.Rows[Metody_bazy.biezacy_wiersz_tabeli].Cells[15].Value = true;
                            dataGridView_zamowienia.Rows[Metody_bazy.biezacy_wiersz_tabeli].DefaultCellStyle.BackColor = Color.LightBlue;
                        }
                        break;
                }
            }

        private void RaportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void Okno_glowne_SizeChanged(object sender, EventArgs e)
        {
            Zmiana_rozmiaru_DGV();
         }

        public static void Kolorowanie_DGV(DataGridView dataGrid)
        {
            try
            {
                if (dataGrid.ColumnCount>0)
                {
                    for (int i = 0; i < dataGrid.RowCount; i++)
                    {
                        if (dataGrid.Rows[i].Cells[14].Value.ToString() != "0")
                            dataGrid.Rows[i].Cells[11].Value = Convert.ToDecimal(dataGrid.Rows[i].Cells[11].Value) + 1;

                        if (dataGrid.Rows[i].Cells[14].Value.ToString() != "0" && dataGrid.Rows[i].Cells[13].Value.ToString() != "True")
                            dataGrid.Rows[i].Cells[12].Value = Convert.ToDecimal(dataGrid.Rows[i].Cells[12].Value) + 1;

                        if (dataGrid.Rows[i].Cells[13].Value.ToString() != "True")
                            dataGrid.Rows[i].Cells[12].Style.BackColor = Color.OrangeRed;
                        else
                            dataGrid.Rows[i].Cells[12].Value = "0.00";

                        if (dataGrid.Rows[i].Cells[15].Value.ToString() == "True")
                            dataGrid.Rows[i].DefaultCellStyle.BackColor = Color.LightBlue;

                        dataGrid.Rows[i].Cells[5].Value = dataGrid.Rows[i].Cells[5].Value.ToString().Substring(10) + " zł";
                        dataGrid.Rows[i].Cells[5].Value = dataGrid.Rows[i].Cells[5].Value.ToString().Replace(" 0.00 zł", "");

                        if (dataGrid.Rows[i].Cells[8].Value.ToString() == "0000-00-00")
                            dataGrid.Rows[i].Cells[8].Value = null;
                        if (dataGrid.Rows[i].Cells[1].Value.ToString() == "Sprzedaż z ekspozycji")
                            dataGrid.Rows[i].Cells[2].Value = null;
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Kolorowanie"); }
        }

        public void Zmiana_rozmiaru_DGV( )
        {
            dataGridView_zamowienia.RowTemplate.MinimumHeight = 57;

            if (dataGridView_zamowienia.Columns.Count > 0)
            {
                if (WindowState == FormWindowState.Maximized && Screen.PrimaryScreen.WorkingArea.Width > 1230)
                {
                    dataGridView_zamowienia.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dataGridView_zamowienia.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dataGridView_zamowienia.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dataGridView_zamowienia.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dataGridView_zamowienia.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dataGridView_zamowienia.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView_zamowienia.Columns[0].Width = 70; //zk
                    dataGridView_zamowienia.Columns[1].Width = 100; //Imie nazwisko
                    dataGridView_zamowienia.Columns[2].Width = 170; //adres
                    dataGridView_zamowienia.Columns[3].Width = 70; //telefon
                    dataGridView_zamowienia.Columns[4].MinimumWidth = 250; //zamowienie
                    dataGridView_zamowienia.Columns[5].Width = 85; //transport
                    dataGridView_zamowienia.Columns[6].Width = 65; //data przyjecia
                    dataGridView_zamowienia.Columns[7].Width = 60; //zadatek
                    dataGridView_zamowienia.Columns[8].Width = 65; // data rozliczenie 
                    dataGridView_zamowienia.Columns[9].Width = 100; // uwagi
                    dataGridView_zamowienia.Columns[10].Width = 35; //raty
                    dataGridView_zamowienia.Columns[11].Width = 60; //łączna
                    dataGridView_zamowienia.Columns[12].Width = 65; //pozostało               
                    dataGridView_zamowienia.Columns[13].Visible = false;
                    dataGridView_zamowienia.Columns[14].Visible = false;
                    dataGridView_zamowienia.Columns[15].Visible = false;
                    dataGridView_zamowienia.Columns[16].Visible = false;

                    dataGridView_zamowienia.Refresh();
                }
                else /*if (WindowState == FormWindowState.Normal)*/
                {
                    dataGridView_zamowienia.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                    dataGridView_zamowienia.Columns[4].Width = 250; //zamowienie
                    dataGridView_zamowienia.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dataGridView_zamowienia.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dataGridView_zamowienia.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dataGridView_zamowienia.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dataGridView_zamowienia.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView_zamowienia.Columns[0].Width = 70; //zk 
                    dataGridView_zamowienia.Columns[1].Width = 100; //Imie nazwisko
                    dataGridView_zamowienia.Columns[2].Width = 100; //adres
                    dataGridView_zamowienia.Columns[3].Width = 70; //telefon
                    dataGridView_zamowienia.Columns[4].MinimumWidth = 250; //zamowienie
                    dataGridView_zamowienia.Columns[5].Width = 85; //transport
                    dataGridView_zamowienia.Columns[6].Width = 65; //data przyjecia   
                    dataGridView_zamowienia.Columns[7].Width = 60; //zadatek
                    dataGridView_zamowienia.Columns[8].Width = 65; // data rozliczenie 
                    dataGridView_zamowienia.Columns[9].Width = 100; // uwagi
                    dataGridView_zamowienia.Columns[10].Width = 35; //raty
                    dataGridView_zamowienia.Columns[11].Width = 60; //łączna
                    dataGridView_zamowienia.Columns[12].Width = 65; //pozostało               
                    dataGridView_zamowienia.Columns[13].Visible = false;
                    dataGridView_zamowienia.Columns[14].Visible = false;
                    dataGridView_zamowienia.Columns[15].Visible = false;
                    dataGridView_zamowienia.Columns[16].Visible = false;
                    dataGridView_zamowienia.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                    dataGridView_zamowienia.Refresh();
                }
            }
        }

        private void Label_wyloguj_Click(object sender, EventArgs e)
        {
            for (int i = Application.OpenForms.Count - 1; i >= 0; i--)
            {
                if (Application.OpenForms[i].Name != "Okno_glowne")
                    Application.OpenForms[i].Close();
            }
            Logowanie.zalogowany = false;
            Logowanie log = new Logowanie(this);
            log.Show();
            this.ShowInTaskbar = false;
            Opacity = 0;
        }

        private void Okno_glowne_Shown(object sender, EventArgs e)
        {
            Zmiana_rozmiaru_DGV();
        }

        string sortowanie = null;
        private void DataGridView_zamowienia_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string typ = null;
            if (dataGridView_zamowienia.Columns[e.ColumnIndex].HeaderText != sortowanie /*&& dataGridView_zamowienia.SortOrder + "" == "Ascending"*/)
            {
                typ = "ASC";
            }
            else
                typ = "DESC";

            sortowanie = dataGridView_zamowienia.Columns[e.ColumnIndex].HeaderText;

            switch (Metody_bazy.metoda_szukania)
             {
                 case 1:
                     Metody_bazy.Uzupelnij_dataGrid_zamowienia(dataGridView_zamowienia, dateTimePicker_od.Text, dateTimePicker_do.Text, sortowanie, typ);
                     break;
                 case 2:
                     Metody_bazy.Szukanie_dynamiczne_texbox(dataGridView_zamowienia, textBox_szukaj_zk, sortowanie, typ);
                     break;
                 case 3:
                     Metody_bazy.Szukanie_dynamiczne_nie_rozliczone(dataGridView_zamowienia, "0", dateTimePicker_od.Text.ToString(), dateTimePicker_do.Text.ToString(), sortowanie, typ);
                     break;
             }
            Kolorowanie_DGV(dataGridView_zamowienia);
        }

        private void RaportKwotToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Raport raport = new Raport();
            raport.ShowDialog();
        }

        private void RaportRealizacjiToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Druk_rap_realizacji druk = new Druk_rap_realizacji();
        }

        private void DateTimePicker_od_CloseUp(object sender, EventArgs e)
        {
            textBox_szukaj_zk.Text = null;
            if (checkBox_nierozliczone.Checked == true)
                Metody_bazy.Szukanie_dynamiczne_nie_rozliczone(dataGridView_zamowienia, "0", dateTimePicker_od.Text.ToString(), dateTimePicker_do.Text.ToString(), "nr_zamowienia", "DESC");
            else if (checkBox_rozliczone.Checked == true)
                Metody_bazy.Szukanie_dynamiczne_nie_rozliczone(dataGridView_zamowienia, "1", dateTimePicker_od.Text.ToString(), dateTimePicker_do.Text.ToString(), "nr_zamowienia", "DESC");
            else
                Metody_bazy.Uzupelnij_dataGrid_zamowienia(dataGridView_zamowienia, dateTimePicker_od.Text, dateTimePicker_do.Text, "nr_zamowienia", "DESC");
        }

        private void DateTimePicker_do_CloseUp(object sender, EventArgs e)
        {
            textBox_szukaj_zk.Text = null;
            if (checkBox_nierozliczone.Checked == true)
                Metody_bazy.Szukanie_dynamiczne_nie_rozliczone(dataGridView_zamowienia, "0", dateTimePicker_od.Text.ToString(), dateTimePicker_do.Text.ToString(), "nr_zamowienia", "DESC");
            else if (checkBox_rozliczone.Checked == true)
                Metody_bazy.Szukanie_dynamiczne_nie_rozliczone(dataGridView_zamowienia, "1", dateTimePicker_od.Text.ToString(), dateTimePicker_do.Text.ToString(), "nr_zamowienia", "DESC");
            else
                Metody_bazy.Uzupelnij_dataGrid_zamowienia(dataGridView_zamowienia, dateTimePicker_od.Text, dateTimePicker_do.Text, "nr_zamowienia", "DESC");
        }

        private void TextBox_szukaj_zk_Enter(object sender, EventArgs e)
        {
            TextBox TB = (TextBox)sender;
            int VisibleTime = 5000;  //in milliseconds

            ToolTip tt = new ToolTip();
            tt.Show("Szukaj w nr zamówienia," +
                "imieniu i nazwisku" +
                "oraz nr telefonu", TB, 20, 20, VisibleTime);
        }

        private void Wersja_Click(object sender, EventArgs e)
        {
            Aktualizacja.Sprawdzenie_wersji();
            if (Aktualizacja.POSIADANA == Aktualizacja.WERJSA__FTP)
                MessageBox.Show("Masz najnowszą wersję oprogramowania.", "Używasz wersji: " + Aktualizacja.POSIADANA);
            else
            {
                aktualizacja = new Aktualizacja
                { Opacity = 100 };
                Aktualizacja aktu = new Aktualizacja();
                aktu.Pytanie_czy_zaktualizowac();
            }
        }
    }
}
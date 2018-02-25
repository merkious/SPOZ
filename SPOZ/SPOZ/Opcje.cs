using IWshRuntimeLibrary;
using System;
using System.Diagnostics;
using System.Windows.Forms;


namespace SPOZ
{
    public partial class Opcje : Form
    {
        Okno_glowne okno_Glowne;

        public Opcje(Okno_glowne okno_glowne)
        {
            InitializeComponent();
            okno_Glowne = okno_glowne;
            Czy_jest_skrot(uruchamiaj_z_systemem_checkbox);
            Metody_bazy.Wczytanie_listy_sprzedawcow_do_combobox(comboBox_sprzedawcy);
            Metody_bazy.Wczytanie_listy_sprzedawcow_do_combobox(comboBox_sprzedawce_do_usuniecia);
            Metody_bazy.Wczytanie_listy_sklepow_do_combobox(comboBox_sklep_sprzedawcy);
            Metody_bazy.Wczytanie_listy_sklepow_do_combobox(comboBox_sklep_do_DGV);
            Metody_bazy.Wczytanie_listy_gratisow_do_combobox(comboBox_gratis);

            comboBox_sklep_sprzedawcy.Enabled = false;
            if (System.IO.File.Exists(Sciezki.aktualizacje + @"\Setup_SPOZ_" + Aktualizacja.WERJSA__FTP + ".exe"))
                button_spr_aktualizacje.Text = "Zainstaluj aktualizację.";
            else if (Aktualizacja.POSIADANA < Aktualizacja.WERJSA__FTP)
                button_spr_aktualizacje.Text = "Pobierz aktualizację.";
             ((Control)this.karta_menadzera).Enabled = false;
        }

        private void Opcje_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.uprawnienia==1)
            {
                ((Control)this.karta_menadzera).Enabled = true;
            }
        }

        #region SKRÓT

        private void Czy_jest_skrot(CheckBox skrot)
        {
            if (System.IO.File.Exists(Sciezki.autostart))
            {
                skrot.Checked = true;
            }
        }

        public static void Utworz_skrot()
        {
            try
            {
                WshShell shell = new WshShell();
                IWshShortcut skrot = shell.CreateShortcut(Sciezki.autostart);
                skrot.Description = "SPOZ";
                skrot.IconLocation = Sciezki.sciezka_aplikacji + @"\icon.ico";
                skrot.TargetPath = Sciezki.sciezka_aplikacji+@"\SPOZ.exe";
                skrot.Save();
            }
            catch (Exception)
            {
                MessageBox.Show("Nie udało się utworzyć skrótu");
            }
        }

        private void Uruchamiaj_z_systemem_checkbox_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (uruchamiaj_z_systemem_checkbox.Checked == true)
                {
                    Utworz_skrot();
                    Properties.Settings.Default.Autostart = true;
                    Properties.Settings.Default.Save();
                }
                if (uruchamiaj_z_systemem_checkbox.Checked == false)
                {
                    System.IO.File.Delete(Sciezki.autostart);
                    Properties.Settings.Default.Autostart = false;
                    Properties.Settings.Default.Save();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\nBłąd zapisu.");
            }
        }
        #endregion

      

        private void Button_zmien_haslo_Click(object sender, EventArgs e)
        {
            if (textBox_nowe.Text == textBox_nowe_2.Text)
            {
                if (textBox_nowe.Text != textBox_poprzednie.Text)
                {
                    Metody_bazy.Zmiana_hasla(textBox_poprzednie, textBox_nowe);
                }
                else
                MessageBox.Show("Nowe hasła nie są identyczne.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
                MessageBox.Show("Nowe hasło nie może być takie jak poprzednie.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

        }

        private void ComboBox_sprzedawcy_TextChanged(object sender, EventArgs e)
        {
            comboBox_sklep_sprzedawcy.Enabled = true;
        }

        private void Button_nowy_sprzedawca_Click(object sender, EventArgs e)
        {
            Nowy_sprzedawca ns = new Nowy_sprzedawca();
            ns.Show();
        }

        private void Button_spr_aktualizacje_Click(object sender, EventArgs e)
        {
            if (button_spr_aktualizacje.Text == "Sprawdź aktualizację")
            {
                Aktualizacja.Sprawdzenie_wersji();
                if (Aktualizacja.POSIADANA == Aktualizacja.WERJSA__FTP)
                    MessageBox.Show("Masz najnowszą wersję oprogramowania.", "Używasz wersji: " + Aktualizacja.POSIADANA);
                else
                {
                    Aktualizacja aktu = new Aktualizacja();
                    aktu.ShowDialog();
                    aktu.Pytanie_czy_zaktualizowac();
                }
            }
            else if (button_spr_aktualizacje.Text == "Pobierz aktualizację.")
            {
                Aktualizacja aktualizacja = new Aktualizacja();
                aktualizacja.Pobieranie_aktualizacji();

            }
            else if(button_spr_aktualizacje.Text == "Zainstaluj aktualizację.")
            {
                Process.Start(Aktualizacja.Aktualizacja_setup);
                Environment.Exit(0);
            }
           
        }

        private void Sklep_do_DGV()
        {
            try
            {
                if (comboBox_sklep_do_DGV.Text != "")
                {
                    int id = Convert.ToInt16(comboBox_sklep_do_DGV.Text.Substring(0, comboBox_sklep_do_DGV.Text.IndexOf(".")));
                    Properties.Settings.Default.id_wybranego_miasta = id;
                    Metody_bazy.Pobranie_aktualnego_miasta();
                    Properties.Settings.Default.aktualne_miasto = Metody_lokalne.Usun_polskie_znaki(Metody_bazy.aktualne_miasto.ToLower());
                    Properties.Settings.Default.aktualne_miasto_PL = comboBox_sklep_do_DGV.Text.Substring(2);

                    Properties.Settings.Default.Save();
                    Metody_bazy.Uzupelnij_dataGrid_zamowienia(okno_Glowne.dataGridView_zamowienia, okno_Glowne.dateTimePicker_od.Text, okno_Glowne.dateTimePicker_do.Text, "nr_zamowienia", "DESC");
                    okno_Glowne.label_wybrny_sklep.Text = "Wybrany sklep: " + Properties.Settings.Default.aktualne_miasto_PL;
                    System.Threading.Thread thr = new System.Threading.Thread(() => Metody_bazy.Dane_sklepu_z_bazy());
                    thr.Start();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void button_zapisz_opcje_Click(object sender, EventArgs e)
        {
            
            if (comboBox_sklep_sprzedawcy.Text!="")
                Metody_bazy.Zmiana_sklepu_sprzedawcy(Convert.ToInt16(comboBox_sklep_sprzedawcy.Text.Substring(0, comboBox_sklep_sprzedawcy.Text.IndexOf("."))),comboBox_sprzedawcy);

            Sklep_do_DGV();
        }

        private void button_usun_sprzedawce_Click(object sender, EventArgs e)
        {
            Metody_bazy.Usun_sprzedawce(comboBox_sprzedawce_do_usuniecia);
            comboBox_sprzedawce_do_usuniecia.Text = "";
            Metody_bazy.Wczytanie_listy_sprzedawcow_do_combobox(comboBox_sprzedawce_do_usuniecia);
        }

        private void button_stworz_gratis_Click(object sender, EventArgs e)
        {
            Gratis g = new Gratis();
            g.Show();
        }

        public bool edycja = false;
        private void button_edytuj_gratis_Click(object sender, EventArgs e)
        {
            edycja = true;
            Gratis g = new Gratis();
            g.Show();
        }

        private void button_usun_gratis_Click(object sender, EventArgs e)
        {
            Metody_bazy.Dezaktywuj_gratis(comboBox_gratis);
            comboBox_gratis.Text = null;
        }

        private void comboBox_gratis_Click(object sender, EventArgs e)
        {
            Metody_bazy.Wczytanie_listy_gratisow_do_combobox(comboBox_gratis);
            comboBox_gratis.Items.RemoveAt(0);
        }

        private void comboBox_gratis_TextChanged(object sender, EventArgs e)
        {
            if (comboBox_gratis.Text.Length!=0)
            {
                button_usun_gratis.Enabled = true;
                button_edytuj_grartis.Enabled = true;
            }
            else
            {
                button_usun_gratis.Enabled = false;
                button_edytuj_grartis.Enabled = false;
            }
        }
    }
}
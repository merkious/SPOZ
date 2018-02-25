using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace SPOZ
{
    public partial class Nowe_zamowienie : Form
    {
        public static decimal sum;
        decimal[] kwoty = new decimal[6];
        private bool zamykanie = false; // odróżnia próbe zamknięcia od zapisu przycikiem
        string pytanie_przy_zamykaniu = "dodawanie";
        string tresc = null;
        Okno_glowne okno_Glowne;

        public Nowe_zamowienie(Okno_glowne okno_glowne)
        {
            InitializeComponent();
            okno_Glowne = okno_glowne;


            Metody_bazy.Wczytanie_listy_gratisow_do_combobox(comboBox_gratis);
            comboBox_gratis.SelectedIndex = 0;
            groupBox2.Visible = false;
            groupBox3.Visible = false;
            groupBox4.Visible = false;
            groupBox5.Visible = false;
            groupBox6.Visible = false;
            textBox_adres_2.Enabled = false;
            textBox_kwota_transportu.Enabled = false;
            textBox_kwota_transportu.Text = "0";

            dateTimePicker_data_przyjecia.Value = DateTime.Now;

            #region Uzupełnianie przy edycji i wykorzystaniu danych
            if (Okno_glowne.czy_edycja == true || Okno_glowne.wykorzystanie_danych==true)
            {
                checkBox_mail_po_edycji.Visible = true;
                Metody_bazy.Wczytanie_zamowienia_do_edycji();               

                //edycja i wykorzystanie
                textBox_imie_nazwisko.Text = Metody_bazy.imie_nazwisko;
                textBox_miasto.Text = Metody_bazy.miejscowosc;
                maskedTextBox_kodpocztowy.Text = Metody_bazy.kod_pocztowy;
                textBox_ulica_nr.Text = Metody_bazy.ulica_nr;
                textBox_tel.Text = Metody_bazy.telefon;

                if (Okno_glowne.czy_edycja == true)
                {
                    comboBox_ilosc.Text = Metody_bazy.ilosc_produktow_combo;

                    //100% edycja
                    if (Metody_bazy.imie_nazwisko == "Sprzedaż z ekspozycji")
                    {
                        checkBox_ekspo.Checked = true;
                    }
                    checkBox_ekspo.Enabled = false;

                    Text = "Edycja zamówienia - " + Metody_bazy.biezacy_nr_zamowienia;
                    pytanie_przy_zamykaniu = "edycję";

                    textBox_uwagi.Text = Metody_bazy.uwagi;
                    textBox_zadatek.Text = Metody_bazy.zadatek;
                    dateTimePicker_data_przyjecia.Value = Metody_bazy.data_przyjecia;
                    checkBox_zaplacono_calosc.Checked = Metody_bazy.zaplacono_calosc;
                    if (Metody_bazy.termin_realizacji != "0")
                        textBox_termin.Text = Metody_bazy.termin_realizacji;
                    
                    checkedListBox_transport.SelectedItem = Metody_bazy.rodzaj_transportu;
                    int temp_transport_select = checkedListBox_transport.SelectedIndex;
                    checkedListBox_transport.ClearSelected();
                    checkedListBox_transport.SetItemCheckState(temp_transport_select, CheckState.Checked);

                    if (checkedListBox_transport.GetItemChecked(2) == true)
                        textBox_kwota_transportu.Enabled = true;
                    if (Metody_bazy.adres_dostawy != "")
                    {                        
                        checkBox_adres_2.Enabled = true;
                        checkBox_adres_2.Checked = true;
                        textBox_adres_2.Text = Metody_bazy.adres_dostawy;
                    }
                    checkBox_raty.Checked = Metody_bazy.raty;
                    textBox_kwota_transportu.Text = Metody_bazy.koszt_transportu;
                    textBox_kwota_1.Text = Metody_bazy.kwota_p_1;
                    textBox_ilosc_1.Text = Metody_bazy.ilosc_p_1;
                    textBox_rabat_1.Text = Metody_bazy.rabat_p_1;
                    textBox_kwota_2.Text = Metody_bazy.kwota_p_2;
                    textBox_ilosc_2.Text = Metody_bazy.ilosc_p_2;
                    textBox_rabat_2.Text = Metody_bazy.rabat_p_2;
                    textBox_kwota_3.Text = Metody_bazy.kwota_p_3;
                    textBox_ilosc_3.Text = Metody_bazy.ilosc_p_3;
                    textBox_rabat_3.Text = Metody_bazy.rabat_p_3;
                    textBox_kwota_4.Text = Metody_bazy.kwota_p_4;
                    textBox_ilosc_4.Text = Metody_bazy.ilosc_p_4;
                    textBox_rabat_4.Text = Metody_bazy.rabat_p_4;
                    textBox_kwota_5.Text = Metody_bazy.kwota_p_5;
                    textBox_ilosc_5.Text = Metody_bazy.ilosc_p_5;
                    textBox_rabat_5.Text = Metody_bazy.rabat_p_5;
                    textBox_kwota_6.Text = Metody_bazy.kwota_p_6;
                    textBox_ilosc_6.Text = Metody_bazy.ilosc_p_6;
                    textBox_rabat_6.Text = Metody_bazy.rabat_p_6;
                    textBox_prod_1.Text = Metody_bazy.zamowienia_tablica[0];
                    textBox_prod_2.Text = Metody_bazy.zamowienia_tablica[1];
                    textBox_prod_3.Text = Metody_bazy.zamowienia_tablica[2];
                    textBox_prod_4.Text = Metody_bazy.zamowienia_tablica[3];
                    textBox_prod_5.Text = Metody_bazy.zamowienia_tablica[4];
                    textBox_prod_6.Text = Metody_bazy.zamowienia_tablica[5];
                    comboBox_gratis.SelectedIndex = Metody_bazy.gratis;
                }
            }
            if (Okno_glowne.czy_edycja == false && (Okno_glowne.wykorzystanie_danych == true || Okno_glowne.wykorzystanie_danych == false))
            {
                comboBox_ilosc.Text = "1";
                textBox_adres_2.Enabled = false;
                textBox_kwota_1.Text = "0.00";
                textBox_ilosc_1.Text = "1";
                textBox_rabat_1.Text = "0.00";                
            }
            #endregion

            Okno_glowne.czy_edycja = false;
            Okno_glowne.wykorzystanie_danych = false;
        } // START      

        private void Blokowanie_entera_w_zamowieniu(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                e.Handled = true;
            }
        }

        private void ComboBox_ilość_SelectedIndexChanged(object sender, EventArgs e)
        {
            GroupBox[] grupy = new GroupBox[6] { groupBox1, groupBox2, groupBox3, groupBox4, groupBox5, groupBox6 };
            TextBox[] okna = new TextBox[12] { textBox_kwota_1, textBox_rabat_1,  textBox_kwota_2, textBox_rabat_2,textBox_kwota_3,
                textBox_rabat_3,  textBox_kwota_4, textBox_rabat_4,  textBox_kwota_5, textBox_rabat_5,textBox_kwota_6, textBox_rabat_6, };
            TextBox[] okna_ilosc = new TextBox[6] { textBox_ilosc_1 , textBox_ilosc_2, textBox_ilosc_3, textBox_ilosc_4, textBox_ilosc_5, textBox_ilosc_6};
            TextBox[] okna_prod = new TextBox[6] { textBox_prod_1, textBox_prod_2,textBox_prod_3, textBox_prod_4, textBox_prod_5,  textBox_prod_6};

            for (int i = 1; i <= 5; i++)
            {
                if (i <= comboBox_ilosc.SelectedIndex)
                {
                    for (int j=1; j <= 5; j++) //zerowanie pól po zmniejszeniu ilości produktów
                    {
                        if (j == 0 || j == 1 || j == 2 || j ==3|| j == 4 || j == 5) okna_ilosc[j].Text = "1";
                    }
                    grupy[i].Visible = true;
                }
                else
                {
                    for (int j = i * 2; j <= 11; j++) //zerowanie pól po zmniejszeniu ilości produktów
                    {
                        okna[j].Text = "0.00";
                        okna_ilosc[i].Text = "0";
                        okna_prod[i].Text = null;
                    }
                    grupy[i].Visible = false;
                }
            }

        }//zmiana ilości przedmiotów w ZK

        private void TextBox_Enter_rabat_kwota(object sender, EventArgs e)
        {
            if ((sender as TextBox).Text == "0.00")
            {
                (sender as TextBox).Text = null;
            }

        } //kasowanie zer w polach rabat i kwota

        private void TextBox_Leave_rabat_kwota(object sender, EventArgs e)
        {
            if ((sender as TextBox).Text=="")
            {
                (sender as TextBox).Text = "0.00";
            }

        } //wpisanie zer jak kursor opuści pole które jest puste

        private void TextBox_Enter_ilosc(object sender, EventArgs e)
        {
            if ((sender as TextBox).Text == "1")
            {
                (sender as TextBox).Text = null;
            }

        } //kasowanie zer w polach rabat i kwota

        private void TextBox_Leave_ilosc(object sender, EventArgs e)
        {
            if ((sender as TextBox).Text == "")
            {
                (sender as TextBox).Text = "1";
            }

        } //wpisanie zer jak kursor opuści pole które jest puste

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            if(sender.GetType()==maskedTextBox_kodpocztowy.GetType())
            {
                (sender as MaskedTextBox).BackColor = Color.White;
            }
            else   (sender as TextBox).BackColor = Color.White;
        } //zmiana koloru na bialy

        Drukowanie_PDF druk = new Drukowanie_PDF();

        public void Tworzenie_pdf(string nr_zk)
        {
            string transp= null;
            if (checkedListBox_transport.GetItemChecked(0) == true)
            {
                transp = " zamawiany gratis.";
            }
            else if (checkedListBox_transport.GetItemChecked(1) == true)
            {
                transp = " we własnym zakresie.";
            }
            else
                transp = " zamawiany płatny - " + (Convert.ToDecimal(textBox_kwota_transportu.Text)).ToString("0.00") + " zł.";

            string adr;
            if (checkBox_ekspo.Checked == true)
            {
                adr = textBox_imie_nazwisko.Text;
            }
            else adr = textBox_imie_nazwisko.Text + ",  " + textBox_ulica_nr.Text + ",  " + textBox_miasto.Text + "  " + maskedTextBox_kodpocztowy.Text + "  tel. " + textBox_tel.Text;          

            druk.Druk_PDF(comboBox_gratis.SelectedIndex,nr_zk,comboBox_ilosc.SelectedIndex+1 , Convert.ToDouble(textBox_zadatek.Text), dateTimePicker_data_przyjecia.Text.ToString(), adr, textBox_adres_2.Text, textBox_termin.Text, transp, textBox_uwagi.Text);
            druk.Druk_produktow(textBox_prod_1.Text, textBox_prod_2.Text, textBox_prod_3.Text, textBox_prod_4.Text, textBox_prod_5.Text, textBox_prod_6.Text);
            druk.Druk_ilosc(Convert.ToDouble(textBox_ilosc_1.Text), Convert.ToDouble(textBox_ilosc_2.Text), Convert.ToDouble(textBox_ilosc_3.Text), Convert.ToDouble(textBox_ilosc_4.Text), Convert.ToDouble(textBox_ilosc_5.Text), Convert.ToDouble(textBox_ilosc_6.Text));
            druk.Druk_rabat(Convert.ToDouble(textBox_rabat_1.Text), Convert.ToDouble(textBox_rabat_2.Text), Convert.ToDouble(textBox_rabat_3.Text), Convert.ToDouble(textBox_rabat_4.Text), Convert.ToDouble(textBox_rabat_5.Text), Convert.ToDouble(textBox_rabat_6.Text));
            druk.Druk_cena_jednostkowa(Convert.ToDouble(textBox_kwota_1.Text), Convert.ToDouble(textBox_kwota_2.Text), Convert.ToDouble(textBox_kwota_3.Text), Convert.ToDouble(textBox_kwota_4.Text), Convert.ToDouble(textBox_kwota_5.Text), Convert.ToDouble(textBox_kwota_6.Text));
            druk.CreateDocument();
        }
        public static string tytuł_maila = null;

        private void Wpis_zamowienia_do_bazy()
        {
            try
            {
                pytanie_przy_zamykaniu = "";

                if (checkBox_ekspo.Checked == true || checkBox_zaplacono_calosc.Checked == true || sum == Convert.ToDecimal(textBox_zadatek.Text) || checkBox_raty.Checked == true)
                    Metody_bazy.Nowe_zamowienie(Metody_bazy.Nowy_numer_zk(), textBox_imie_nazwisko, textBox_miasto, maskedTextBox_kodpocztowy, textBox_ulica_nr, textBox_tel,
                    textBox_prod_1.Text + "\n" + textBox_prod_2.Text + "\n" + textBox_prod_3.Text + "\n" + textBox_prod_4.Text + "\n" + textBox_prod_5.Text + "\n" + textBox_prod_6.Text,
                    textBox_uwagi, textBox_zadatek.Text, dateTimePicker_data_przyjecia, dateTimePicker_data_przyjecia.Text.ToString(), checkBox_raty, textBox_adres_2,1,
                    textBox_kwota_1.Text, textBox_ilosc_1.Text, textBox_rabat_1.Text, textBox_kwota_2.Text, textBox_ilosc_2.Text, textBox_rabat_2.Text,
                    textBox_kwota_3.Text, textBox_ilosc_3.Text, textBox_rabat_3.Text, textBox_kwota_4.Text, textBox_ilosc_4.Text, textBox_rabat_4.Text,
                    textBox_kwota_5.Text, textBox_ilosc_5.Text, textBox_rabat_5.Text, textBox_kwota_6.Text, textBox_ilosc_6.Text, textBox_rabat_6.Text,
                    checkBox_zaplacono_calosc, textBox_termin.Text, checkedListBox_transport, textBox_kwota_transportu.Text, comboBox_gratis, 1);
                else
                    Metody_bazy.Nowe_zamowienie(Metody_bazy.Nowy_numer_zk(), textBox_imie_nazwisko, textBox_miasto, maskedTextBox_kodpocztowy, textBox_ulica_nr, textBox_tel,
                   textBox_prod_1.Text + "\n" + textBox_prod_2.Text + "\n" + textBox_prod_3.Text + "\n" + textBox_prod_4.Text + "\n" + textBox_prod_5.Text + "\n" + textBox_prod_6.Text,
                   textBox_uwagi, textBox_zadatek.Text, dateTimePicker_data_przyjecia, "NULL", checkBox_raty, textBox_adres_2, 0,
                   textBox_kwota_1.Text, textBox_ilosc_1.Text, textBox_rabat_1.Text, textBox_kwota_2.Text, textBox_ilosc_2.Text, textBox_rabat_2.Text,
                   textBox_kwota_3.Text, textBox_ilosc_3.Text, textBox_rabat_3.Text, textBox_kwota_4.Text, textBox_ilosc_4.Text, textBox_rabat_4.Text,
                   textBox_kwota_5.Text, textBox_ilosc_5.Text, textBox_rabat_5.Text, textBox_kwota_6.Text, textBox_ilosc_6.Text, textBox_rabat_6.Text,
                   checkBox_zaplacono_calosc, textBox_termin.Text, checkedListBox_transport, textBox_kwota_transportu.Text, comboBox_gratis, 0);

                tresc = Metody_bazy.Tresc_maila(Metody_bazy.biezacy_nr_zamowienia);
                var th = new Thread(() => Metody_lokalne.Wyslij_zamowienie(Metody_bazy.biezacy_nr_zamowienia, tresc));
                th.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }//wysłanie zamówienia do bazy MySQL

        private void Aktualizacja_wpisu_w_bazie()
        {
            if (checkBox_ekspo.Checked == true || checkBox_zaplacono_calosc.Checked == true || sum == Convert.ToDecimal(textBox_zadatek.Text)|| checkBox_raty.Checked==true)
                Metody_bazy.Aktualizacja_zamowienia(textBox_imie_nazwisko, textBox_miasto, maskedTextBox_kodpocztowy, textBox_ulica_nr, textBox_tel,
               textBox_prod_1.Text + "\n" + textBox_prod_2.Text + "\n" + textBox_prod_3.Text + "\n" + textBox_prod_4.Text + "\n" + textBox_prod_5.Text + "\n" + textBox_prod_6.Text,
               textBox_uwagi, textBox_zadatek.Text, dateTimePicker_data_przyjecia, dateTimePicker_data_przyjecia.Text.ToString(), checkBox_raty, textBox_adres_2, 1,
               textBox_kwota_1.Text, textBox_ilosc_1.Text, textBox_rabat_1.Text, textBox_kwota_2.Text, textBox_ilosc_2.Text, textBox_rabat_2.Text,
               textBox_kwota_3.Text, textBox_ilosc_3.Text, textBox_rabat_3.Text, textBox_kwota_4.Text, textBox_ilosc_4.Text, textBox_rabat_4.Text,
               textBox_kwota_5.Text, textBox_ilosc_5.Text, textBox_rabat_5.Text, textBox_kwota_6.Text, textBox_ilosc_6.Text, textBox_rabat_6.Text,
               checkBox_zaplacono_calosc, textBox_termin, checkedListBox_transport, textBox_kwota_transportu, comboBox_gratis);
            else
                Metody_bazy.Aktualizacja_zamowienia(textBox_imie_nazwisko, textBox_miasto, maskedTextBox_kodpocztowy, textBox_ulica_nr, textBox_tel,
               textBox_prod_1.Text + "\n" + textBox_prod_2.Text + "\n" + textBox_prod_3.Text + "\n" + textBox_prod_4.Text + "\n" + textBox_prod_5.Text + "\n" + textBox_prod_6.Text,
               textBox_uwagi, textBox_zadatek.Text, dateTimePicker_data_przyjecia, null, checkBox_raty, textBox_adres_2, 0,
               textBox_kwota_1.Text, textBox_ilosc_1.Text, textBox_rabat_1.Text, textBox_kwota_2.Text, textBox_ilosc_2.Text, textBox_rabat_2.Text,
               textBox_kwota_3.Text, textBox_ilosc_3.Text, textBox_rabat_3.Text, textBox_kwota_4.Text, textBox_ilosc_4.Text, textBox_rabat_4.Text,
               textBox_kwota_5.Text, textBox_ilosc_5.Text, textBox_rabat_5.Text, textBox_kwota_6.Text, textBox_ilosc_6.Text, textBox_rabat_6.Text,
               checkBox_zaplacono_calosc, textBox_termin, checkedListBox_transport, textBox_kwota_transportu, comboBox_gratis);
        }//wysłanie aktualizacji zamówienia do bazy MySQL

        private void Button_zapisz_click(object sender, EventArgs e)
        {
            if (pytanie_przy_zamykaniu == "dodawanie")
            {
                if (Sprawdzanie_wypelniania() == true) //czy wszystkie wymagane pola są wypełnione
                {
                    if (checkBox_raty.Checked == true) // sprzedaż na raty
                    {
                        Tworzenie_pdf(Metody_bazy.Nowy_numer_zk());
                        if (MessageBox.Show("Czy klient otrzymał zgodę na udzielenie rat oraz podpisał dokumenty?", "Uwaga", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            if (MessageBox.Show("Czy Klient podpisał zamówienie?", "Uwaga", MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {
                                //dodawanie danych do tabeli
                                Wpis_zamowienia_do_bazy();
                                zamykanie = true;
                                this.Close();
                            }
                            else
                                return;
                        }
                        else
                            return;
                    }
                    else if (checkBox_ekspo.Checked == true) // sprzedaż z ekspo
                    {
                        Tworzenie_pdf(Metody_bazy.Nowy_numer_zk());
                        if (MessageBox.Show("Czy chcesz zapisać zamówienie?", "Uwaga", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly) == DialogResult.Yes)
                        {
                            //dodawanie danych do tabeli
                            Wpis_zamowienia_do_bazy();
                            zamykanie = true;
                            this.Close();
                        }
                        else
                            return;

                    }
                    else // sprzdaż normalna
                    {
                        Tworzenie_pdf(Metody_bazy.Nowy_numer_zk());
                        if (MessageBox.Show("Czy Klient podpisał zamówienie?", "Uwaga", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly) == DialogResult.Yes)
                        {
                            //dodawanie danych do tabeli
                            Wpis_zamowienia_do_bazy();
                            zamykanie = true;
                            this.Close();
                        }
                        else                            
                            return;
                    }                   
                }
            }
            else
            {
                if (Sprawdzanie_wypelniania() == true) //czy wszystkie wymagane pola są wypełnione
                {
                    tytuł_maila = "(Edytowane)-";
                    if (MessageBox.Show("Czy chcesz zapisać zmiany?", "Wymagane potwierdzenie", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        Tworzenie_pdf(Metody_bazy.biezacy_nr_zamowienia);
                        if (Drukowanie_PDF.pdf_zamkniety == true)
                        {                           
                            zamykanie = true;
                            pytanie_przy_zamykaniu = "dodawanie";

                            //var aktualizacja_wpisu = new Thread(() => Aktualizacja_wpisu_w_bazie());
                            //aktualizacja_wpisu.Start();

                            Aktualizacja_wpisu_w_bazie();

                            if (checkBox_mail_po_edycji.Checked == true)
                            {                               
                                tresc = Metody_bazy.Tresc_maila(Metody_bazy.biezacy_nr_zamowienia);
                                var mail = new Thread(() => Metody_lokalne.Wyslij_zamowienie(Metody_bazy.biezacy_nr_zamowienia, tresc));
                                mail.Start();
                            }
                            Close();
                        }
                    }
                    ///else MessageBox.Show("Plik .pdf dla tego zamówienia jest otwarty zamknij go aby móc zapisać zmiany.", "Błąd!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                }                               
            }

           
        } //Przycisk zapisywania

        private void CheckBox_adres_2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_adres_2.Checked == true)
            {
                textBox_adres_2.Enabled = true;
            }
            else
            {
                textBox_adres_2.Text = null;
                textBox_adres_2.Enabled = false;
                textBox_adres_2.BackColor = Color.White;
            }
        } //blokowanie dodatkowego adresu

        private void CheckBox_ekspo_CheckedChanged(object sender, EventArgs e)
        {
            checkedListBox_transport.ClearSelected();

            if (checkBox_ekspo.Checked == true)
            {
                comboBox_gratis.Enabled = false;
                comboBox_gratis.SelectedIndex = 0;
                textBox_ulica_nr.Enabled = false;
                textBox_ulica_nr.Text = null;
                textBox_ulica_nr.BackColor = Color.White;
                textBox_imie_nazwisko.Enabled = false;
                textBox_imie_nazwisko.Text = "Sprzedaż z ekspozycji";
                textBox_imie_nazwisko.BackColor = Color.White;
                textBox_tel.Enabled = false;
                textBox_tel.Text = null;
                textBox_tel.BackColor = Color.White;
                textBox_termin.Text = "nie dotyczy";
                checkBox_zaplacono_calosc.Checked = true;
                checkBox_zaplacono_calosc.Enabled = false;
                checkBox_raty.Checked = false;
                checkBox_raty.Enabled = false;
                checkBox_adres_2.Enabled = false;
                checkBox_adres_2.Checked = false;
                textBox_uwagi.Text = "Sprzedaż z ekspozycji";
                checkedListBox_transport.SetItemCheckState(1,CheckState.Checked);
                checkedListBox_transport.Enabled = false;
                textBox_zadatek.Text = textBox_suma.Text;
                textBox_kwota_transportu.Enabled = false;
                textBox_kwota_transportu.Text = "0";
                textBox_miasto.Enabled = false;
                textBox_miasto.Text = null;
                textBox_miasto.BackColor = Color.White;
                maskedTextBox_kodpocztowy.Enabled = false;
                maskedTextBox_kodpocztowy.Text = null;
                maskedTextBox_kodpocztowy.BackColor = Color.White;
            }
            else
            {
                comboBox_gratis.Enabled = true;
                textBox_ulica_nr.Enabled = true;
                textBox_imie_nazwisko.Enabled = true;
                textBox_imie_nazwisko.Text = null;
                textBox_tel.Enabled = true;
                textBox_termin.Text = null;
                checkBox_zaplacono_calosc.Checked = false;
                checkBox_raty.Enabled = true;
                checkBox_adres_2.Enabled = true;
                textBox_uwagi.Text = null;
                textBox_zadatek.Text = "0.00";
                checkBox_zaplacono_calosc.Enabled = true;
                //textBox_kwota_transportu.Enabled = true;
                textBox_miasto.Enabled = true;                
                maskedTextBox_kodpocztowy.Enabled = true;
                checkedListBox_transport.Enabled = true;
            }
        }//on/off spredaży ekspo

        private void TextBox_ilosc_1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }            
            (sender as TextBox).BackColor = Color.White;
        }//wpisywanie tylko cyfr

        private void TextBox_tylko_liczby(object sender, KeyPressEventArgs e)
        {
            if (!(sender as TextBox).Text.Contains("."))
            {
                Metody_lokalne.Kropka_w_locie((sender as TextBox), e);
            }
            else if ((sender as TextBox).Text.Contains(".") && e.KeyChar == ',' || e.KeyChar == '.')
            {
                e.Handled = true;
            }
            (sender as TextBox).BackColor = Color.White;

        }//wpisywanie tylko cyfr i "."

        private void TextBox_tylko_liczby_2_po_przecinku(object sender, KeyPressEventArgs e)
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
            (sender as TextBox).BackColor = Color.White;
        }//wpisywanie tylko cyfr i ".", maks 2 miejsca po przecinku

        private bool Sprawdzanie_wypelniania()
        {
            bool poprawne_wyp = true;
            TextBox[] okna = new TextBox[24] { textBox_prod_1, textBox_ilosc_1, textBox_kwota_1, textBox_rabat_1, textBox_prod_2, textBox_ilosc_2, textBox_kwota_3, textBox_rabat_3, textBox_prod_3, textBox_ilosc_3, textBox_kwota_3, textBox_rabat_3, textBox_prod_4, textBox_ilosc_4, textBox_kwota_4, textBox_rabat_4, textBox_prod_5, textBox_ilosc_5, textBox_kwota_5, textBox_rabat_5, textBox_prod_6, textBox_ilosc_6, textBox_kwota_6, textBox_rabat_6, };
            int liczba = comboBox_ilosc.SelectedIndex;

            for (int i = 0; i < (liczba + 1) * 4; i++)
            {
                if (okna[i].Text.Length == 0)
                {
                    okna[i].BackColor = Color.IndianRed;
                    poprawne_wyp = false;
                }
            }
            if (textBox_ulica_nr.Enabled == true && textBox_ulica_nr.Text.Length == 0)
            {
                textBox_ulica_nr.BackColor = Color.IndianRed;
                poprawne_wyp = false;
            }
            if (textBox_adres_2.Enabled == true && textBox_adres_2.Text.Length == 0)
            {
                textBox_adres_2.BackColor = Color.IndianRed;
                poprawne_wyp = false;
            }
            if (textBox_imie_nazwisko.Enabled == true && textBox_imie_nazwisko.Text.Length == 0)
            {
                textBox_imie_nazwisko.BackColor = Color.IndianRed;
                poprawne_wyp = false;
            }
            if (textBox_miasto.Enabled == true && textBox_miasto.Text.Length == 0)
            {
                textBox_miasto.BackColor = Color.IndianRed;
                poprawne_wyp = false;
            }
            if (maskedTextBox_kodpocztowy.Enabled == true && maskedTextBox_kodpocztowy.MaskCompleted==false)
            {
                
                maskedTextBox_kodpocztowy.BackColor = Color.IndianRed;
                poprawne_wyp = false;
            }
            if (textBox_tel.Enabled == true && textBox_tel.Text.Length == 0)
            {
                textBox_tel.BackColor = Color.IndianRed;
                poprawne_wyp = false;
            }
            if (textBox_termin.Text.Length == 0)
            {
                textBox_termin.BackColor = Color.IndianRed;
                poprawne_wyp = false;
            }
            if (textBox_zadatek.Text.Length == 0)
            {
                textBox_zadatek.BackColor = Color.IndianRed;
                poprawne_wyp = false;
            }
            if (checkedListBox_transport.GetItemCheckState(0)==0 && checkedListBox_transport.GetItemCheckState(1) == 0 && checkedListBox_transport.GetItemCheckState(2) == 0)
            {
                checkedListBox_transport.BackColor = Color.IndianRed;
                poprawne_wyp = false;
            }

            if (poprawne_wyp==false)
            {
                 MessageBox.Show("Wypełnij brakujące pola", "Błąd!", MessageBoxButtons.OK);
            }
            else if (poprawne_wyp==true && checkBox_raty.Checked==false && Convert.ToDecimal(textBox_zadatek.Text)==0)
            {
                MessageBox.Show("Zadatek nie może być zerowy", "Błąd!", MessageBoxButtons.OK);
                poprawne_wyp = false;
            }
            else if (poprawne_wyp == true && Convert.ToDecimal(textBox_zadatek.Text) > sum)
            {
                MessageBox.Show("Zadatek nie może przekraczać kwoty zamówienia!", "Błąd!", MessageBoxButtons.OK);
                textBox_zadatek.BackColor = Color.IndianRed;
                poprawne_wyp = false;
            }


                return poprawne_wyp;
        }//sprawdzanie czy wszystkie pola są wypełnione

        private void TextBox_obliczanie_kwot(object sender, EventArgs e)
        {
            try
            {
                decimal kwota, rabat, wynik, ilosc;
                // te 5 ifów to sprawdzanie które pole zostało zmienione
                if ((sender as TextBox) == textBox_kwota_1 || (sender as TextBox) == textBox_rabat_1 || (sender as TextBox) == textBox_ilosc_1)
                {
                    decimal.TryParse(textBox_kwota_1.Text, out kwota);
                    decimal.TryParse(textBox_rabat_1.Text, out rabat);
                    decimal.TryParse(textBox_ilosc_1.Text, out ilosc);
                    wynik = ilosc * (kwota - ((rabat / 100) * kwota));
                    kwoty[0] = wynik;
                    textBox_kwota_fin_1.Text = wynik.ToString("##,##0.00" + " zł");
                }
                if ((sender as TextBox) == textBox_kwota_2 || (sender as TextBox) == textBox_rabat_2 || (sender as TextBox) == textBox_ilosc_2)
                {
                    decimal.TryParse(textBox_kwota_2.Text, out kwota);
                    decimal.TryParse(textBox_rabat_2.Text, out rabat);
                    decimal.TryParse(textBox_ilosc_2.Text, out ilosc);
                    wynik = ilosc * (kwota - ((rabat / 100) * kwota));
                    kwoty[1] = wynik;
                    textBox_kwota_fin_2.Text = wynik.ToString("##,##0.00" + " zł");
                }
                if ((sender as TextBox) == textBox_kwota_3 || (sender as TextBox) == textBox_rabat_3 || (sender as TextBox) == textBox_ilosc_3)
                {
                    decimal.TryParse(textBox_kwota_3.Text, out kwota);
                    decimal.TryParse(textBox_rabat_3.Text, out rabat);
                    decimal.TryParse(textBox_ilosc_3.Text, out ilosc);
                    wynik = ilosc * (kwota - ((rabat / 100) * kwota));
                    kwoty[2] = wynik;
                    textBox_kwota_fin_3.Text = wynik.ToString("##,##0.00" + " zł");
                }
                if ((sender as TextBox) == textBox_kwota_4 || (sender as TextBox) == textBox_rabat_4 || (sender as TextBox) == textBox_ilosc_4)
                {
                    decimal.TryParse(textBox_kwota_4.Text, out kwota);
                    decimal.TryParse(textBox_rabat_4.Text, out rabat);
                    decimal.TryParse(textBox_ilosc_4.Text, out ilosc);
                    wynik = ilosc * (kwota - ((rabat / 100) * kwota));
                    kwoty[3] = wynik;
                    textBox_kwota_fin_4.Text = wynik.ToString("##,##0.00" + " zł");
                }
                if ((sender as TextBox) == textBox_kwota_5 || (sender as TextBox) == textBox_rabat_5 || (sender as TextBox) == textBox_ilosc_5)
                {
                    decimal.TryParse(textBox_kwota_5.Text, out kwota);
                    decimal.TryParse(textBox_rabat_5.Text, out rabat);
                    decimal.TryParse(textBox_ilosc_5.Text, out ilosc);
                    wynik = ilosc * (kwota - ((rabat / 100) * kwota));
                    kwoty[4] = wynik;
                    textBox_kwota_fin_5.Text = wynik.ToString("##,##0.00" + " zł");
                }
                if ((sender as TextBox) == textBox_kwota_6 || (sender as TextBox) == textBox_rabat_6 || (sender as TextBox) == textBox_ilosc_6)
                {
                    decimal.TryParse(textBox_kwota_6.Text, out kwota);
                    decimal.TryParse(textBox_rabat_6.Text, out rabat);
                    decimal.TryParse(textBox_ilosc_6.Text, out ilosc);
                    wynik = ilosc * (kwota - ((rabat / 100) * kwota));
                    kwoty[5] = wynik;
                    textBox_kwota_fin_6.Text = wynik.ToString("##,##0.00" + " zł");
                }

                sum = 0;
                foreach (decimal liczba in kwoty)
                {
                    sum += liczba;
                }
                if (comboBox_gratis.SelectedIndex != 0) sum += 1;

                if (checkBox_ekspo.Checked == true ||checkBox_zaplacono_calosc.Checked == true)                         // && comboBox_gratis.SelectedIndex!=0)
                    textBox_zadatek.Text = sum.ToString("##,##0.00");
                {
                    sum=Math.Round(sum, 2);                   
                    textBox_suma.Text = sum.ToString("##,##0.00" + " zł"); // no i wpisujemy łączną sumę
                }
            }
            catch (Exception)
            {

            }
        } // Obliczanie kwot z rabatem oraz sumy całościowej   

        private void CheckBox_zaplacono_calosc_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_zaplacono_calosc.Checked == true)
            {
                if (comboBox_gratis.SelectedIndex != 0) sum += 1;
                textBox_zadatek.Text = sum.ToString("##,##0.00" + " zł");
                checkBox_raty.Enabled = false;
                checkBox_raty.Checked = false;
            }
            else
            {
                checkBox_raty.Enabled = true;
                textBox_zadatek.Text = "0.00";
            }
        }

        private void Form_nowe_zamowienie_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (zamykanie == false)
            {
                if (MessageBox.Show("Czy anuloawć " + pytanie_przy_zamykaniu + " zamówienia?", "Ostrzeżenie !", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    return;
                }
                else
                    e.Cancel = true;
            }
            Metody_bazy.Uzupelnij_dataGrid_zamowienia(okno_Glowne.dataGridView_zamowienia, okno_Glowne.dateTimePicker_od.Text, okno_Glowne.dateTimePicker_do.Text, "nr_zamowienia", "DESC");
         } //łapanie zamykania okna

        private void CheckedListBox_transport_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Checked)
                for (int ix = 0; ix < checkedListBox_transport.Items.Count; ++ix)
                    if (e.Index != ix) checkedListBox_transport.SetItemChecked(ix, false);
            Color color = ColorTranslator.FromHtml("#f0f0f0");
            checkedListBox_transport.BackColor = color;
        }//wybieranie sposobu transportu      

        private void CheckedListBox_transport_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (checkedListBox_transport.GetItemChecked(2) == true && Okno_glowne.czy_edycja==false)
            {
                textBox_kwota_transportu.Enabled = true;
                textBox_kwota_transportu.Text = "0";
            }
             if (checkedListBox_transport.GetItemChecked(2) != true)
            {
                textBox_kwota_transportu.Enabled = false;
                textBox_kwota_transportu.Text = "0";

            }
            if (checkedListBox_transport.GetItemChecked(2) == true && Okno_glowne.czy_edycja == true)
                textBox_kwota_transportu.Enabled = true;

        }

        private void ComboBox_gratis_SelectedIndexChanged(object sender, EventArgs e)
        {
            TextBox_obliczanie_kwot(textBox_kwota_1, e);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            new PrintDialog().ShowDialog();
        }

        private void TextBox_termin_KeyPress(object sender, KeyPressEventArgs e)
        {

            if  ( !char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back) 
                {
                e.Handled = true;
            }
        }
    }
}
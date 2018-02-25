using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace SPOZ
{
    class Metody_bazy
    {
        public static string
            pytanie_sql = null,
            aktualne_miasto = null,
            aktualne_miasto_PL = null,
            ostati_w_tab,
            zamowienie = null,
            imie_nazwisko_uzytkownika = null;
        public static String[] zamowienia_tablica = null;
        public static int ilosc1 = 0, ilosc2 = 0, ilosc3 = 0, ilosc4 = 0, ilosc5 = 0, ilosc6 = 0, biezacy_wiersz_tabeli = 0;


        public static void Wczytanie_listy_sklepow_do_combobox(ComboBox lista_miast)
        {
            try
            {
                pytanie_sql = "SELECT * FROM `sklepy`";
                Polaczenie polaczenieMySQL = new Polaczenie();
                MySqlConnection polaczenie = polaczenieMySQL.Polacz();
                MySqlCommand pytanie = new MySqlCommand(pytanie_sql, polaczenie);
                MySqlDataReader wynik;
                wynik = pytanie.ExecuteReader();
                while (wynik.Read())
                {
                    string lista = wynik.GetString("id_sklepu");
                    lista += ". " + wynik.GetString("miejscowosc");
                    lista += ", " + wynik.GetString("adres1");
                    if (wynik.GetString("adres2") != "")
                        lista += ", " + wynik.GetString("adres2");
                    lista_miast.Items.Add(lista);
                }
                polaczenieMySQL.Zamknij(polaczenie);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Wczytanie_listy_sklepow_do_combobox");
            }
        }

        public static void Pobranie_aktualnego_miasta()
        {
            try
            {
                pytanie_sql = "SELECT * FROM `sklepy` WHERE id_sklepu='" + Properties.Settings.Default.id_wybranego_miasta + "'";
                Polaczenie polaczenieMySQL = new Polaczenie();
                MySqlConnection polaczenie = polaczenieMySQL.Polacz();
                MySqlCommand pytanie = new MySqlCommand(pytanie_sql, polaczenie);
                MySqlDataReader wynik;
                wynik = pytanie.ExecuteReader();
                wynik.Read();
                aktualne_miasto = wynik.GetString("miejscowosc");
                polaczenieMySQL.Zamknij(polaczenie);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Pobieranie ID i nazwy sklepu");
            }
        }

        #region LOGOWANIE i opcje towarzyszące kontom
        public static bool Czy_mail_jest_w_bazie(TextBox mail)
        {
            bool jest = false;
            try
            {
                int mail_baza = 0;
                pytanie_sql = "SELECT  COUNT( `adres_email`) AS ilosc FROM `uzytkownicy` WHERE `adres_email`='" + mail.Text + "';";
                Polaczenie polaczenieMySQL = new Polaczenie();
                MySqlConnection polaczenie = polaczenieMySQL.Polacz();
                MySqlCommand pytanie = new MySqlCommand(pytanie_sql, polaczenie);
                MySqlDataReader wynik;
                wynik = pytanie.ExecuteReader();
                wynik.Read();
                mail_baza = wynik.GetInt16("ilosc");
                polaczenieMySQL.Zamknij(polaczenie);
                if (mail_baza > 0)
                    jest = true;
            }
            catch (Exception) { }
            return jest;
        }

        public static void Nowy_sprzedawca(TextBox imie, TextBox nazwisko, TextBox mail, TextBox haslo, int id_sklepu)
        {
            Szyfrowanie_hasła szyfr = new Szyfrowanie_hasła();
            string haslo_po_SHA256 = szyfr.Szyfrowaine_hasła(haslo.Text);

            pytanie_sql = "INSERT INTO `uzytkownicy` (`imie`, `nazwisko`, `adres_email`, `haslo`, `id_miasta`) " +
                "VALUES ('" + imie.Text + "', '" + nazwisko.Text + "', '" + mail.Text + "', '" + haslo_po_SHA256  + "', '" + id_sklepu + "');";
            Polaczenie.SQL_insert_update(pytanie_sql);
            MessageBox.Show("Dodawanie sprzedawcy zakończyło się pomyślnie.", "Dodawanie sprzedawcy", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static bool Czy_pierwsze_logowanie(TextBox mail)
        {
            bool pierwsze = false;
            try
            {
                pytanie_sql = "SELECT `pierwsze_logowanie` FROM `uzytkownicy` WHERE `adres_email`='" + mail.Text + "';";
                Polaczenie polaczenieMySQL = new Polaczenie();
                MySqlConnection polaczenie = polaczenieMySQL.Polacz();
                MySqlCommand pytanie = new MySqlCommand(pytanie_sql, polaczenie);
                MySqlDataReader wynik;
                wynik = pytanie.ExecuteReader();
                wynik.Read();
                pierwsze = wynik.GetBoolean("pierwsze_logowanie");
            }
            catch (Exception)
            {
                pierwsze = false;
            }
            return pierwsze;
        }

        public static void Pobranie_maila_menadzera()
        {
            try
            {
                pytanie_sql = "SELECT `adres_email` FROM `uzytkownicy`  WHERE `Opis` = 'Menadżer'";
                Polaczenie polaczenieMySQL = new Polaczenie();
                MySqlConnection polaczenie = polaczenieMySQL.Polacz();
                MySqlCommand pytanie = new MySqlCommand(pytanie_sql, polaczenie);
                MySqlDataReader wynik;
                wynik = pytanie.ExecuteReader();
                wynik.Read();

                Properties.Settings.Default.mail_managera = wynik.GetString("adres_email");
                polaczenieMySQL.Zamknij(polaczenie);
            }
            catch (Exception){}
          
        }

        public static bool Logowanie_do_programu(TextBox mail, TextBox haslo)
        {
            Logowanie.zalogowany = false;
            string haslo_baza = null;
            try
            {
                pytanie_sql = "SELECT `haslo` FROM `uzytkownicy`  WHERE `adres_email` = '" + mail.Text + "'";
                Polaczenie polaczenieMySQL = new Polaczenie();
                MySqlConnection polaczenie = polaczenieMySQL.Polacz();
                MySqlCommand pytanie = new MySqlCommand(pytanie_sql, polaczenie);
                MySqlDataReader wynik;
                wynik = pytanie.ExecuteReader();
                wynik.Read();

                haslo_baza = wynik.GetString("haslo");
                polaczenieMySQL.Zamknij(polaczenie);


                Szyfrowanie_hasła szyfr = new Szyfrowanie_hasła();
                string haslo_po_SHA256 = szyfr.Szyfrowaine_hasła(haslo.Text);

                if (haslo_baza == haslo_po_SHA256)
                {
                    pytanie_sql = "SELECT *,`uzytkownicy`.`adres_email` AS mail_sprzed  FROM `uzytkownicy`,`sklepy` WHERE `uzytkownicy`.`adres_email`='" + mail.Text + "' " +
                        "AND `uzytkownicy`.`haslo`='" + haslo_po_SHA256 + "' AND `id_sklepu`=`uzytkownicy`.`id_miasta`";
                    polaczenie = polaczenieMySQL.Polacz();
                    pytanie = new MySqlCommand(pytanie_sql, polaczenie);
                    wynik = pytanie.ExecuteReader();
                    wynik.Read();

                    Properties.Settings.Default.id_uzytkownika = wynik.GetInt16("id_uzytkownika");
                    Properties.Settings.Default.id_wybranego_miasta = wynik.GetInt16("id_miasta");
                    Properties.Settings.Default.uprawnienia = wynik.GetInt16("uprawnienia");
                    Properties.Settings.Default.aktualne_miasto = Metody_lokalne.Usun_polskie_znaki(wynik.GetString("miejscowosc"));
                    Properties.Settings.Default.ostatnio_zalogowany = wynik.GetString("mail_sprzed");
                    string miasto_PL = wynik.GetString("miejscowosc");
                    miasto_PL += ", " + wynik.GetString("adres1");
                    if (wynik.GetString("adres2") != "")
                        miasto_PL += ", " + wynik.GetString("adres2");
                    Properties.Settings.Default.aktualne_miasto_PL = miasto_PL;
                    Properties.Settings.Default.Save();

                    imie_nazwisko_uzytkownika = wynik.GetString("imie");
                    imie_nazwisko_uzytkownika += " " + wynik.GetString("nazwisko");

                    polaczenieMySQL.Zamknij(polaczenie);

                    Logowanie.zalogowany = true;
                }
                else
                {
                    MessageBox.Show("Zostały wpisany błędny login lub hasło.", "Logowanie nie powidło się", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    haslo.SelectAll();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd logowania2.\n" + ex.Message);
            }
            return Logowanie.zalogowany;
        }

        public static void Zmiana_hasla_1_logowanie(TextBox stare, TextBox nowe)
        {
            try
            {
                Logowanie log = Application.OpenForms.OfType<Logowanie>().FirstOrDefault();
                pytanie_sql = "SELECT `haslo` FROM `uzytkownicy`  WHERE `adres_email` = '" + log.textBox_mail.Text + "'";
                Polaczenie polaczenieMySQL = new Polaczenie();
                MySqlConnection polaczenie = polaczenieMySQL.Polacz();
                MySqlCommand pytanie = new MySqlCommand(pytanie_sql, polaczenie);
                MySqlDataReader wynik;
                wynik = pytanie.ExecuteReader();
                wynik.Read();

                string haslo = wynik.GetString("haslo");

                polaczenieMySQL.Zamknij(polaczenie);

                Szyfrowanie_hasła szyfr = new Szyfrowanie_hasła();
                string stare_haslo_po_SHA256 = szyfr.Szyfrowaine_hasła(stare.Text);
                string nowe_haslo_po_SHA256 = szyfr.Szyfrowaine_hasła(nowe.Text);

                if (haslo == stare_haslo_po_SHA256)
                {
                    pytanie_sql = "UPDATE `uzytkownicy` SET `haslo`= '" + nowe_haslo_po_SHA256 + "' ,`pierwsze_logowanie`=0 WHERE `adres_email` = '" + log.textBox_mail.Text + "'";
                    Polaczenie.SQL_insert_update(pytanie_sql);
                    MessageBox.Show("Pomyślnie zmieniono hasło","Sukces",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
                else MessageBox.Show("Podane hasło różni się od poprzedniego.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void Zmiana_hasla(TextBox stare, TextBox nowe)
        {
            int id = Properties.Settings.Default.id_uzytkownika;
            try
            {
                pytanie_sql = "SELECT `haslo` FROM `uzytkownicy`  WHERE `id_uzytkownika` = '" +id + "'";
                Polaczenie polaczenieMySQL = new Polaczenie();
                MySqlConnection polaczenie = polaczenieMySQL.Polacz();
                MySqlCommand pytanie = new MySqlCommand(pytanie_sql, polaczenie);
                MySqlDataReader wynik;
                wynik = pytanie.ExecuteReader();
                wynik.Read();

                string haslo = wynik.GetString("haslo");

                polaczenieMySQL.Zamknij(polaczenie);

                Szyfrowanie_hasła szyfr = new Szyfrowanie_hasła();
                string stare_haslo_po_SHA256 = szyfr.Szyfrowaine_hasła(stare.Text);
                string nowe_haslo_po_SHA256 = szyfr.Szyfrowaine_hasła(nowe.Text);

                if (haslo == stare_haslo_po_SHA256)
                {
                    pytanie_sql = "UPDATE `uzytkownicy` SET `haslo`= '" + nowe_haslo_po_SHA256 + "' WHERE `uzytkownicy`.`id_uzytkownika` = '" + id + "';";
                    Polaczenie.SQL_insert_update(pytanie_sql);
                    MessageBox.Show("Pomyślnie zmieniono hasło", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else MessageBox.Show("Podane hasło różni się od poprzedniego.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void Reset_hasla(TextBox nowe)
        {
            try
            {
                Logowanie log = Application.OpenForms.OfType<Logowanie>().FirstOrDefault();
                Szyfrowanie_hasła szyfr = new Szyfrowanie_hasła();
                string nowe_haslo_po_SHA256 = szyfr.Szyfrowaine_hasła(nowe.Text);
                pytanie_sql = "UPDATE `uzytkownicy` SET `haslo`= '" + nowe_haslo_po_SHA256 + "' WHERE `adres_email` = '" + log.textBox_mail.Text + "'";
                Polaczenie.SQL_insert_update(pytanie_sql);
                MessageBox.Show("Pomyślnie zmieniono hasło", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region Sprzedawca
        public static void Wczytanie_listy_sprzedawcow_do_combobox(ComboBox lista_sprzedawcow)
        {
            try
            {
                pytanie_sql = "SELECT * FROM `uzytkownicy`";
                Polaczenie polaczenieMySQL = new Polaczenie();
                MySqlConnection polaczenie = polaczenieMySQL.Polacz();
                MySqlCommand pytanie = new MySqlCommand(pytanie_sql, polaczenie);
                MySqlDataReader wynik;
                wynik = pytanie.ExecuteReader();
                while (wynik.Read())
                {
                    string lista = wynik.GetString("imie");
                    lista += " " + wynik.GetString("nazwisko");
                    lista += ", " + wynik.GetString("adres_email");
                    lista_sprzedawcow.Items.Add(lista);
                }
                polaczenieMySQL.Zamknij(polaczenie);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Wczytanie_listy_sklepow_do_combobox");
            }
        }

        public static int Pobranie_id_sprzedawcy_z_combo(ComboBox sprzed)
        {

            pytanie_sql = "SELECT `id_uzytkownika` FROM `uzytkownicy`  WHERE `adres_email` = '" + sprzed.Text.Substring(2 + sprzed.Text.IndexOf(",")) + "';";
            Polaczenie polaczenieMySQL = new Polaczenie();
            MySqlConnection polaczenie = polaczenieMySQL.Polacz();
            MySqlCommand pytanie = new MySqlCommand(pytanie_sql, polaczenie);
            MySqlDataReader wynik;
            wynik = pytanie.ExecuteReader();
            wynik.Read();

            int id = wynik.GetInt16("id_uzytkownika");

            polaczenieMySQL.Zamknij(polaczenie);
            return id;
        }

        public static void Zmiana_sklepu_sprzedawcy(int id, ComboBox sprzed)
        {
            try
            {
                pytanie_sql = "UPDATE `uzytkownicy` SET `id_miasta`= '" + id + "' WHERE `uzytkownicy`.`id_uzytkownika` = '" + Pobranie_id_sprzedawcy_z_combo(sprzed) + "';";
                Polaczenie.SQL_insert_update(pytanie_sql);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "zmianai sklepu");
            }
        }

        public static void Usun_sprzedawce(ComboBox sprzed)
        {
            pytanie_sql = "DELETE FROM `uzytkownicy`  WHERE `uzytkownicy`.`id_uzytkownika` = " + Pobranie_id_sprzedawcy_z_combo(sprzed) + ";";
            Polaczenie.SQL_delete(pytanie_sql);
        }
        #endregion

        #region Gratis
        public static int Pobranie_id_gratisu_z_combo(ComboBox gratis)
        {

            pytanie_sql = "SELECT `id_gratisu` FROM `gratisy`  WHERE `id_gratisu` = '" + gratis.Text.Substring(0,gratis.Text.IndexOf('.')) + "';";
            Polaczenie polaczenieMySQL = new Polaczenie();
            MySqlConnection polaczenie = polaczenieMySQL.Polacz();
            MySqlCommand pytanie = new MySqlCommand(pytanie_sql, polaczenie);
            MySqlDataReader wynik;
            wynik = pytanie.ExecuteReader();
            wynik.Read();

            int id = wynik.GetInt16("id_gratisu");

            polaczenieMySQL.Zamknij(polaczenie);
            return id;
        }

        public static bool Unikalna_nazwa_gratisu(TextBox nazwa)
        {
            bool jest = false;
            try
            {
                int mail_baza = 0, aktywny=0;
                pytanie_sql = "SELECT  COUNT(`nazwa_gratisu`) , `aktywny`  FROM `gratisy` WHERE `nazwa_gratisu`='" + nazwa.Text + "';";
                Polaczenie polaczenieMySQL = new Polaczenie();
                MySqlConnection polaczenie = polaczenieMySQL.Polacz();
                MySqlCommand pytanie = new MySqlCommand(pytanie_sql, polaczenie);
                MySqlDataReader wynik;
                wynik = pytanie.ExecuteReader();
                wynik.Read();
                mail_baza = wynik.GetInt16(0);
                aktywny = wynik.GetInt16(1);
                polaczenieMySQL.Zamknij(polaczenie);
                if (mail_baza > 0 && aktywny==1)
                    jest = true;
            }
            catch (Exception) { }
            return jest;
        }

        public static void Dodaj_gratis(TextBox nazwa, TextBox kwota, TextBox rabat)
        {
            if (Unikalna_nazwa_gratisu(nazwa) == false)
            {
                pytanie_sql = "INSERT INTO `gratisy` (`nazwa_gratisu`, `cena`, `rabat`) " +
               "VALUES ('" + nazwa.Text + "', '" + kwota.Text + "', '" + rabat.Text + "');";
                Polaczenie.SQL_insert_update(pytanie_sql);
                MessageBox.Show("Gratis został zapisany.", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Gratis o takiej nazwie już istnieje i jest aktywny.");
        }

        public static bool aktywny;
        public static void Wczytanie_gratisu_do_edycji(ComboBox combo_gratis)
        {
            pytanie_sql = "SELECT * FROM `gratisy`  WHERE `id_gratisu` = '" + Pobranie_id_gratisu_z_combo(combo_gratis) + "';";
            Polaczenie polaczenieMySQL = new Polaczenie();
            MySqlConnection polaczenie = polaczenieMySQL.Polacz();
            MySqlCommand pytanie = new MySqlCommand(pytanie_sql, polaczenie);
            MySqlDataReader wynik;
            wynik = pytanie.ExecuteReader();
            wynik.Read();

            nazwa_gratisu = wynik.GetString("nazwa_gratisu");
            aktywny = wynik.GetBoolean("aktywny");

            polaczenieMySQL.Zamknij(polaczenie);
        }

        public static void Edycja_gratisu(TextBox nazwa,  CheckBox aktywny, ComboBox combo_rabat)
        {
            pytanie_sql = "UPDATE `gratisy` SET `nazwa_gratisu`= '" + nazwa.Text + "', `aktywny`=" + aktywny.Checked + " WHERE `id_gratisu` = '" + Pobranie_id_gratisu_z_combo(combo_rabat) + "';";
            Polaczenie.SQL_insert_update(pytanie_sql);
        }

        public static void Dezaktywuj_gratis(ComboBox combo_gratis)
        {
            pytanie_sql = "UPDATE `gratisy` SET  `aktywny`=0" + " WHERE `id_gratisu` = '" + Pobranie_id_gratisu_z_combo(combo_gratis) + "';";
            Polaczenie.SQL_insert_update(pytanie_sql);
        }
        
        public static void Wczytanie_listy_gratisow_do_combobox(ComboBox gratis)
        {
            try
            {
                gratis.Items.Clear();

                pytanie_sql = "SELECT * FROM `gratisy` WHERE `aktywny`=1";
                Polaczenie polaczenieMySQL = new Polaczenie();
                MySqlConnection polaczenie = polaczenieMySQL.Polacz();
                MySqlCommand pytanie = new MySqlCommand(pytanie_sql, polaczenie);
                MySqlDataReader wynik;
                wynik = pytanie.ExecuteReader();

                while (wynik.Read())
                {
                    string lista = wynik.GetString("id_gratisu");
                    lista +="."+ wynik.GetString("nazwa_gratisu");

                    gratis.Items.Add(lista);
                }
                polaczenieMySQL.Zamknij(polaczenie);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Wczytanie_listy_sklepow_do_combobox");
            }
        }

        public static string nazwa_gratisu;
        public static Decimal cena_gratisu, rabat_gratisu;
        public static int id_gratisu;

        public static void Wczytanie_gratisu_o_id(int id_gratis)
        {
            try
            {
                pytanie_sql = "SELECT * FROM `gratisy` WHERE `id_gratisu`=" + id_gratis;
                Polaczenie polaczenieMySQL = new Polaczenie();
                MySqlConnection polaczenie = polaczenieMySQL.Polacz();
                MySqlCommand pytanie = new MySqlCommand(pytanie_sql, polaczenie);
                MySqlDataReader wynik;
                wynik = pytanie.ExecuteReader();

                while (wynik.Read())
                {
                    nazwa_gratisu = wynik.GetString(1);
                    cena_gratisu = wynik.GetDecimal(2);
                    rabat_gratisu = wynik.GetDecimal(3);
                }
                polaczenieMySQL.Zamknij(polaczenie);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Wczytanie_listy_sklepow_do_combobox");
            }
        }
        #endregion

        #region UZUPEŁNIANIE DGV I SZUKANIE W NIM
        public static int metoda_szukania = 0;
        public static void Uzupelnij_dataGrid_zamowienia(DataGridView dataGrid, string data_od, string data_do, string sortowanie, string typ_sortowanie)
        {
            //try
            //{
                if (Properties.Settings.Default.aktualne_miasto != "" && Logowanie.zalogowany==true)
                {
                     pytanie_sql = "SELECT " +
                        "`Nr_zamowienia` AS 'Numer zamówienia.', " +
                        "`Imie_Nazwisko` AS 'Imię i nazwisko', " +
                        " CONCAT_WS(', ',`miejscowosc`,`kod_pocztowy`,`ulica_nr`)  AS Adres," +
                        "`Telefon`, " +
                        "`Zamowienie` AS 'Zamówienie', " +                                          
                        " CONCAT_WS(' ',`rodzaj_transportu`,`koszt_transportu`)  AS Transport," +
                        " DATE_FORMAT(`Data_przyjecia`, '%Y-%m-%d') AS 'Data przyjecia'," +
                        "`Zadatek`," +
                        " DATE_FORMAT(`Data_rozliczenia`, '%Y-%m-%d') AS 'Data rozliczenia'," +
                        "`Dodatkowe_uwagi` AS 'Dodatkowe uwagi'," +
                        "`Raty`,               " +
                        " Round((`ilosc_p_1` *(`kwota_p_1` -((`rabat_p_1` / 100) * `kwota_p_1`))+ " +
                        "`ilosc_p_2` *(`kwota_p_2` -((`rabat_p_2` / 100) * `kwota_p_2`))+ " +
                        "`ilosc_p_3` *(`kwota_p_3` -((`rabat_p_3` / 100) * `kwota_p_3`))+ " +
                        "`ilosc_p_4` *(`kwota_p_4` -((`rabat_p_4` / 100) * `kwota_p_4`))+" +
                        "`ilosc_p_5` *(`kwota_p_5` -((`rabat_p_5` / 100) * `kwota_p_5`))+ " +
                        "`ilosc_p_6` *(`kwota_p_6` -((`rabat_p_6` / 100) * `kwota_p_6`)) ),2)AS 'Kwota łączna'," +
                        " Round(( `ilosc_p_1` *(`kwota_p_1` -((`rabat_p_1` / 100) * `kwota_p_1`))+" +
                        "`ilosc_p_2` *(`kwota_p_2` -((`rabat_p_2` / 100) * `kwota_p_2`))+ " +
                        "`ilosc_p_3` *(`kwota_p_3` -((`rabat_p_3` / 100) * `kwota_p_3`))+ " +
                        "`ilosc_p_4` *(`kwota_p_4` -((`rabat_p_4` / 100) * `kwota_p_4`))+ " +
                        "`ilosc_p_5` *(`kwota_p_5` -((`rabat_p_5` / 100) * `kwota_p_5`))+ " +
                        "`ilosc_p_6` *(`kwota_p_6` -((`rabat_p_6` / 100) * `kwota_p_6`))-zadatek),2) AS 'Pozostało do zapłaty', " +
                        "`Rozliczony`, " +
                        "`Gratis`," +
                        "`towar_na_stanie`," +
                        "`numer_fv`" +
                        " FROM " + Properties.Settings.Default.aktualne_miasto + " WHERE  `Data_przyjecia` BETWEEN '" + data_od + "' AND '" + data_do + "'  ORDER BY  `"+sortowanie+ "` "+ typ_sortowanie;

                    Polaczenie.SQL_dataGridView(dataGrid, pytanie_sql);
                    Wyciaganie_ilosci_zamowionych_produktow(dataGrid);
                    metoda_szukania = 1;
                }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "datagridview zamowień");
            //}
            
        }

        public static void Szukanie_dynamiczne_texbox(DataGridView dataGrid, TextBox pasek, string sortowanie, string typ_sortowanie)
        {
            try
            {
                pytanie_sql = "SELECT " +
                    "`Nr_zamowienia` AS 'Numer zamówienia.', " +
                    "`Imie_Nazwisko` AS 'Imię i nazwisko', " +
                    " CONCAT_WS(', ',`miejscowosc`,`kod_pocztowy`,`ulica_nr`)  AS Adres," +
                    "`Telefon`, " +
                    "`Zamowienie` AS 'Zamówienie', " +
                    " CONCAT_WS(' ',`rodzaj_transportu`,`koszt_transportu`)  AS Transport," +
                    " DATE_FORMAT(`Data_przyjecia`, '%Y-%m-%d') AS 'Data przyjecia'," +
                    "`Zadatek`," +
                    " DATE_FORMAT(`Data_rozliczenia`, '%Y-%m-%d') AS 'Data rozliczenia'," +
                    "`Dodatkowe_uwagi` AS 'Dodatkowe uwagi'," +
                    "`Raty`," +
                    " Round((`ilosc_p_1` *(`kwota_p_1` -((`rabat_p_1` / 100) * `kwota_p_1`))+ " +
                    "`ilosc_p_2` *(`kwota_p_2` -((`rabat_p_2` / 100) * `kwota_p_2`))+ " +
                    "`ilosc_p_3` *(`kwota_p_3` -((`rabat_p_3` / 100) * `kwota_p_3`))+ " +
                    "`ilosc_p_4` *(`kwota_p_4` -((`rabat_p_4` / 100) * `kwota_p_4`))+" +
                    "`ilosc_p_5` *(`kwota_p_5` -((`rabat_p_5` / 100) * `kwota_p_5`))+ " +
                    "`ilosc_p_6` *(`kwota_p_6` -((`rabat_p_6` / 100) * `kwota_p_6`)) ),2)AS 'Kwota łączna'," +
                    " Round(( `ilosc_p_1` *(`kwota_p_1` -((`rabat_p_1` / 100) * `kwota_p_1`))+" +
                    " `ilosc_p_2` *(`kwota_p_2` -((`rabat_p_2` / 100) * `kwota_p_2`))+ " +
                    "`ilosc_p_3` *(`kwota_p_3` -((`rabat_p_3` / 100) * `kwota_p_3`))+ " +
                    "`ilosc_p_4` *(`kwota_p_4` -((`rabat_p_4` / 100) * `kwota_p_4`))+ " +
                    "`ilosc_p_5` *(`kwota_p_5` -((`rabat_p_5` / 100) * `kwota_p_5`))+ " +
                    "`ilosc_p_6` *(`kwota_p_6` -((`rabat_p_6` / 100) * `kwota_p_6`))-zadatek),2) AS 'Pozostało do zapłaty' ,  " +
                    "`Rozliczony`, " +
                    "`Gratis`," +
                    "`towar_na_stanie`," +
                    "`numer_fv`" +
                    " FROM " +
                    Properties.Settings.Default.aktualne_miasto + " WHERE " +
                    "`Nr_zamowienia`LIKE '%" + pasek.Text + "%'" +
                    " OR Imie_Nazwisko LIKE '%" + pasek.Text + "%'" +
                    " OR Telefon LIKE '%" + pasek.Text + "%' " +
                    " ORDER BY  `" + sortowanie + "` " + typ_sortowanie;
                Polaczenie.SQL_dataGridView(dataGrid, pytanie_sql);
                Wyciaganie_ilosci_zamowionych_produktow(dataGrid);
                metoda_szukania = 2;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Dynamiczne<>pole tekstowe");
            }
        }

        public static void Szukanie_dynamiczne_nie_rozliczone(DataGridView dataGrid, string rozliczony, string data_od, string data_do, string sortowanie, string typ_sortowanie)
        {
            try
            {
                pytanie_sql = "SELECT " +
                    "`Nr_zamowienia` AS 'Numer zamówienia.', " +
                    "`Imie_Nazwisko` AS 'Imię i nazwisko', " +
                    " CONCAT_WS(', ',`miejscowosc`,`ulica_nr`,`kod_pocztowy`)  AS Adres," +
                    "`Telefon`, " +
                    "`Zamowienie` AS 'Zamówienie', " +
                    " CONCAT_WS(' ',`rodzaj_transportu`,`koszt_transportu`)  AS Transport," +
                    " DATE_FORMAT(`Data_przyjecia`, '%Y-%m-%d') AS 'Data przyjecia'," +
                    "`Zadatek`," +
                    " DATE_FORMAT(`Data_rozliczenia`, '%Y-%m-%d') AS 'Data rozliczenia'," +
                    "`Dodatkowe_uwagi` AS 'Dodatkowe uwagi'," +
                    "`Raty`," +
                    " Round((`ilosc_p_1` *(`kwota_p_1` -((`rabat_p_1` / 100) * `kwota_p_1`))+ " +
                    "`ilosc_p_2` *(`kwota_p_2` -((`rabat_p_2` / 100) * `kwota_p_2`))+ " +
                    "`ilosc_p_3` *(`kwota_p_3` -((`rabat_p_3` / 100) * `kwota_p_3`))+ " +
                    "`ilosc_p_4` *(`kwota_p_4` -((`rabat_p_4` / 100) * `kwota_p_4`))+" +
                    "`ilosc_p_5` *(`kwota_p_5` -((`rabat_p_5` / 100) * `kwota_p_5`))+ " +
                    "`ilosc_p_6` *(`kwota_p_6` -((`rabat_p_6` / 100) * `kwota_p_6`)) ),2)AS 'Kwota łączna'," +
                    " Round(( `ilosc_p_1` *(`kwota_p_1` -((`rabat_p_1` / 100) * `kwota_p_1`))+" +
                    "`ilosc_p_2` *(`kwota_p_2` -((`rabat_p_2` / 100) * `kwota_p_2`))+ " +
                    "`ilosc_p_3` *(`kwota_p_3` -((`rabat_p_3` / 100) * `kwota_p_3`))+ " +
                    "`ilosc_p_4` *(`kwota_p_4` -((`rabat_p_4` / 100) * `kwota_p_4`))+ " +
                    "`ilosc_p_5` *(`kwota_p_5` -((`rabat_p_5` / 100) * `kwota_p_5`))+ " +
                    "`ilosc_p_6` *(`kwota_p_6` -((`rabat_p_6` / 100) * `kwota_p_6`))-zadatek),2) AS 'Pozostało do zapłaty' ,  " +
                    "`Rozliczony`, " +
                    "`Gratis`," +
                    "`towar_na_stanie`," +
                    "`numer_fv`" +
                    " FROM " +
                    Properties.Settings.Default.aktualne_miasto + " WHERE  `Data_przyjecia` BETWEEN '"+data_od+"' AND '"+data_do+"' AND  `Rozliczony`=" + rozliczony +
                    " ORDER BY  `" + sortowanie + "` " + typ_sortowanie;
                Polaczenie.SQL_dataGridView(dataGrid, pytanie_sql);
                Wyciaganie_ilosci_zamowionych_produktow(dataGrid);
                metoda_szukania = 3;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Dynamiczne<>pole tekstowe");
            }
        }

        public static void Zmien_towar_na_stanie(int stan)
        {
            pytanie_sql = "UPDATE `" + Properties.Settings.Default.aktualne_miasto + "` SET `towar_na_stanie`= " + stan + " " +
                "WHERE `" + Properties.Settings.Default.aktualne_miasto + "`.`Id_zamowienia` = " + ID_z_nr_zamowienia + "; ";
            Polaczenie.SQL_insert_update(pytanie_sql);
        }
        #endregion

        #region ZAMÓWIENIA
        //zmienne zeby załadować zamówienie do edycji
        public static string biezacy_nr_zamowienia, imie_nazwisko, miejscowosc, kod_pocztowy, ulica_nr, uwagi, telefon, ilosc_p_1, ilosc_p_2, ilosc_p_3, ilosc_p_4, ilosc_p_5, ilosc_p_6, ilosc_produktow_combo, 
           adres_dostawy, kwota_p_1, rabat_p_1, kwota_p_2, rabat_p_2, kwota_p_3, rabat_p_3, kwota_p_4, rabat_p_4, kwota_p_5, rabat_p_5, kwota_p_6, rabat_p_6, zadatek, termin_realizacji, koszt_transportu, rodzaj_transportu, ID_z_nr_zamowienia;
        public static DateTime data_przyjecia;
        public static bool raty, zaplacono_calosc;
        public static int gratis;

        public static void Pobranie_ID_z_nr_zamowienia()
        {
            try
            {
                pytanie_sql = "SELECT `Id_zamowienia` FROM " + Properties.Settings.Default.aktualne_miasto + " WHERE `Nr_zamowienia`='" + biezacy_nr_zamowienia + "'";
                Polaczenie polaczenieMySQL = new Polaczenie();
                MySqlConnection polaczenie = polaczenieMySQL.Polacz();
                MySqlCommand pytanie = new MySqlCommand(pytanie_sql, polaczenie);
                MySqlDataReader wynik;
                wynik = pytanie.ExecuteReader();

                wynik.Read();

                ID_z_nr_zamowienia = wynik.GetString("Id_zamowienia");

                polaczenieMySQL.Zamknij(polaczenie);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Pobieranie ID");

            }
        }

        public static void Wczytanie_zamowienia_do_edycji()
        {
            try
            {
                if (Properties.Settings.Default.aktualne_miasto != "")
                {
                    pytanie_sql = "SELECT *, DATE_FORMAT(`Data_przyjecia`, '%Y-%m-%d') AS 'Data przyjecia' FROM " + Properties.Settings.Default.aktualne_miasto + " WHERE  `Id_zamowienia`=" + ID_z_nr_zamowienia;
                    Polaczenie polaczenieMySQL = new Polaczenie();
                    MySqlConnection polaczenie = polaczenieMySQL.Polacz();
                    MySqlCommand pytanie = new MySqlCommand(pytanie_sql, polaczenie);
                    MySqlDataReader wynik;
                    wynik = pytanie.ExecuteReader();
                    wynik.Read();
                    biezacy_nr_zamowienia = wynik.GetString("Nr_zamowienia");
                    imie_nazwisko = wynik.GetString("Imie_Nazwisko");
                    miejscowosc = wynik.GetString("miejscowosc");
                    kod_pocztowy = wynik.GetString("kod_pocztowy");
                    ulica_nr = wynik.GetString("ulica_nr");
                    uwagi = wynik.GetString("Dodatkowe_uwagi");
                    telefon = wynik.GetString("Telefon");
                    ilosc_p_1 = wynik.GetString("ilosc_p_1");
                    ilosc_p_2 = wynik.GetString("ilosc_p_2");
                    ilosc_p_3 = wynik.GetString("ilosc_p_3");
                    ilosc_p_4 = wynik.GetString("ilosc_p_4");
                    ilosc_p_5 = wynik.GetString("ilosc_p_5");
                    ilosc_p_6 = wynik.GetString("ilosc_p_6");
                    kwota_p_1 = wynik.GetString("kwota_p_1");
                    rabat_p_1 = wynik.GetString("rabat_p_1");
                    kwota_p_2 = wynik.GetString("kwota_p_2");
                    rabat_p_2 = wynik.GetString("rabat_p_2");
                    kwota_p_3 = wynik.GetString("kwota_p_3");
                    rabat_p_3 = wynik.GetString("rabat_p_3");
                    kwota_p_4 = wynik.GetString("kwota_p_4");
                    rabat_p_4 = wynik.GetString("rabat_p_4");
                    kwota_p_5 = wynik.GetString("kwota_p_5");
                    rabat_p_5 = wynik.GetString("rabat_p_5");
                    kwota_p_6 = wynik.GetString("kwota_p_6");
                    rabat_p_6 = wynik.GetString("rabat_p_6");
                    zadatek = wynik.GetString("Zadatek");
                    data_przyjecia = wynik.GetDateTime("Data przyjecia");
                    raty = wynik.GetBoolean("Raty");
                    adres_dostawy = wynik.GetString("adres_dostawy");
                    zaplacono_calosc = wynik.GetBoolean("Zaplacono_calosc");
                    termin_realizacji = wynik.GetString("Przewidywany_termin_realizacji");
                    rodzaj_transportu = wynik.GetString("Rodzaj_transportu");
                    koszt_transportu = wynik.GetString("Koszt_transportu");
                    gratis = wynik.GetInt16("Gratis");

                    if (ilosc_p_1 != "0")
                    { ilosc_produktow_combo = "1";

                        if (ilosc_p_2 != "0")
                        { ilosc_produktow_combo = "2";

                            if (ilosc_p_3 != "0")
                            { ilosc_produktow_combo = "3";

                                if (ilosc_p_4 != "0")
                                { ilosc_produktow_combo = "4";

                                    if (ilosc_p_5 != "0")
                                    { ilosc_produktow_combo = "5";

                                        if (ilosc_p_6 != "0")
                                        { ilosc_produktow_combo = "6"; }
                                    }
                                    
                                }
                            }
                        }
                    }
                    polaczenieMySQL.Zamknij(polaczenie);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Wyciąganie");
            }
        }

        public static void Aktualizacja_zamowienia(TextBox Imie_Nazwisko, TextBox Miejscowosc, MaskedTextBox Kod_pocztowy, TextBox Ulica_nr, TextBox Telefon, String Zamowienie, TextBox Dodatkowe_uwagi, 
            string Zadatek, DateTimePicker Data_przyjecia, String Data_realizacji, CheckBox Raty, TextBox adres_dostawy, int rozliczony, 
            string kwota_p_1, string ilosc_p_1, string rabat_p_1, string kwota_p_2, string ilosc_p_2, string rabat_p_2, string kwota_p_3, string ilosc_p_3, string rabat_p_3,
            string kwota_p_4, string ilosc_p_4, string rabat_p_4, string kwota_p_5, string ilosc_p_5, string rabat_p_5, string kwota_p_6, string ilosc_p_6, string rabat_p_6,
            CheckBox zaplacono_calosc, TextBox termin_realizacji, CheckedListBox rodzaj_transportu, TextBox koszt_transportu, ComboBox gratis)
        {
            string str = null;
            pytanie_sql = "UPDATE `" + Properties.Settings.Default.aktualne_miasto + "` SET " +
                "`Imie_Nazwisko`='" + Imie_Nazwisko.Text + "'," +
                "`miejscowosc`='" + Miejscowosc.Text + "'," +
                "`kod_pocztowy`='" + Kod_pocztowy.Text + "'," +
                "`ulica_nr`='" + Ulica_nr.Text + "',";
                if (Imie_Nazwisko.Text!= "Sprzedaż z ekspozycji")
                pytanie_sql +="`Telefon`=" + Telefon.Text + ",";
                pytanie_sql += "`Zamowienie`='" + Zamowienie + "'," +
                "`Data_przyjecia`='" + Data_przyjecia.Text + "'," +
                "`Zadatek`=" + Convert.ToDecimal(Zadatek) + "," +
                "`Data_rozliczenia`='" + Data_realizacji + "'," +
                "`Dodatkowe_uwagi`='" + Dodatkowe_uwagi.Text + "'," +
                "`Raty`=" + Raty.Checked + "," +
                "`adres_dostawy`='" + adres_dostawy.Text + "'," +
                "`Rozliczony`=" + rozliczony + "," +
                "`kwota_p_1`=" + Convert.ToDecimal(kwota_p_1) + ", `ilosc_p_1`=" + ilosc_p_1 + ", `rabat_p_1`=" + rabat_p_1 + "," +
                "`kwota_p_2`=" + Convert.ToDecimal(kwota_p_2) + ", `ilosc_p_2`=" + ilosc_p_2 + ", `rabat_p_2`=" + rabat_p_2 + "," +
                "`kwota_p_3`=" + Convert.ToDecimal(kwota_p_3) + ", `ilosc_p_3`=" + ilosc_p_3 + ", `rabat_p_3`=" + rabat_p_3 + "," +
                "`kwota_p_4`=" + Convert.ToDecimal(kwota_p_4) + ", `ilosc_p_4`=" + ilosc_p_4 + ", `rabat_p_4`=" + rabat_p_4 + "," +
                "`kwota_p_5`=" + Convert.ToDecimal(kwota_p_5) + ", `ilosc_p_5`=" + ilosc_p_5 + ", `rabat_p_5`=" + rabat_p_5 + "," +
                "`kwota_p_6`=" + Convert.ToDecimal(kwota_p_6) + ", `ilosc_p_6`=" + ilosc_p_6 + ", `rabat_p_6`=" + rabat_p_6 + "," +
                "`Zaplacono_calosc`=" + zaplacono_calosc.Checked + "," +
                "`Przewidywany_termin_realizacji`='" + termin_realizacji.Text + "',";
            for (int i = 0; i < rodzaj_transportu.Items.Count; i++)           
                if (rodzaj_transportu.GetItemChecked(i))                
                     str = (string)rodzaj_transportu.Items[i];
            pytanie_sql += "`Rodzaj_transportu`='" + str + "'," +
                "`Koszt_transportu`='" + koszt_transportu.Text + "'," +
                "`Gratis`='" + gratis.SelectedIndex + "'" +
                " WHERE `" + Properties.Settings.Default.aktualne_miasto + "`.`Id_zamowienia` = " + ID_z_nr_zamowienia + ";";
            Polaczenie.SQL_insert_update(pytanie_sql);
        }

        public static void Rozliczanie_zamowienia_z_menuDGV(DateTimePicker data_rozliczenia)
        {
            try
            {
                pytanie_sql = "UPDATE " + Properties.Settings.Default.aktualne_miasto + " SET `Data_rozliczenia` = '" + data_rozliczenia.Text + "', `Rozliczony`=1 " +
                    "WHERE `" + Properties.Settings.Default.aktualne_miasto + "`.`Id_zamowienia` = " + ID_z_nr_zamowienia + ";";
                Polaczenie.SQL_insert_update(pytanie_sql);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Rozliczanie");
            }
        }

        public static bool Doplata_do_zamowienia_z_menuDGV(TextBox doplata, DataGridView DGV)
        {
            bool sukces = true;
            try
            { 
                 pytanie_sql = "SELECT `Zadatek`," +
                     " Round(( `ilosc_p_1` *(`kwota_p_1` -((`rabat_p_1` / 100) * `kwota_p_1`))+" +
                    " `ilosc_p_2` *(`kwota_p_2` -((`rabat_p_2` / 100) * `kwota_p_2`))+ " +
                    "`ilosc_p_3` *(`kwota_p_3` -((`rabat_p_3` / 100) * `kwota_p_3`))+ " +
                    "`ilosc_p_4` *(`kwota_p_4` -((`rabat_p_4` / 100) * `kwota_p_4`))+ " +
                    "`ilosc_p_5` *(`kwota_p_5` -((`rabat_p_5` / 100) * `kwota_p_5`))+ " +
                    "`ilosc_p_6` *(`kwota_p_6` -((`rabat_p_6` / 100) * `kwota_p_6`))-zadatek),2) AS 'Pozostało do zapłaty'"+
                    " FROM " + Properties.Settings.Default.aktualne_miasto + " WHERE `" + Properties.Settings.Default.aktualne_miasto + "`.`Id_zamowienia` = " + ID_z_nr_zamowienia + ";";
                Polaczenie polaczenieMySQL = new Polaczenie();
                MySqlConnection polaczenie = polaczenieMySQL.Polacz();
                MySqlCommand pytanie = new MySqlCommand(pytanie_sql, polaczenie);
                MySqlDataReader wynik;
                wynik = pytanie.ExecuteReader();
                wynik.Read();
                decimal zadatek = wynik.GetDecimal("Zadatek");
                decimal pozostało =1+ wynik.GetDecimal("Pozostało do zapłaty");
                polaczenieMySQL.Zamknij(polaczenie);
                 if (Convert.ToDecimal(doplata.Text) < pozostało)
                {
                    pytanie_sql = "UPDATE " + Properties.Settings.Default.aktualne_miasto + " SET `Zadatek` = `Zadatek` + '" + doplata.Text +
                  "' WHERE `" + Properties.Settings.Default.aktualne_miasto + "`.`Id_zamowienia` = " + ID_z_nr_zamowienia + ";";
                    sukces = true;
                }
                else if (Convert.ToDecimal(doplata.Text) == pozostało)
                {
                    MessageBox.Show("Przy dopłacaniu całej pozostałej należności, należy użyć opcji 'Rozlicz'.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    sukces = false;
                }
                else
                {
                    MessageBox.Show("Zadatek nie może być większy od pozostałej kwoty do zapłaty.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    sukces = false;
                }
                Polaczenie.SQL_insert_update(pytanie_sql);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Doplata_do_zamowienia_z_menuDGV");
            }
            return sukces;
        }

        public static void Nowe_zamowienie(String Nr_zamowienia, TextBox Imie_Nazwisko, TextBox Miejscowosc, MaskedTextBox Kod_pocztowy, TextBox Ulica_nr, TextBox Telefon, String Zamowienie, TextBox Dodatkowe_uwagi,
          string Zadatek, DateTimePicker Data_przyjecia, String Data_realizacji, CheckBox Raty, TextBox adres_dostawy, int rozliczony,
          string kwota_p_1, string ilosc_p_1, string rabat_p_1, string kwota_p_2, string ilosc_p_2, string rabat_p_2, string kwota_p_3, string ilosc_p_3, string rabat_p_3,
          string kwota_p_4, string ilosc_p_4, string rabat_p_4, string kwota_p_5, string ilosc_p_5, string rabat_p_5, string kwota_p_6, string ilosc_p_6, string rabat_p_6,
          CheckBox zaplacono_calosc, string termin_realizacji, CheckedListBox rodzaj_transportu, string koszt_transportu, ComboBox gratis, int towar)
        {
            try
            {
                string str = null;

                pytanie_sql = "INSERT INTO " +
                    Properties.Settings.Default.aktualne_miasto +
                    "(`Nr_zamowienia`, " +
                    "`Imie_Nazwisko`," +
                    "`miejscowosc`," +
                    "`kod_pocztowy`," +
                    "`ulica_nr`," +
                    "`Telefon`, " +
                    "`Zamowienie`, " +
                    "`Data_przyjecia`, " +
                    "`Zadatek`, " +
                    "`Data_rozliczenia`," +
                    "`Dodatkowe_uwagi`, " +
                    "`Raty`," +
                    "`adres_dostawy`," +
                    "`kwota_p_1`, `ilosc_p_1`, `rabat_p_1`," +
                    "`kwota_p_2`, `ilosc_p_2`, `rabat_p_2`," +
                    "`kwota_p_3`, `ilosc_p_3`, `rabat_p_3`," +
                    "`kwota_p_4`, `ilosc_p_4`, `rabat_p_4`," +
                    "`kwota_p_5`, `ilosc_p_5`, `rabat_p_5`," +
                    "`kwota_p_6`, `ilosc_p_6`, `rabat_p_6`," +
                    "`Rozliczony`, " +
                    "`Zaplacono_calosc`, " +
                    "`Przewidywany_termin_realizacji`, " +
                    "`Rodzaj_transportu`, " +
                    "`Koszt_transportu`, " +
                    "`Gratis`," +
                    "`towar_na_stanie`)  VALUES ('" +
                    Nr_zamowienia + "','" + Imie_Nazwisko.Text + "','" + Miejscowosc.Text + "','" + Kod_pocztowy.Text + "','" + Ulica_nr.Text + "','" +
                    Telefon.Text + "','" + Zamowienie + "','" + Data_przyjecia.Text + "'," +
                    Zadatek + ", '" + Data_realizacji + "', '" + Dodatkowe_uwagi.Text + "', " + Raty.Checked + ", '"+ adres_dostawy.Text+ "', " +
                    kwota_p_1 + ", " + ilosc_p_1 + ", " + rabat_p_1 + ", " + kwota_p_2 + ", " + ilosc_p_2 + ", " + rabat_p_2 + ", " +
                    kwota_p_3 + ", " + ilosc_p_3 + ", " + rabat_p_3 + ", " + kwota_p_4 + ", " + ilosc_p_4 + ", " + rabat_p_4 + ", " +
                    kwota_p_5 + ", " + ilosc_p_5 + ", " + rabat_p_5 + ", " + kwota_p_6 + ", " + ilosc_p_6 + ", " + rabat_p_6 + ", " +
                    rozliczony + ", " + zaplacono_calosc.Checked + ", '" + termin_realizacji + "', '";

                for (int i = 0; i < rodzaj_transportu.Items.Count; i++)
                    if (rodzaj_transportu.GetItemChecked(i))
                        str = (string)rodzaj_transportu.Items[i];

                pytanie_sql += str + "', '" + koszt_transportu + "', " + gratis.SelectedIndex + ", " + towar + ");";
                Polaczenie.SQL_insert_update(pytanie_sql);

               // MessageBox.Show("Przyjęto zamówienie", "Powodzenie");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Błąd nowy wpis");
            }
        }

        public static string Pobranie_ostatniego_nr_zamowienia_dla_wybranego_miasta()
        {
            try
            {
                pytanie_sql = "SELECT COUNT(*) AS ilosc FROM  " + Properties.Settings.Default.aktualne_miasto + ";";

                Polaczenie polaczenieMySQL = new Polaczenie();
                MySqlConnection polaczenie = polaczenieMySQL.Polacz();
                MySqlCommand pytanie = new MySqlCommand(pytanie_sql, polaczenie);
                MySqlDataReader wynik;
                wynik = pytanie.ExecuteReader();
                wynik.Read();
                int ilosc = wynik.GetInt16("ilosc");
                polaczenieMySQL.Zamknij(polaczenie);
                if (ilosc >= 1)
                {
                    pytanie_sql = "SELECT `Nr_zamowienia` FROM " + Properties.Settings.Default.aktualne_miasto + " ORDER BY  `" + Properties.Settings.Default.aktualne_miasto + "`.`ID_zamowienia` ASC";
                    polaczenieMySQL = new Polaczenie();
                    polaczenie = polaczenieMySQL.Polacz();
                    pytanie = new MySqlCommand(pytanie_sql, polaczenie);
                    wynik = pytanie.ExecuteReader();
                    while (wynik.Read())
                    {
                        ostati_w_tab = wynik.GetString("Nr_zamowienia");
                    }
                    polaczenieMySQL.Zamknij(polaczenie);
                }
                else
                {
                    ostati_w_tab = "001/XXXX";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Pobranie_ostatniego_nr_zamowienia_dla_wybranego_miasta");
            }
            return ostati_w_tab;

        }

        public static String koncowy;

        public static string Nowy_numer_zk()
        {
            String sDate = DateTime.Now.ToString();
            DateTime datevalue = (Convert.ToDateTime(sDate.ToString()));
            String yy = datevalue.Year.ToString();

            Pobranie_ostatniego_nr_zamowienia_dla_wybranego_miasta();

            String[] stringi_podzielone = ostati_w_tab.Split('/');
            Double liczba;
            liczba = Convert.ToDouble(stringi_podzielone[0]);
            liczba++;
            if (liczba <= 9) koncowy = "00" + liczba.ToString();
            else if (liczba <= 99) koncowy = "0" + liczba.ToString();
            else koncowy = liczba.ToString();

            biezacy_nr_zamowienia = koncowy + "/" + yy;
            if (yy == stringi_podzielone[1])
                return koncowy + "/" + yy;
            else return "001/" + yy;
        }

        public static String[] kolejne_nr_zamowien_z_DGV;

        public static void Kolejne_nr_zamowien_z_DGV(DataGridView DGV)
        {
            try
            {
                kolejne_nr_zamowien_z_DGV = new string[DGV.RowCount];
                for (int i = 0; i <= DGV.RowCount - 1; i++)
                {
                    kolejne_nr_zamowien_z_DGV[i] = DGV.Rows[i].Cells[0].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Kolejne_nr_zamowien_z_DGV");
            }
        }

        public static void Wyciaganie_ilosci_zamowionych_produktow(DataGridView DGV)
        {
            try
            {

                if (DGV.RowCount > 0)
                {
                    Kolejne_nr_zamowien_z_DGV(DGV);
                    if (Properties.Settings.Default.aktualne_miasto != "")
                    {
                        for (int i = 0; i <= DGV.RowCount - 1; i++)
                        {
                            pytanie_sql = "SELECT id_zamowienia, zamowienie, ilosc_p_1, ilosc_p_2, ilosc_p_3, ilosc_p_4, ilosc_p_5, ilosc_p_6  FROM  " + Properties.Settings.Default.aktualne_miasto +
                            " WHERE nr_zamowienia='" + kolejne_nr_zamowien_z_DGV[i] + "';";
                            Polaczenie polaczenieMySQL = new Polaczenie();
                            MySqlConnection polaczenie = polaczenieMySQL.Polacz();
                            MySqlCommand pytanie = new MySqlCommand(pytanie_sql, polaczenie);
                            MySqlDataReader wynik;
                            wynik = pytanie.ExecuteReader();

                            if (DGV.RowCount >= 1)
                            {
                                wynik.Read();
                                zamowienie = wynik.GetString("zamowienie");
                                zamowienia_tablica = zamowienie.Split('\n');

                                ilosc1 = wynik.GetInt16("ilosc_p_1");
                                ilosc2 = wynik.GetInt16("ilosc_p_2");
                                ilosc3 = wynik.GetInt16("ilosc_p_3");
                                ilosc4 = wynik.GetInt16("ilosc_p_4");
                                ilosc5 = wynik.GetInt16("ilosc_p_5");
                                ilosc6 = wynik.GetInt16("ilosc_p_6");

                                string temp_zamowienie = ilosc1 + "x " + zamowienia_tablica[0];
                                if (ilosc2 >= 1)
                                {
                                    temp_zamowienie += "\n" + ilosc2 + "x " + zamowienia_tablica[1];

                                    if (ilosc3 >= 1)
                                    {
                                        temp_zamowienie += "\n" + ilosc3 + "x " + zamowienia_tablica[2];

                                        if (ilosc4 >= 1)
                                        {
                                            temp_zamowienie += "\n" + ilosc4 + "x " + zamowienia_tablica[3];

                                            if (ilosc5 >= 1)
                                            {
                                                temp_zamowienie += "\n" + ilosc5 + "x " + zamowienia_tablica[4];

                                                if (ilosc6 >= 1)
                                                {
                                                    temp_zamowienie += "\n" + ilosc6 + "x " + zamowienia_tablica[5];
                                                }
                                            }
                                        }
                                    }
                                }
                                polaczenieMySQL.Zamknij(polaczenie);
                                DGV.Rows[i].Cells[4].Value = temp_zamowienie;

                                pytanie_sql = "SELECT  `gratisy`.`nazwa_gratisu` AS Gratis FROM  `" + Properties.Settings.Default.aktualne_miasto + "` ,  `gratisy` " +
                                    "WHERE  `" + Properties.Settings.Default.aktualne_miasto + "`.`Gratis` =  `gratisy`.`id_gratisu` AND  nr_zamowienia='" + kolejne_nr_zamowien_z_DGV[i] + "';";

                                polaczenieMySQL = new Polaczenie();
                                polaczenie = polaczenieMySQL.Polacz();
                                pytanie = new MySqlCommand(pytanie_sql, polaczenie);
                                wynik = pytanie.ExecuteReader();
                                wynik.Read();
                                if (wynik.GetString("Gratis") != "BRAK")
                                    temp_zamowienie += "\nGratis: " + wynik.GetString("Gratis");

                                DGV.Rows[i].Cells[4].Value = temp_zamowienie;
                                polaczenieMySQL.Zamknij(polaczenie);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ilosci zamowien");
            }
        }

        public static void Wyciaganie_nazw_zamowionych_produktow()
        {
            try
            {
                pytanie_sql = "SELECT * FROM  " + Properties.Settings.Default.aktualne_miasto + " WHERE `Id_zamowienia`=" + ID_z_nr_zamowienia + ";";
                Polaczenie polaczenieMySQL = new Polaczenie();
                MySqlConnection polaczenie = polaczenieMySQL.Polacz();
                MySqlCommand pytanie = new MySqlCommand(pytanie_sql, polaczenie);
                MySqlDataReader wynik;
                wynik = pytanie.ExecuteReader();
                wynik.Read();

                zamowienie = wynik.GetString("Zamowienie");
                zamowienia_tablica = zamowienie.Split('\n');

                polaczenieMySQL.Zamknij(polaczenie);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "nazwy zamowien");
            }
        }
        #endregion

        public static string Krotka_nazwa, adres1, adres2, kod_pocztowy_s, miejscowosc_s ,adres_email;

        public static void Dane_sklepu_z_bazy()
        {
            try
            {
                pytanie_sql = "SELECT * FROM sklepy WHERE `id_sklepu`='" + Properties.Settings.Default.id_wybranego_miasta + "'";

                Polaczenie polaczenieMySQL = new Polaczenie();
                MySqlConnection polaczenie = polaczenieMySQL.Polacz();
                MySqlCommand pytanie = new MySqlCommand(pytanie_sql, polaczenie);
                MySqlDataReader wynik;
                wynik = pytanie.ExecuteReader();
                wynik.Read();

                Krotka_nazwa = wynik.GetString("krotka_nazwa");
                adres1 = wynik.GetString("adres1");
                adres2 = wynik.GetString("adres2");
                telefon = wynik.GetString("telefon");
                kod_pocztowy_s = wynik.GetString("kod_pocztowy");
                miejscowosc_s = wynik.GetString("miejscowosc");
                adres_email = wynik.GetString("adres_email");

                polaczenieMySQL.Zamknij(polaczenie);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Pobieranie Sklepu");
            }
        }

        public static double kwota_laczna = 0;
        public static string Tresc_maila(string nr_zamowienia)
        {
            string tresc_maila = null;
            try
            {
                pytanie_sql = "SELECT id_zamowienia, zamowienie, ilosc_p_1,ilosc_p_2,ilosc_p_3,ilosc_p_4,ilosc_p_5,ilosc_p_6,  " +
                    "`zadatek`, `gratis`, `gratisy`.nazwa_gratisu, " +
                    " Round((" +
                    "`ilosc_p_1` *(`kwota_p_1` -((`rabat_p_1` / 100) * `kwota_p_1`))+ " +
                    "`ilosc_p_2` *(`kwota_p_2` -((`rabat_p_2` / 100) * `kwota_p_2`))+ " +
                    "`ilosc_p_3` *(`kwota_p_3` -((`rabat_p_3` / 100) * `kwota_p_3`))+ " +
                    "`ilosc_p_4` *(`kwota_p_4` -((`rabat_p_4` / 100) * `kwota_p_4`))+" +
                    "`ilosc_p_5` *(`kwota_p_5` -((`rabat_p_5` / 100) * `kwota_p_5`))+ " +
                    "`ilosc_p_6` *(`kwota_p_6` -((`rabat_p_6` / 100) * `kwota_p_6`)) ),2)AS 'Kwota łączna' " +
                    " FROM  `" + Properties.Settings.Default.aktualne_miasto +"`, `gratisy`" +
                    " WHERE `" + Properties.Settings.Default.aktualne_miasto + "`.`gratis`=`gratisy`.`id_gratisu` AND nr_zamowienia='" + nr_zamowienia + "';";
              
                Polaczenie polaczenieMySQL = new Polaczenie();
                MySqlConnection polaczenie = polaczenieMySQL.Polacz();
                MySqlCommand pytanie = new MySqlCommand(pytanie_sql, polaczenie);
                MySqlDataReader wynik;
                wynik = pytanie.ExecuteReader();
                wynik.Read();

                zamowienie = wynik.GetString("zamowienie");
                zamowienia_tablica = zamowienie.Split('\n');

                kwota_laczna= wynik.GetDouble("Kwota łączna");
                ilosc1 = wynik.GetInt16("ilosc_p_1");
                ilosc2 = wynik.GetInt16("ilosc_p_2");
                ilosc3 = wynik.GetInt16("ilosc_p_3");
                ilosc4 = wynik.GetInt16("ilosc_p_4");
                ilosc5 = wynik.GetInt16("ilosc_p_5");
                ilosc6 = wynik.GetInt16("ilosc_p_6");
                zadatek = wynik.GetString("zadatek");
                string gratis = wynik.GetString("nazwa_gratisu");

                string temp_zamowienie = ilosc1 + "x " + zamowienia_tablica[0];
                if (ilosc2 >= 1)
                {
                    temp_zamowienie += "\n" + ilosc2 + "x " + zamowienia_tablica[1];

                    if (ilosc3 >= 1)
                    {
                        temp_zamowienie += "\n" + ilosc3 + "x " + zamowienia_tablica[2];

                        if (ilosc4 >= 1)
                        {
                            temp_zamowienie += "\n" + ilosc4 + "x " + zamowienia_tablica[3];

                            if (ilosc5 >= 1)
                            {
                                temp_zamowienie += "\n" + ilosc5 + "x " + zamowienia_tablica[4];

                                if (ilosc6 >= 1)
                                {
                                    temp_zamowienie += "\n" + ilosc6 + "x " + zamowienia_tablica[5];
                                }
                            }
                        }
                    }
                }
                if (gratis != "BRAK")
                {
                    gratis = "\nGratis: " + gratis;
                    kwota_laczna += 1;
                }
                else
                    gratis = null; 

                tresc_maila = "Zawartość zamówienia:\n"+temp_zamowienie + gratis+"\n\nKwota łączna zamówienie:  " + kwota_laczna + "zł\n\nWpłacony zadatek: " + zadatek+"zł.";
                polaczenieMySQL.Zamknij(polaczenie);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Tresc_maila");
            }
            return tresc_maila;
        }

        public static string Numer_fv(string rok)
        {
            string numer_fv = null;
            int czy_ma_numer;
            pytanie_sql = "SELECT  COUNT( `numer_fv`) AS ilosc FROM "+ Properties.Settings.Default.aktualne_miasto + " WHERE `Nr_zamowienia`= '" + biezacy_nr_zamowienia + "' AND `numer_fv` LIKE '%/" + rok + "%'";
            Polaczenie polaczenieMySQL = new Polaczenie();            
            MySqlConnection polaczenie = polaczenieMySQL.Polacz();
            MySqlCommand pytanie = new MySqlCommand(pytanie_sql, polaczenie);
            MySqlDataReader wynik;
            wynik = pytanie.ExecuteReader();
            wynik.Read();
            czy_ma_numer = wynik.GetInt16("ilosc");
            polaczenieMySQL.Zamknij(polaczenie);
            if (czy_ma_numer > 0)
            {
                
                try
                {
                    pytanie_sql = "SELECT `numer_fv` FROM " + Properties.Settings.Default.aktualne_miasto + " WHERE `Nr_zamowienia`='" + biezacy_nr_zamowienia + "'";
                    polaczenieMySQL = new Polaczenie();
                    polaczenie = polaczenieMySQL.Polacz();
                    pytanie = new MySqlCommand(pytanie_sql, polaczenie);

                    wynik = pytanie.ExecuteReader();

                    wynik.Read();

                    numer_fv = wynik.GetString("numer_fv");

                    polaczenieMySQL.Zamknij(polaczenie);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "pobieranie numeru fv dla aktualnie wybranego zk");

                }

            }
            else numer_fv = Nowy_numer_fv(rok);
                               
            return numer_fv;
        }

        public static string Nowy_numer_fv(string rok)
        {
            string nowy = null;

            int ile_numer;
            pytanie_sql = "SELECT  COUNT( `numer_fv`) AS ilosc FROM " + Properties.Settings.Default.aktualne_miasto + " WHERE `numer_fv` LIKE '%/" + rok + "%' ORDER BY `numer_fv` ASC";
            Polaczenie polaczenieMySQL = new Polaczenie();
            MySqlConnection polaczenie = polaczenieMySQL.Polacz();
            MySqlCommand pytanie = new MySqlCommand(pytanie_sql, polaczenie);
            MySqlDataReader wynik;            
            wynik = pytanie.ExecuteReader();
            wynik.Read();
            ile_numer = wynik.GetInt16("ilosc");
            polaczenieMySQL.Zamknij(polaczenie);
            if (ile_numer>0)
            {
                try
                {
                    pytanie_sql = "SELECT `numer_fv` FROM " + Properties.Settings.Default.aktualne_miasto + " WHERE `numer_fv` LIKE '%/" + rok + "%' ORDER BY `numer_fv` DESC";
                    polaczenieMySQL = new Polaczenie();
                    polaczenie = polaczenieMySQL.Polacz();
                    pytanie = new MySqlCommand(pytanie_sql, polaczenie);

                    wynik = pytanie.ExecuteReader();

                    wynik.Read();
                    nowy = wynik.GetString("numer_fv");


                    polaczenieMySQL.Zamknij(polaczenie);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "pobieranie ostatniego numeru fv");

                }
                
                String[] stringi_podzielone = nowy.Split('/');
                Double liczba;
                liczba = Convert.ToDouble(stringi_podzielone[0]);
                liczba++;
                if (liczba <= 9) koncowy = "00" + liczba.ToString();
                else if (liczba <= 99) koncowy = "0" + liczba.ToString();
                else koncowy = liczba.ToString();
                nowy =koncowy + "/" + rok;

            }
            else nowy= "001/"+rok;
            
            try
            {
                
                pytanie_sql = "UPDATE " + Properties.Settings.Default.aktualne_miasto + " SET `numer_fv` = '" + nowy + "' " +
                    "WHERE `" + Properties.Settings.Default.aktualne_miasto + "`.`Id_zamowienia` = " + ID_z_nr_zamowienia + ";";
                
                Polaczenie.SQL_insert_update(pytanie_sql);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "dodawanie numeru");
            }

            return nowy;

        }


        public static string[,] Metoda_Rafal(string kryteria_true_false)
        {
            int ilosc = 0;
            string[,] tablica = new string[1, 1];

            try
            {
                if (Properties.Settings.Default.aktualne_miasto != "" && Logowanie.zalogowany == true)
                {
                    pytanie_sql = "SELECT COUNT(*)" +
                       " FROM " + Properties.Settings.Default.aktualne_miasto + ",  `gratisy` " +
                       "WHERE `" + Properties.Settings.Default.aktualne_miasto + "`.`Gratis` =  `gratisy`.`id_gratisu` AND " + kryteria_true_false + ";";

                    Polaczenie polaczenieMySQL = new Polaczenie();
                    MySqlConnection polaczenie = polaczenieMySQL.Polacz();
                    MySqlCommand pytanie = new MySqlCommand(pytanie_sql, polaczenie);

                    MySqlDataReader wynik;
                    wynik = pytanie.ExecuteReader();
                    wynik.Read();

                    ilosc = wynik.GetInt16(0);
                    polaczenieMySQL.Zamknij(polaczenie);
                   
                    if (ilosc >= 1)
                    {
                        pytanie_sql = "SELECT *," +
                      "`Nr_zamowienia`, " +
                      "`Zamowienie`, " +
                      " DATE_FORMAT(`Data_przyjecia`, '%Y-%m-%d') AS 'Data przyjecia'," +
                      "`Zadatek`," +
                      "`Raty`," +
                      " Round((`ilosc_p_1` *(`kwota_p_1` -((`rabat_p_1` / 100) * `kwota_p_1`))+ " +
                      "`ilosc_p_2` *(`kwota_p_2` -((`rabat_p_2` / 100) * `kwota_p_2`))+ " +
                      "`ilosc_p_3` *(`kwota_p_3` -((`rabat_p_3` / 100) * `kwota_p_3`))+ " +
                      "`ilosc_p_4` *(`kwota_p_4` -((`rabat_p_4` / 100) * `kwota_p_4`))+" +
                      "`ilosc_p_5` *(`kwota_p_5` -((`rabat_p_5` / 100) * `kwota_p_5`))+ " +
                      "`ilosc_p_6` *(`kwota_p_6` -((`rabat_p_6` / 100) * `kwota_p_6`)) ),2)AS 'Kwota łączna'," +
                      " Round(( `ilosc_p_1` *(`kwota_p_1` -((`rabat_p_1` / 100) * `kwota_p_1`))+" +
                      "`ilosc_p_2` *(`kwota_p_2` -((`rabat_p_2` / 100) * `kwota_p_2`))+ " +
                      "`ilosc_p_3` *(`kwota_p_3` -((`rabat_p_3` / 100) * `kwota_p_3`))+ " +
                      "`ilosc_p_4` *(`kwota_p_4` -((`rabat_p_4` / 100) * `kwota_p_4`))+ " +
                      "`ilosc_p_5` *(`kwota_p_5` -((`rabat_p_5` / 100) * `kwota_p_5`))+ " +
                      "`ilosc_p_6` *(`kwota_p_6` -((`rabat_p_6` / 100) * `kwota_p_6`))-zadatek),2) AS 'Pozostało do zapłaty', " +
                      "`gratisy`.`nazwa_gratisu` AS Gratis_tresc" +
                      " FROM " + Properties.Settings.Default.aktualne_miasto + ",  `gratisy` " +
                      "WHERE `" + Properties.Settings.Default.aktualne_miasto + "`.`Gratis` =  `gratisy`.`id_gratisu` AND " + kryteria_true_false +
                      " ORDER BY  `" + Properties.Settings.Default.aktualne_miasto + "`.`Nr_zamowienia` DESC";//";";

                        polaczenieMySQL = new Polaczenie();
                        polaczenie = polaczenieMySQL.Polacz();
                        pytanie = new MySqlCommand(pytanie_sql, polaczenie);
                        //wynik = pytanie.ExecuteReader();

                        DataTable dt = new DataTable();
                        MySqlDataAdapter adap = new MySqlDataAdapter(pytanie);
                        adap.Fill(dt);
                        int row = 0;
                        tablica = new string[7, ilosc];
                        foreach (DataRow row_data in dt.Rows)
                        {
                            zamowienie = row_data["Zamowienie"].ToString();
                            zamowienia_tablica = zamowienie.Split('\n');

                            ilosc1 = Convert.ToInt32(row_data["ilosc_p_1"]);
                            ilosc2 = Convert.ToInt32(row_data["ilosc_p_2"]);
                            ilosc3 = Convert.ToInt32(row_data["ilosc_p_3"]);
                            ilosc4 = Convert.ToInt32(row_data["ilosc_p_4"]);
                            ilosc5 = Convert.ToInt32(row_data["ilosc_p_5"]);
                            ilosc6 = Convert.ToInt32(row_data["ilosc_p_6"]);

                            string temp_zamowienie = ilosc1 + "x " + zamowienia_tablica[0];
                            if (ilosc2 >= 1)
                            {
                                temp_zamowienie += "\n" + ilosc2 + "x " + zamowienia_tablica[1];

                                if (ilosc3 >= 1)
                                {
                                    temp_zamowienie += "\n" + ilosc3 + "x " + zamowienia_tablica[2];

                                    if (ilosc4 >= 1)
                                    {
                                        temp_zamowienie += "\n" + ilosc4 + "x " + zamowienia_tablica[3];

                                        if (ilosc5 >= 1)
                                        {
                                            temp_zamowienie += "\n" + ilosc5 + "x " + zamowienia_tablica[4];

                                            if (ilosc6 >= 1)
                                            {
                                                temp_zamowienie += "\n" + ilosc6 + "x " + zamowienia_tablica[5];
                                            }
                                        }
                                    }
                                }

                            }
                            string laczna = Convert.ToDecimal(row_data["Kwota łączna"]).ToString("##,##0.00");
                            string pozostalo = Convert.ToDecimal(row_data["Pozostało do zapłaty"]).ToString("##,##0.00");
                            

                            tablica[0, row] = row_data["Nr_zamowienia"].ToString();
                            tablica[1, row] = row_data["Data przyjecia"].ToString();
                            tablica[2, row] = Convert.ToDecimal(row_data["Zadatek"]).ToString("##,##0.00");
                            if (row_data["Gratis_tresc"].ToString() != "BRAK")
                            {
                                laczna = (1 + Convert.ToDecimal(laczna)).ToString("##,##0.00");
                                pozostalo = (1 + Convert.ToDecimal(pozostalo)).ToString("##,##0.00");
                            }
                            tablica[3, row] = laczna;
                            tablica[4, row] = pozostalo;
                            if (row_data["Gratis_tresc"].ToString()!="BRAK")
                            {
                                temp_zamowienie += "\n1x " + row_data["Gratis_tresc"].ToString();
                            }
                            tablica[5, row] = temp_zamowienie;
                            tablica[6, row] = row_data["Raty"].ToString();


                            polaczenieMySQL.Zamknij(polaczenie);

                            row++;
                        }
                        return tablica;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Rafał 1");
            }
            
            return tablica;
        }


        public static void Dodaj_firme(string numer_fv, string nazwa_f, string miejscowosc_f, string kod_pocztowy_f, string adres_f, string nip)
        {
            pytanie_sql = "INSERT INTO `firma` (`numer_fv`, `nazwa_firmy`, `miejscowosc`, `kod_pocztowy`, `adres`, `nip`) " +
           "VALUES ('" + numer_fv + "', '" + nazwa_f + "', '" + miejscowosc_f + "', '" + kod_pocztowy_f + "', '" + adres_f + "', '" + nip + "');";
            Polaczenie.SQL_insert_update(pytanie_sql);            

        }
        
        public static string [] Wczytanie_firmy_o_nr_fv(string numer_fv)
        {
            string[] wynik_tab = new string[7];
            try
            {
                pytanie_sql = "SELECT * FROM `firma` WHERE `numer_fv`='" + numer_fv + "'";
                Polaczenie polaczenieMySQL = new Polaczenie();
                MySqlConnection polaczenie = polaczenieMySQL.Polacz();
                MySqlCommand pytanie = new MySqlCommand(pytanie_sql, polaczenie);
                MySqlDataReader wynik;
                wynik = pytanie.ExecuteReader();

                while (wynik.Read())
                {
                    wynik_tab[0] = wynik.GetString(0);
                    wynik_tab[1] = wynik.GetString(1);
                    wynik_tab[2] = wynik.GetString(2);
                    wynik_tab[3] = wynik.GetString(3);
                    wynik_tab[4] = wynik.GetString(4);
                    wynik_tab[5] = wynik.GetString(5);
                    wynik_tab[6] = wynik.GetString(6);

                }
                polaczenieMySQL.Zamknij(polaczenie);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "dane faktury");
            }
          
                
            
 
            return wynik_tab;
        }
    }
}
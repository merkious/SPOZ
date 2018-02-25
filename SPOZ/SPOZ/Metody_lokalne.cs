using MySql.Data.MySqlClient;
using System;
using System.Diagnostics;
using System.IO;
using System.Net.Mail;
using System.Text;
using System.Windows.Forms;

namespace SPOZ
{
    class Metody_lokalne
    {      
        public static bool proces = false;

        public static void Sprawdzanie_statusu_polaczenia(ToolStripLabel label, ToolStripLabel pic_g, ToolStripLabel pic_r)
        {
            Polaczenie polaczenieMySQL = new Polaczenie();
            MySqlConnection polaczenie = polaczenieMySQL.Polacz();
            if (Polaczenie.polaczenie.State.ToString() == "Open")
            {
                label.Text = "Połączenie z bazą jest prowidłowe.";
                pic_g.Visible = true;
                pic_r.Visible = false ;

            }
            else
            {
                label.Text = "Brak połączenia z bazą.";
                pic_g.Visible = false ;
                pic_r.Visible = true;
            }
            polaczenieMySQL.Zamknij(polaczenie);
        }

        public static void Kropka_w_locie(TextBox nazwa, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar == ',' )
            {
                e.Handled = true;
                int i = nazwa.Text.Length;
                nazwa.Text = nazwa.Text.Insert(i, ".");
                nazwa.SelectionStart = i + 1;
            }
        }

        public static string Usun_polskie_znaki(string txt)
        {
            byte[] bytes = Encoding.GetEncoding("Cyrillic").GetBytes(txt);
            string miasto_bez_polskich= Encoding.ASCII.GetString(bytes).ToString().ToLower();
            return miasto_bez_polskich;
        }

        public static void Usuwanie_starych_aktualizacji()
        {
            string[] pliki = Directory.GetFiles(Sciezki.aktualizacje);

            for (int i = 0; i <= pliki.Length-1; i++)
            {
                if (pliki[i] != Sciezki.aktualizacje+@"\Setup_SPOZ_" + Aktualizacja.WERJSA__FTP + ".exe")
                {
                    File.Delete( pliki[i]);
                }
            }
        }

        public static void Foldery()
        {
            if (!Directory.Exists(Sciezki.aktualizacje))
                Directory.CreateDirectory(Sciezki.aktualizacje);
            if (!Directory.Exists(Sciezki.zamowienia))
                Directory.CreateDirectory(Sciezki.zamowienia);
            if (!Directory.Exists(Sciezki.faktury))
                Directory.CreateDirectory(Sciezki.faktury);
            if (!Directory.Exists(Sciezki.faktury))
                Directory.CreateDirectory(Sciezki.faktury);
        }

        static MailMessage mail;
        public static void Wyslij_zamowienie(string nr_zamówienia, string tresc)
        {
            try
            {
                string miasto = Properties.Settings.Default.aktualne_miasto_PL;
                mail = new MailMessage();
                mail.From = new MailAddress("info.zamowienie@spoz.pl");
                mail.To.Add(Properties.Settings.Default.mail_managera);
                mail.ReplyToList.Add(Metody_bazy.adres_email);
                mail.Subject = Nowe_zamowienie.tytuł_maila+"Zamówienie nr " + nr_zamówienia + " z " + miasto.Replace('\r', ' ').Replace('\n', ' ');
                mail.Body = tresc;
                mail.Attachments.Add(new Attachment(Sciezki.drukowane_zk));
                MailAddress mail_replay2 = new MailAddress(Metody_bazy.adres_email);
                MailMessage mail_replay = new MailMessage();

                SmtpClient klient = new SmtpClient("az-serwer1789737.online.pro");
                klient.Port = 587;
                klient.Credentials = new System.Net.NetworkCredential("info.zamowienie@spoz.pl", "odr123GGO");
                klient.EnableSsl = true;
                klient.Send(mail);
                mail.Attachments.Dispose();
                MessageBox.Show("Przyjęto oraz wysłano zamówienie", "Powodzenie");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Nie mogę wysłać maila.\n" + ex.Message, "Niepowodzenie", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
   
        public static void Wyslij_kod_resetu(TextBox mail_uzytkownika)
        {
            try
            {
                mail = new MailMessage();
                mail.From = new MailAddress("info.zamowienie@spoz.pl");
                mail.To.Add(mail_uzytkownika.Text);
                mail.Subject = "Zmiana hasła do konta SPOZ";
                mail.Body = 
                    "Aby dokonać jednorazowej zmiany hasła wpisz podany niżej kod w odpowiednie pole w programie SPOZ.\n\n"+
                    Logowanie.kod.ToString() +
                    "\n\nJeśli nie zgłaszałeś chęci zmiany hasła, zignoruj ten list (prawdopodobnie inna osoba podała omyłkowo Twój adres)." +
                    "\nDziękujemy za korzystanie z naszych usług." +
                    "\n\nProsimy nie odppowiadać na tego maila." +
                    "\nZespół ODR";

                SmtpClient klient = new SmtpClient("az-serwer1789737.online.pro");
                klient.Port = 587;
                klient.Credentials = new System.Net.NetworkCredential("info.zamowienie@spoz.pl", "odr123GGO");
                klient.EnableSsl = true;
                klient.Send(mail);
                MessageBox.Show("Kod potrzebny do zmiany hasła został wysłany na: "+mail_uzytkownika.Text, "Reset hasła", MessageBoxButtons.OK, MessageBoxIcon.Information,MessageBoxDefaultButton.Button1,MessageBoxOptions.DefaultDesktopOnly);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Nie mogę wysłać maila.\n" + ex.Message, "Niepowodzenie", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public static void Otwieranie_zamowienia(string numer_zk)
        {
            try
            {               
                String[] stringi_podzielone = numer_zk.Split('/');
                String numer_zamowienia = stringi_podzielone[0] + "/" + Metody_bazy.Krotka_nazwa + "/" + stringi_podzielone[1];
                String filename = Sciezki.zamowienia + @"\ZK-" + numer_zamowienia.Replace('/', '-') + ".pdf";
                Process.Start(filename);        
            }
            catch (Exception)
            {
                if(MessageBox.Show("Brak pliku wybranego zamówienia.\nChcesz go teraz utworzyć?", "Brak pliku", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly) == DialogResult.Yes)
                {
                    Metody_bazy.Wczytanie_zamowienia_do_edycji();

                    Drukowanie_PDF druk = new Drukowanie_PDF();
                    string adr;

                    if (Metody_bazy.imie_nazwisko == "Sprzedaż z ekspozycji")
                        adr = Metody_bazy.imie_nazwisko;
                    else adr = Metody_bazy.imie_nazwisko + ",  " + Metody_bazy.ulica_nr + ",  " + Metody_bazy.miejscowosc + "  " + Metody_bazy.kod_pocztowy + "  tel. " + Metody_bazy.telefon;

                    string transp = null;
                    if (Metody_bazy.rodzaj_transportu == "Transport Gratis")
                        transp = " zamawiany gratis.";
                    else if (Metody_bazy.rodzaj_transportu == "Transport Własny")
                        transp = " we własnym zakresie.";
                    else
                        transp = " zamawiany płatny - " + (Convert.ToDecimal(Metody_bazy.koszt_transportu)).ToString("0.00") + " zł.";

                    string adres_dost = "";
                    if (Metody_bazy.adres_dostawy != "")
                         adres_dost = Metody_bazy.adres_dostawy;

                    druk.Druk_PDF(Metody_bazy.gratis, numer_zk, Convert.ToInt16(Metody_bazy.ilosc_produktow_combo), Convert.ToDouble(Metody_bazy.zadatek),Metody_bazy.data_przyjecia.ToString(), adr, adres_dost, Metody_bazy.termin_realizacji, transp, Metody_bazy.uwagi);
                    druk.Druk_produktow(Metody_bazy.zamowienia_tablica[0], Metody_bazy.zamowienia_tablica[1], Metody_bazy.zamowienia_tablica[2], Metody_bazy.zamowienia_tablica[3], Metody_bazy.zamowienia_tablica[4], Metody_bazy.zamowienia_tablica[5]);
                    druk.Druk_ilosc(Convert.ToDouble(Metody_bazy.ilosc_p_1), Convert.ToDouble(Metody_bazy.ilosc_p_2), Convert.ToDouble(Metody_bazy.ilosc_p_3), Convert.ToDouble(Metody_bazy.ilosc_p_4), Convert.ToDouble(Metody_bazy.ilosc_p_5), Convert.ToDouble(Metody_bazy.ilosc_p_6));
                    druk.Druk_rabat(Convert.ToDouble(Metody_bazy.rabat_p_1), Convert.ToDouble(Metody_bazy.rabat_p_2), Convert.ToDouble(Metody_bazy.rabat_p_3),Convert.ToDouble(Metody_bazy.rabat_p_4), Convert.ToDouble(Metody_bazy.rabat_p_5), Convert.ToDouble(Metody_bazy.rabat_p_6));
                    druk.Druk_cena_jednostkowa(Convert.ToDouble(Metody_bazy.kwota_p_1), Convert.ToDouble(Metody_bazy.kwota_p_2), Convert.ToDouble(Metody_bazy.kwota_p_3), Convert.ToDouble(Metody_bazy.kwota_p_4), Convert.ToDouble(Metody_bazy.kwota_p_5), Convert.ToDouble(Metody_bazy.kwota_p_6));
                    druk.CreateDocument();



                    //Okno_glowne okno_Glowne = Application.OpenForms.OfType<Okno_glowne>().FirstOrDefault();
                    //Okno_glowne.czy_edycja = true;
                    //Nowe_zamowienie nowe_zk = new Nowe_zamowienie(okno_Glowne);
                    //nowe_zk.Tworzenie_pdf(Metody_bazy.biezacy_nr_zamowienia);
                    //nowe_zk.Close();
                }
            }
        }

        public static void Otwieranie_faktury(string numer_fv, string data_rozliczenia_f)
        {
            String[] stringi_podzielone = numer_fv.Split('/');
            String numer_faktury = stringi_podzielone[0] + "/" + Metody_bazy.Krotka_nazwa + "/" + stringi_podzielone[1];
            try
            {               
                String filename = Sciezki.faktury + @"\FV-" + numer_faktury.Replace('/', '-') + ".pdf";
                Process.Start(filename);               
            }
            catch (Exception)
            {
                //MessageBox.Show("Brak pliku wybranej faktury.");
                try
                {
                    string[] tab = Metody_bazy.Wczytanie_firmy_o_nr_fv(numer_faktury);
                    new PDF.Druk_fv(tab[1], tab[2], tab[4] + " " + tab[3], tab[5], tab[6]);
                    
                }
                catch (Exception)
                {

                    new PDF.Druk_fv(numer_fv, data_rozliczenia_f);
                }
            }
        }
    }
}
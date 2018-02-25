using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace SPOZ
{
    class Polaczenie
    {
        public static string Dane_polaczenia_z_baza = "server=az-serwer1789737.online.pro; user=00084420_spoztest;  password=odr123GGO; database=00084420_spoztest;  DefaultTableCacheAge=30; charset=utf8; Convert Zero Datetime=true;";
 
        public static MySqlConnection polaczenie;

        public MySqlConnection Polacz()
        {
             try
            {
                polaczenie = new MySqlConnection(Dane_polaczenia_z_baza);
                polaczenie.Open();
                return polaczenie;
            }
            catch (Exception)
            {
                MessageBox.Show("Sprawdź swoje połączenie z internetem.", "Brak połączenia z bazą danych", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1,MessageBoxOptions.DefaultDesktopOnly);
            }
            return polaczenie;
        }

        public void Zamknij(MySqlConnection polaczenie)
        {
            polaczenie.Close();
        }

        //Polecenia SQL
        public static void SQL_insert_update(string pytanie_sql)
        {
            try
            {
                Polaczenie polaczenieMySQL = new Polaczenie();
                MySqlConnection polaczenie = polaczenieMySQL.Polacz();
                MySqlCommand pytanie = new MySqlCommand(pytanie_sql, polaczenie);
                MySqlDataReader wynik;
                wynik = pytanie.ExecuteReader();
                polaczenieMySQL.Zamknij(polaczenie);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void SQL_delete(string pytanie_sql)
        {
            try
            {
                Polaczenie polaczenieMySQL = new Polaczenie();
                MySqlConnection polaczenie = polaczenieMySQL.Polacz();
                MySqlCommand pytanie = new MySqlCommand(pytanie_sql, polaczenie);
                MySqlDataReader wynik;
                wynik = pytanie.ExecuteReader();
                polaczenieMySQL.Zamknij(polaczenie);
            }
            catch (Exception){}
        }

        public static DataTable data;
        public static void SQL_dataGridView(DataGridView dataGrid, string pytanie)
        {
            try
            {
                Polaczenie polaczenieMySQL = new Polaczenie();
                MySqlConnection polaczenie = polaczenieMySQL.Polacz();
                MySqlCommand com = new MySqlCommand(pytanie, polaczenie);
                MySqlDataAdapter adapter = new MySqlDataAdapter(com);
                data = new DataTable();
                adapter.Fill(data);
                dataGrid.DataSource = data;
                polaczenieMySQL.Zamknij(polaczenie);

                Okno_glowne.Kolorowanie_DGV(dataGrid);
            }
            catch (Exception ex)
            {
                MessageBox.Show("SQL_dataGrid\n" + ex.Message, "Połączenie");
            }
        }
    }
}
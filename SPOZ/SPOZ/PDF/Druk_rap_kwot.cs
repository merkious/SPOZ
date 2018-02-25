using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.Rendering;
using MySql.Data.MySqlClient;
using PdfSharp.Pdf;
using System;
using System.Diagnostics;
using System.Windows.Forms;


namespace SPOZ
{

    class Druk_raport_pdf
    {
        Document document;
        private string data_od, data_do;
        private Section section;
        private Table table;
        private Double suma_zk, suma_doplata, suma_rozliczono;
        private string ile_przyjetych, ile_rozliczonych, ile_rozliczonych_wedlug_roz;


        public Druk_raport_pdf(string druk_od_daty, string druk_do_daty)
        {

            data_od = druk_od_daty;
            data_do = druk_do_daty;
            CreateDocument();


        }

        public void CreateDocument()
        {

            // Create a new MigraDoc document
            document = new Document();
            document.Info.Title = "Raport";

            DefineStyles();
            CreatePage();
            Wszystkie_zamowienia();
            Rozliczone_zamowienia();


            document.UseCmykColor = true;
            const bool unicode = true;
            const PdfFontEmbedding embedding = PdfFontEmbedding.Always;
            PdfDocumentRenderer pdfRenderer = new PdfDocumentRenderer(unicode, embedding)
            {Document = document};
            pdfRenderer.RenderDocument();
            //ścieżka dostępu 
            try
            {
                string filename = Sciezki.moje_dokumnety + @"\SPOZ\Raport.pdf";
                pdfRenderer.PdfDocument.Save(filename);
                Process.Start(filename);
            }
            catch (Exception)
            {
                MessageBox.Show("Należy zamknąć poprzedni raport.");
            }
        }

        void DefineStyles()

        {
            // Get the predefined style Normal.
            Style style = this.document.Styles["Normal"];
            // Because all styles are derived from Normal, the next line changes the
            // font of the whole document. Or, more exactly, it changes the font of
            // all styles and paragraphs that do not redefine the font.
            style.Font.Name = "Verdana";
            style = this.document.Styles[StyleNames.Header];
            style.ParagraphFormat.AddTabStop("16cm", MigraDoc.DocumentObjectModel.TabAlignment.Right);
            style = this.document.Styles[StyleNames.Footer];
            style.ParagraphFormat.AddTabStop("8cm", MigraDoc.DocumentObjectModel.TabAlignment.Center);
            // Create a new style called Table based on style Normal
            style = this.document.Styles.AddStyle("Table", "Normal");
            style.Font.Name = "Verdana";
            style.Font.Name = "Times New Roman";
            style.Font.Size = 9;

            style = this.document.Styles.AddStyle("TNR12", "Normal");
            style.Font.Name = "Times New Roman";
            style.ParagraphFormat.SpaceAfter = "3";
            style.Font.Color = Colors.Black;
            style.Font.Size = 12;

            style = this.document.Styles.AddStyle("TNR12B", "Normal");
            style.Font.Name = "Times New Roman";
            style.Font.Color = Colors.Black;
            style.Font.Size = 12;
            style.ParagraphFormat.SpaceAfter = "3";
            style.Font.Bold = true;


            // Create a new style called Reference based on style Normal
            style = this.document.Styles.AddStyle("Reference", "Normal");
            style.ParagraphFormat.SpaceBefore = "5mm";
            style.ParagraphFormat.SpaceAfter = "5mm";
            style.ParagraphFormat.TabStops.AddTabStop("16cm", MigraDoc.DocumentObjectModel.TabAlignment.Right);
        }
        
        void CreatePage()
        {
            Sumy_wybranych();

            // Each MigraDoc document needs at least one section.
            section = this.document.AddSection();
            Paragraph paragraph = section.Footers.Primary.AddParagraph();

            paragraph = section.AddParagraph();
            paragraph.AddText(Properties.Settings.Default.aktualne_miasto_PL);
            paragraph.Style = "TNR12";
            //////////
            paragraph = section.AddParagraph();
            paragraph.AddText("Raport od: " + data_od);
            paragraph.Style = "TNR12";
            ///////////
            paragraph = section.AddParagraph();
            paragraph.AddText("Raport do: " + data_do);
            paragraph.Style = "TNR12";
            //



            paragraph = section.AddParagraph();
            paragraph.AddText("Przyjętych zamówień: " + ile_przyjetych);
            paragraph.Style = "TNR12";

            paragraph = section.AddParagraph();
            paragraph.AddText("W tym rozliczonych: " + ile_rozliczonych);
            paragraph.Style = "TNR12";

            Tworzenie_tabeli();

        }
        private void Tworzenie_tabeli()
        {
            // Create the item table
            this.table = section.AddTable();
            this.table.Style = "Table";
            this.table.Borders.Width = 0.25;
            this.table.Borders.Left.Width = 0.5;
            this.table.Borders.Right.Width = 0.5;
            this.table.Rows.LeftIndent = 0;


            // Before you can add a row, you must define the columns
            Column column = this.table.AddColumn("2cm");
            column.Format.Alignment = ParagraphAlignment.Left;
            column = this.table.AddColumn("2cm");
            column.Format.Alignment = ParagraphAlignment.Center;
            column = this.table.AddColumn("2cm");
            column.Format.Alignment = ParagraphAlignment.Center;
            column = this.table.AddColumn("2cm");
            column.Format.Alignment = ParagraphAlignment.Right;
            column = this.table.AddColumn("2cm");
            column.Format.Alignment = ParagraphAlignment.Right;
            column = this.table.AddColumn("2cm");
            column.Format.Alignment = ParagraphAlignment.Right;
            column = this.table.AddColumn("2cm");
            column.Format.Alignment = ParagraphAlignment.Center;


            // Create the header of the table
            Row row = table.AddRow();
            row.HeadingFormat = true;
            row.Format.Alignment = ParagraphAlignment.Left;
            row.VerticalAlignment = VerticalAlignment.Bottom;
            row.Format.Font.Bold = true;
            row.Shading.Color = Colors.Aqua;
            row.TopPadding = 3.5;
            ////////////////////////////
            row.Cells[0].AddParagraph("Numer zamówienia");
            row.Cells[1].AddParagraph("Data przyjęca");
            row.Cells[2].AddParagraph("Data rozliczenia");
            row.Cells[3].AddParagraph("Wartość zamówienia");
            row.Cells[4].AddParagraph("Zadatek");
            row.Cells[5].AddParagraph("Pozostało do zapłaty");
            row.Cells[6].AddParagraph("Raty");


            this.table.SetEdge(0, 0, 7, 1, Edge.Box, MigraDoc.DocumentObjectModel.BorderStyle.Single, 0.75, MigraDoc.DocumentObjectModel.Color.Empty);
            this.table.SetEdge(0, 0, 7, 1, Edge.Box, MigraDoc.DocumentObjectModel.BorderStyle.Single, 0.75);
        }

        private void Sumy_wybranych()
        {
            
          
            try
            {
                string pytanie_sql = "SELECT " +
                   "COUNT(`Nr_zamowienia`) AS 'Ilość zamówień' " +
                    " FROM " +
                     Properties.Settings.Default.aktualne_miasto + " WHERE  `Data_przyjecia` BETWEEN '" + data_od + "' AND '" + data_do + "'  ORDER BY  `Nr_zamowienia` DESC";
                Polaczenie polaczenieMySQL = new Polaczenie();
                MySqlConnection polaczenie = polaczenieMySQL.Polacz();
                MySqlCommand pytanie = new MySqlCommand(pytanie_sql, polaczenie);
                MySqlDataReader wynik;
                wynik = pytanie.ExecuteReader();
                while (wynik.Read())
                {
                    ile_przyjetych = wynik.GetValue(0).ToString();

                }
                polaczenieMySQL.Zamknij(polaczenie);



            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Pobranie_ostatniego_nr_zamowienia_dla_wybranego_miasta");
            }  //ile przytjetych (dat przyj)

            try
            {
                string pytanie_sql = "SELECT " +
                   "COUNT(`Nr_zamowienia`) AS 'Ilość zamówień' " +
                    " FROM " +
                    Properties.Settings.Default.aktualne_miasto + " WHERE  `Data_przyjecia` BETWEEN '" + data_od + "' AND '" + data_do + "' AND  `Rozliczony`=True" +
                    " ORDER BY  `" + Properties.Settings.Default.aktualne_miasto + "`.`Nr_zamowienia` DESC";
                Polaczenie polaczenieMySQL = new Polaczenie();
                MySqlConnection polaczenie = polaczenieMySQL.Polacz();
                MySqlCommand pytanie = new MySqlCommand(pytanie_sql, polaczenie);
                MySqlDataReader wynik;
                wynik = pytanie.ExecuteReader();
                while (wynik.Read())
                {
                    ile_rozliczonych = wynik.GetValue(0).ToString();

                }
                polaczenieMySQL.Zamknij(polaczenie);

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Pobranie_ostatniego_nr_zamowienia_dla_wybranego_miasta");
            }  //ile rozliczonych (dat przyj)

            try
            {
                string pytanie_sql = "SELECT " +
                   "COUNT(`Nr_zamowienia`) AS 'Ilość zamówień' " +
                    " FROM " +
                    Properties.Settings.Default.aktualne_miasto + " WHERE  `Data_rozliczenia` BETWEEN '" + data_od + "' AND '" + data_do + "' AND  `Rozliczony`=True" +
                    " ORDER BY  `" + Properties.Settings.Default.aktualne_miasto + "`.`Nr_zamowienia` DESC";
                Polaczenie polaczenieMySQL = new Polaczenie();
                MySqlConnection polaczenie = polaczenieMySQL.Polacz();
                MySqlCommand pytanie = new MySqlCommand(pytanie_sql, polaczenie);
                MySqlDataReader wynik;
                wynik = pytanie.ExecuteReader();
                while (wynik.Read())
                {
                    ile_rozliczonych_wedlug_roz = wynik.GetValue(0).ToString();

                }
                polaczenieMySQL.Zamknij(polaczenie);

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Pobranie_ostatniego_nr_zamowienia_dla_wybranego_miasta");
            }  //ile rozliczonych (dat roz)

        }

        private void Wszystkie_zamowienia()
        {
            try
            {
                string pytanie_sql = "SELECT " +
                    "`Nr_zamowienia` AS 'Numer zamówienia.', " +
                     " DATE_FORMAT(`Data_przyjecia`, '%Y-%m-%d') AS 'Data przyjecia'," +
                    "`Zadatek`," +
                      " DATE_FORMAT(`Data_rozliczenia`, '%Y-%m-%d') AS 'Data rozliczenia'," +
                    "`Raty`," +
                    "Round((`ilosc_p_1` *(`kwota_p_1` -((`rabat_p_1` / 100) * `kwota_p_1`))+ " +
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
                    "`Rozliczony`," +
                     "`Gratis`" +
                    " FROM " + Properties.Settings.Default.aktualne_miasto + " WHERE  `Data_przyjecia` BETWEEN '" + data_od + "' AND '" + data_do + "'  ORDER BY  `Nr_zamowienia` DESC";
                Polaczenie polaczenieMySQL = new Polaczenie();
                MySqlConnection polaczenie = polaczenieMySQL.Polacz();
                MySqlCommand pytanie = new MySqlCommand(pytanie_sql, polaczenie);
                MySqlDataReader wynik;
                wynik = pytanie.ExecuteReader();
                while (wynik.Read())
                {
                    string[] data_przyj = wynik.GetString(1).Split(null);
                    DateTime dat = new DateTime(2010, 01, 01);
                    string dattt = " ";

                    try
                    {
                        string[] data_roz = wynik.GetString(3).Split(null);
                        if (data_roz[0] != "0000-00-00")  dattt = data_roz[0];                        
                           
                    }
                    catch (Exception){ }


                    Row row1 = this.table.AddRow();
                    if (wynik.GetValue(7).ToString() == "True") row1.Shading.Color = Colors.LightGray;
                    row1.TopPadding = 5;
                    row1.BottomPadding = 5;
                    row1.VerticalAlignment = VerticalAlignment.Center;
                    row1.Cells[0].AddParagraph(wynik.GetString(0));
                    row1.Cells[1].AddParagraph(data_przyj[0]);
                    row1.Cells[2].AddParagraph(dattt);

                    if (wynik.GetInt16(8) == 0)
                    {
                        row1.Cells[3].AddParagraph((Convert.ToDouble(wynik.GetValue(5).ToString())).ToString("##,##0.00") + " zł");
                        suma_zk += Convert.ToDouble(wynik.GetValue(5));
                    }
                    else
                    {
                        row1.Cells[3].AddParagraph((Convert.ToDouble((wynik.GetDecimal(5) + 1).ToString())).ToString("##,##0.00") + " zł");
                        suma_zk += Convert.ToDouble((wynik.GetDecimal(5) + 1));
                    }

                    row1.Cells[4].AddParagraph((Convert.ToDouble(wynik.GetValue(2).ToString())).ToString("##,##0.00") + " zł");
                    if (wynik.GetBoolean(7)==false)
                    {
                        if (wynik.GetInt16(8) != 0)
                        {
                            row1.Cells[5].AddParagraph((Convert.ToDouble((wynik.GetDecimal(6) + 1).ToString())).ToString("##,##0.00") + " zł");
                            suma_doplata += Convert.ToDouble(wynik.GetDecimal(6) + 1);
                        }
                        else
                        {
                            row1.Cells[5].AddParagraph((Convert.ToDouble(wynik.GetValue(6).ToString())).ToString("##,##0.00") + " zł");
                            suma_doplata += Convert.ToDouble(wynik.GetDecimal(6));
                        }
                    }
                    else
                        row1.Cells[5].AddParagraph("0.00 zł");

                    if (wynik.GetString(4) == "True")
                    {
                        row1.Cells[6].AddParagraph("TAK");
                    }


                    this.table.SetEdge(0, this.table.Rows.Count - 2, 7, 2, Edge.Box, MigraDoc.DocumentObjectModel.BorderStyle.Single, 0.75);
                }
                polaczenieMySQL.Zamknij(polaczenie);



            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Pobranie_ostatniego_nr_zamowienia_dla_wybranego_miasta");
            }

            Paragraph paragraph = section.Footers.Primary.AddParagraph();
            paragraph = section.AddParagraph();
            paragraph.AddText("Łączna kwota zamówień: " + suma_zk.ToString("##,##0.00") + " zł");
            paragraph.Style = "TNR12";

            paragraph = section.AddParagraph();
            paragraph.AddText("Do dopłaty pozostało: " + suma_doplata.ToString("##,##0.00") + " zł");
            paragraph.Style = "TNR12";
        }

        private void Rozliczone_zamowienia()
        {
            section = this.document.AddSection();
            Paragraph paragraph = section.Footers.Primary.AddParagraph();

            paragraph = section.AddParagraph();
            paragraph.AddText("W podanym okresie rozliczono: " + ile_rozliczonych_wedlug_roz);
            paragraph.Style = "TNR12";

            ///////////
            Tworzenie_tabeli();

            try
            {
                string pytanie_sql = "SELECT " +
                    "`Nr_zamowienia` AS 'Numer zamówienia.', " +
                     " DATE_FORMAT(`Data_przyjecia`, '%Y-%m-%d') AS 'Data przyjecia'," +
                    "`Zadatek`," +
                      " DATE_FORMAT(`Data_rozliczenia`, '%Y-%m-%d') AS 'Data rozliczenia'," +
                    "`Raty`," +
                    "Round((`ilosc_p_1` *(`kwota_p_1` -((`rabat_p_1` / 100) * `kwota_p_1`))+ " +
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
                    "`Rozliczony`," +
                     "`Gratis`" +
                    " FROM " + Properties.Settings.Default.aktualne_miasto + " WHERE  `Data_rozliczenia` BETWEEN '" + data_od + "' AND '" + data_do + "' AND  `Rozliczony`=True" +
                    " ORDER BY  `" + Properties.Settings.Default.aktualne_miasto + "`.`Nr_zamowienia` DESC";
                Polaczenie polaczenieMySQL = new Polaczenie();
                MySqlConnection polaczenie = polaczenieMySQL.Polacz();
                MySqlCommand pytanie = new MySqlCommand(pytanie_sql, polaczenie);
                MySqlDataReader wynik;
                wynik = pytanie.ExecuteReader();
                while (wynik.Read())
                {

                    string[] data_przyj = wynik.GetString(1).Split(null);
                    DateTime dat = new DateTime(2010, 01, 01);
                    string dattt = " ";

                    try
                    {
                        string[] data_roz = wynik.GetString(3).Split(null);
                        if (data_roz[0] != "0000-00-00")  dattt = data_roz[0];
                    }
                    catch (Exception)
                    {

                    }

                    Row row1 = this.table.AddRow();

                    row1.TopPadding = 5;
                    row1.BottomPadding = 5;
                    row1.VerticalAlignment = VerticalAlignment.Center;
                    row1.Cells[0].AddParagraph(wynik.GetString(0));
                    row1.Cells[1].AddParagraph(data_przyj[0]);
                    row1.Cells[2].AddParagraph(dattt);
                    if (wynik.GetInt16(8) == 0)
                    {
                        row1.Cells[3].AddParagraph((Convert.ToDouble(wynik.GetValue(5).ToString())).ToString("##,##0.00") + " zł");
                    }
                    else
                    {
                        row1.Cells[3].AddParagraph((Convert.ToDouble((wynik.GetDecimal(5) + 1).ToString())).ToString("##,##0.00") + " zł");
                    }
                    row1.Cells[4].AddParagraph((Convert.ToDouble(wynik.GetValue(2).ToString())).ToString("##,##0.00") + " zł");
                    if (wynik.GetInt16(8) != 0)
                    {
                        row1.Cells[5].AddParagraph((Convert.ToDouble((wynik.GetDecimal(6) + 1).ToString())).ToString("##,##0.00") + " zł");
                        suma_rozliczono += Convert.ToDouble(wynik.GetDecimal(6) + 1);
                    }
                    else
                    {
                        row1.Cells[5].AddParagraph((Convert.ToDouble(wynik.GetValue(6).ToString())).ToString("##,##0.00") + " zł");
                        suma_rozliczono += Convert.ToDouble(wynik.GetDecimal(6));
                    }


                    if (wynik.GetString(4) == "True")
                    {
                        row1.Cells[6].AddParagraph("TAK");
                    }


                    this.table.SetEdge(0, this.table.Rows.Count - 2, 7, 2, Edge.Box, MigraDoc.DocumentObjectModel.BorderStyle.Single, 0.75);
                }
                polaczenieMySQL.Zamknij(polaczenie);


            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Pobranie_ostatniego_nr_zamowienia_dla_wybranego_miasta");
            }

            //////////
            paragraph = section.AddParagraph();
            paragraph.AddText("Łącznie dopłacono: " + suma_rozliczono.ToString("##,##0.00") + " zł");
            paragraph.Style = "TNR12";
        }

    }
}

using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Shapes;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.Rendering;
using PdfSharp.Pdf;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace SPOZ

{
    class Drukowanie_PDF
    {

        Document document;
        private TextFrame addressFrame;
        private Table table;
        //private Color TableBorder;
        Section section;
        private string  data_przyjecia, dane_klienta, adres_kl_2, termin_realizacji, transport, uwagi, numer_zamowienia; /*miasto, kod_pocztowy, adres_1, adres_2,*/
        private string pom_termin;
        private String[] produkt = new String[6] { "", "", "", "", "", "" };
        private Double[] ilosc = new Double[6] { 0, 0, 0, 0, 0, 0 };
        private Double[] rabat = new Double[6] { 0, 0, 0, 0, 0, 0 };
        private Double[] cena_jednostkowa = new Double[6] { 0, 0, 0, 0, 0, 0 };
        private Double zadatek = 0;
        private int id_gratis = 0;
        int ilosc_prod = 1;

        public Color TableGray { get; private set; }

        private void Wprowadzanie_danych_sklepu(string nr_zk)
        {
            Metody_bazy.Dane_sklepu_z_bazy();
            String[] stringi_podzielone = nr_zk.Split('/');
            numer_zamowienia = stringi_podzielone[0] + "/" + Metody_bazy.Krotka_nazwa + "/" + stringi_podzielone[1];

            String sDate = DateTime.Now.ToString();
            DateTime datevalue = (Convert.ToDateTime(sDate.ToString()));
            String yy = datevalue.Year.ToString();

            DateTime sDate2 = DateTime.Now;
            int tydz_roku = Convert.ToInt16(sDate2.DayOfYear.ToString());
            if (termin_realizacji== "nie dotyczy")
            {
                pom_termin = "nie dotyczy";
            }
            else if ((tydz_roku/7)-10>Convert.ToInt16(termin_realizacji))
            {
                pom_termin = termin_realizacji + " tydzień roku " + (Convert.ToInt16(yy) + 1).ToString() + "(+, - 5 dni roboczych)";
            }
            else
                pom_termin = termin_realizacji + " tydzień roku " + (Convert.ToInt16(yy)).ToString() + "(+, - 5 dni roboczych)";
            

        }
        
        public void Druk_PDF(int id_gratisu,string numer_edytowanego_zk, int ilosc_produktow, double zadatek_zk, string data_przyjecia_ZK, string dane_klienta_komplet, string dodatkowy_adres_dostawy, string termin_realizacji_zk, string rodzaj_transportu, string dodatkowe_uwagi)
        {
            id_gratis = id_gratisu;
            ilosc_prod = ilosc_produktow;
            zadatek = zadatek_zk;
            data_przyjecia = data_przyjecia_ZK;
            dane_klienta = dane_klienta_komplet;
            adres_kl_2 = dodatkowy_adres_dostawy;
            termin_realizacji = termin_realizacji_zk;
            transport = rodzaj_transportu;
            uwagi = dodatkowe_uwagi;

            Wprowadzanie_danych_sklepu(numer_edytowanego_zk);
        }

        public void Druk_produktow(string produkt_1, string produkt_2, string produkt_3, string produkt_4, string produkt_5, string produkt_6)
        {
            produkt[0] = produkt_1;
            produkt[1] = produkt_2;
            produkt[2] = produkt_3;
            produkt[3] = produkt_4;
            produkt[4] = produkt_5;
            produkt[5] = produkt_6;

        }
        public void Druk_ilosc(Double ilosc_1, Double ilosc_2, Double ilosc_3, Double ilosc_4, Double ilosc_5, Double ilosc_6)
        {
            ilosc[0] = ilosc_1;
            ilosc[1] = ilosc_2;
            ilosc[2] = ilosc_3;
            ilosc[3] = ilosc_4;
            ilosc[4] = ilosc_5;
            ilosc[5] = ilosc_6;
        }
        public void Druk_rabat(Double rabat_1, Double rabat_2, Double rabat_3, Double rabat_4, Double rabat_5, Double rabat_6)
        {
            rabat[0] = rabat_1;
            rabat[1] = rabat_2;
            rabat[2] = rabat_3;
            rabat[3] = rabat_4;
            rabat[4] = rabat_5;
            rabat[5] = rabat_6;
        }
        public void Druk_cena_jednostkowa(Double cena_jednostkowa_1, Double cena_jednostkowa_2, Double cena_jednostkowa_3, Double cena_jednostkowa_4, Double cena_jednostkowa_5, Double cena_jednostkowa_6)
        {
            cena_jednostkowa[0] = cena_jednostkowa_1;
            cena_jednostkowa[1] = cena_jednostkowa_2;
            cena_jednostkowa[2] = cena_jednostkowa_3;
            cena_jednostkowa[3] = cena_jednostkowa_4;
            cena_jednostkowa[4] = cena_jednostkowa_5;
            cena_jednostkowa[5] = cena_jednostkowa_6;
        }

        public static bool pdf_zamkniety = true;
        public void CreateDocument()
        {
            // Create a new MigraDoc document
            document = new Document();
            document.Info.Title = "Zamówienie";
            // document.Info.Subject = "Demonstrates how to create an invoice.";
            // document.Info.Author = "Stefan Lange";

            DefineStyles();
            CreatePage();
            FillContent_table();

            document.UseCmykColor = true;
            const bool unicode = true;
            const PdfFontEmbedding embedding = PdfFontEmbedding.Always;
            PdfDocumentRenderer pdfRenderer = new PdfDocumentRenderer(unicode, embedding)
            {Document = document};
            pdfRenderer.RenderDocument();
            //ścieżka dostępu 
            try
            {
                string filename = Sciezki.zamowienia + @"\ZK-" + numer_zamowienia.Replace('/','-') +".pdf";
                Sciezki.drukowane_zk = filename;
                pdfRenderer.PdfDocument.Save(filename);
                Process.Start(filename);
                pdf_zamkniety = true;
            }
            catch (Exception ex)
            {               
                MessageBox.Show(ex.Message, "Należy zamknąć poprzednie zamówienie.");
                pdf_zamkniety = false;
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
            // Each MigraDoc document needs at least one section.
            section = this.document.AddSection();
            Paragraph paragraph = section.Footers.Primary.AddParagraph();

            // Create the text frame for the address
            this.addressFrame = section.AddTextFrame();
            this.addressFrame.Height = "3.0cm";
            this.addressFrame.Width = "9.0cm";
            this.addressFrame.Left = ShapePosition.Left;
            this.addressFrame.RelativeHorizontal = RelativeHorizontal.Margin;
            this.addressFrame.Top = "2.0cm";
            this.addressFrame.RelativeVertical = RelativeVertical.Page;
            // Put sender in address frame
            paragraph = this.addressFrame.AddParagraph("SALON FIRMOWY KOŁO");
            paragraph.Style = "TNR12B";
            paragraph = this.addressFrame.AddParagraph(Metody_bazy.adres1);
            paragraph.Style = "TNR12";
            if (Metody_bazy.adres2!="")
            {
                paragraph = this.addressFrame.AddParagraph(Metody_bazy.adres2);
                paragraph.Style = "TNR12";
            }           
            paragraph = this.addressFrame.AddParagraph(Metody_bazy.kod_pocztowy_s    + " " + Metody_bazy.miejscowosc_s);
            paragraph.Style = "TNR12";
            paragraph = this.addressFrame.AddParagraph(Metody_bazy.telefon);
            paragraph.Style = "TNR12B";
            paragraph = this.addressFrame.AddParagraph("NIP:841-109-62-30");
            paragraph.Style = "TNR12";
            paragraph = this.addressFrame.AddParagraph("Nr rachunku: 25 1020 3844 0000 1902 0118 6428");
            paragraph.Style = "TNR12B";

            // Add the print date field
            paragraph = section.AddParagraph();
            paragraph.Format.SpaceBefore = "1cm";
            paragraph.Format.SpaceAfter = "2,5cm";
            paragraph.Style = "Reference";
            paragraph.AddTab();
            paragraph.AddText(Metody_bazy.miejscowosc_s + ", dn. " + data_przyjecia);
            //////////
            paragraph = section.AddParagraph();
            paragraph.AddText("Zamówienie " + numer_zamowienia);
            paragraph.Format.Alignment = ParagraphAlignment.Center;
            paragraph.Format.Font.Name = "Times New Roman";
            paragraph.Format.Font.Size = 18;
            paragraph.Format.Font.Bold = true;
            paragraph.Format.SpaceBefore = 15;
            paragraph.Format.SpaceAfter = 3;
            ///////////
            paragraph = section.AddParagraph();
            paragraph.AddText(dane_klienta);
            paragraph.Style = "TNR12";


            // Create the item table
            this.table = section.AddTable();
            this.table.Style = "Table";
            this.table.Borders.Width = 0.25;
            this.table.Borders.Left.Width = 0.5;
            this.table.Borders.Right.Width = 0.5;
            this.table.Rows.LeftIndent = 0;


            // Before you can add a row, you must define the columns
            Column column = this.table.AddColumn("4cm");
            column.Format.Alignment = ParagraphAlignment.Left;
            column = this.table.AddColumn("2cm");
            column.Format.Alignment = ParagraphAlignment.Center;
            column = this.table.AddColumn("1cm");
            column.Format.Alignment = ParagraphAlignment.Right;
            column = this.table.AddColumn("2cm");
            column.Format.Alignment = ParagraphAlignment.Center;
            column = this.table.AddColumn("2cm");
            column.Format.Alignment = ParagraphAlignment.Center;
            column = this.table.AddColumn("1cm");
            column.Format.Alignment = ParagraphAlignment.Center;
            column = this.table.AddColumn("2cm");
            column.Format.Alignment = ParagraphAlignment.Center;
            column = this.table.AddColumn("2cm");
            column.Format.Alignment = ParagraphAlignment.Right;

            // Create the header of the table
            Row row = table.AddRow();
            row.HeadingFormat = true;
            row.Format.Alignment = ParagraphAlignment.Left;
            row.VerticalAlignment = VerticalAlignment.Bottom;
            row.Format.Font.Bold = false;
            row.Shading.Color = Colors.Aqua;
            row.TopPadding = 3.5;
            ////////////////////////////
            row.Cells[0].AddParagraph("Nazwa Towaru");
            row.Cells[1].AddParagraph("Cena jednostkowa");
            row.Cells[2].AddParagraph("Ilość");
            row.Cells[3].AddParagraph("Wartość netto");
            row.Cells[4].AddParagraph("Wartosć Vat");
            row.Cells[5].AddParagraph("Rabat");
            row.Cells[6].AddParagraph("Należność");
            row.Cells[7].AddParagraph("Należność z Rabatem");
            row.Cells[7].Format.Font.Bold = true;

            this.table.SetEdge(0, 0, 8, 1, Edge.Box, MigraDoc.DocumentObjectModel.BorderStyle.Single, 0.75, MigraDoc.DocumentObjectModel.Color.Empty);
            this.table.SetEdge(0, 0, 8, 1, Edge.Box, MigraDoc.DocumentObjectModel.BorderStyle.Single, 0.75);
        }

        void FillContent_table()
        {
            Double suma;
            suma = 0;
            // Fill address in address text frame            
            Paragraph paragraph = this.addressFrame.AddParagraph();

            for (int i = 0; i < ilosc_prod; i++)
            {

                Row row1 = this.table.AddRow();
                //row1.TopPadding = 19;

                row1.VerticalAlignment = VerticalAlignment.Bottom;
                row1.HeightRule = RowHeightRule.AtLeast;
                row1.Height = 25;

                row1.Cells[0].VerticalAlignment = VerticalAlignment.Top;
                row1.Cells[0].AddParagraph(produkt[i]);
                row1.Cells[1].AddParagraph(cena_jednostkowa[i].ToString("##,##0.00") + " zł");
                row1.Cells[2].AddParagraph(ilosc[i].ToString());
                row1.Cells[3].AddParagraph(((cena_jednostkowa[i] * ilosc[i] * 100) / 123).ToString("##,##0.00") + " zł");
                row1.Cells[4].AddParagraph(((cena_jednostkowa[i] * ilosc[i]) - (cena_jednostkowa[i] * ilosc[i] * 100) / 123).ToString("##,##0.00") + " zł");
                row1.Cells[5].AddParagraph(rabat[i].ToString("0.0") + "%");
                row1.Cells[6].AddParagraph((cena_jednostkowa[i] * ilosc[i]).ToString("##,##0.00") + " zł");
                row1.Cells[7].AddParagraph(Oblicz_naleznosc(i).ToString("##,##0.00") + " zł");

                suma += Oblicz_naleznosc(i);

                this.table.SetEdge(7, this.table.Rows.Count - 2, 1, 2, Edge.Box, MigraDoc.DocumentObjectModel.BorderStyle.Single, 0.75);
                this.table.SetEdge(0, this.table.Rows.Count - 2, 8, 2, Edge.Box, MigraDoc.DocumentObjectModel.BorderStyle.Single, 0.75);
            }

            if (id_gratis!=0)
            {
                Metody_bazy.Wczytanie_gratisu_o_id(id_gratis);
                Row row1 = this.table.AddRow();
                row1.VerticalAlignment = VerticalAlignment.Bottom;
                row1.HeightRule = RowHeightRule.AtLeast;
                row1.Height = 25;

                row1.Cells[0].VerticalAlignment = VerticalAlignment.Top;
                row1.Cells[0].AddParagraph(Metody_bazy.nazwa_gratisu);
                row1.Cells[1].AddParagraph(Metody_bazy.cena_gratisu.ToString("##,##0.00") + " zł");
                row1.Cells[2].AddParagraph("1");
                row1.Cells[3].AddParagraph(((Metody_bazy.cena_gratisu * 100) / 123).ToString("##,##0.00") + " zł");
                row1.Cells[4].AddParagraph(((Metody_bazy.cena_gratisu) - (Metody_bazy.cena_gratisu * 100) / 123).ToString("##,##0.00") + " zł");
                row1.Cells[5].AddParagraph(Metody_bazy.rabat_gratisu.ToString("0.0") + "%");
                row1.Cells[6].AddParagraph((Metody_bazy.cena_gratisu).ToString("##,##0.00") + " zł");
                row1.Cells[7].AddParagraph((1).ToString("##,##0.00") + " zł");

                suma += 1;

                this.table.SetEdge(7, this.table.Rows.Count - 2, 1, 2, Edge.Box, MigraDoc.DocumentObjectModel.BorderStyle.Single, 0.75);
                this.table.SetEdge(0, this.table.Rows.Count - 2, 8, 2, Edge.Box, MigraDoc.DocumentObjectModel.BorderStyle.Single, 0.75);


            }


            // Add an invisible row as a space line to the table
            Row row = this.table.AddRow();
            row.HeightRule = RowHeightRule.AtLeast;
            row.Height = 25;
            //row.Borders.Visible = false;
            row.Cells[0].Borders.Visible = false;
            row.Cells[0].AddParagraph("Razem");
            row.Cells[0].VerticalAlignment = VerticalAlignment.Bottom;
            row.Cells[0].Format.Font.Bold = true;
            row.Cells[0].Format.Alignment = ParagraphAlignment.Right;
            row.Cells[0].MergeRight = 6;
            row.Cells[7].VerticalAlignment = VerticalAlignment.Bottom;
            row.Cells[7].AddParagraph(suma.ToString("##,##0.00") + "zł");

            this.table.SetEdge(7, this.table.Rows.Count - 1, 1, 1, Edge.Box, MigraDoc.DocumentObjectModel.BorderStyle.Single, 0.75);

            //// KONIEC TABELI -----------------------------


            paragraph = section.AddParagraph();
            paragraph.AddText("Zadatek: " + zadatek.ToString("##,##0.00") + " zł");
            paragraph.Style = "TNR12B";

            paragraph = section.AddParagraph();
            paragraph.AddText("Transport:" + transport);
            paragraph.Style = "TNR12B";

            paragraph = section.AddParagraph();
            if (adres_kl_2.Length <= 3)
            {
                paragraph.AddText("Adres dostawy towaru: j/w");
            }
            else
                paragraph.AddText("Adres dostawy towaru:" + adres_kl_2);
            paragraph.Style = "TNR12B";

            paragraph = section.AddParagraph();
            if (uwagi.Length <= 3)
            {
                paragraph.AddText("Dodatkowe uwagi: BRAK");
            }
            else
                paragraph.AddText("Dodatkowe uwagi:" + uwagi);
            paragraph.Style = "TNR12";


            paragraph = section.AddParagraph();
            paragraph.AddText("Przewidywany termin realizacji: " + pom_termin);
            paragraph.Style = "TNR12";

            paragraph = section.AddParagraph();
            paragraph.AddText("Podpis klienta:");
            paragraph.Style = "TNR12";
            paragraph.Style = "Reference";
            paragraph.AddTab();
            paragraph.AddText("Podpis sprzedawcy: ");

            paragraph = section.AddParagraph();
            paragraph.AddText("..................");
            paragraph.Style = "TNR12";
            paragraph.Style = "Reference";
            paragraph.AddTab();
            paragraph.AddText(".................. ");

            paragraph = section.AddParagraph();
            paragraph.AddText("Niniejszy dokument zamówienia stanowi jednocześnie podstawę do ewentualnych reklamacji. W przypadku utraty paragonu bądź faktury, wyblaknięcia lub tp. reklamacja zostanie przyjęta na podstawie tego dokumentu.");
            paragraph.Format.Font.Name = "Times New Roman";
            paragraph.Format.Font.Size = 10;
            paragraph.Format.Font.Italic = true;
            paragraph.Format.SpaceAfter = 10;



            paragraph = section.AddParagraph();
            paragraph.AddText("Drodzy klienci, dostarczenie zamawianego towaru pod wskazany adres nie uwzględnia jego wniesienia, rozpakowania i montażu.  Jedynie w uzasadnionych przypadkach kierowca może pomóc w tych czynnościach.");
            paragraph.Format.Font.Name = "Times New Roman";
            paragraph.Format.Font.Size = 10;
            paragraph.Format.Font.Italic = true;
            paragraph.Format.SpaceAfter = 6;


            paragraph = section.AddParagraph();
            paragraph.AddText("Wydanie towaru klientowi następuje w chwili opłacenia zamówienia przez klienta.");
            paragraph.Format.Font.Name = "Times New Roman";
            paragraph.Format.Font.Size = 10;
            paragraph.Format.Font.Italic = true;
            paragraph.Format.Font.Bold = true;
            paragraph.Format.SpaceAfter = 3;
        }

        private double Oblicz_naleznosc(int i)
        {
            Double a, b;
            a = cena_jednostkowa[i] * ilosc[i];
            b = (rabat[i] / 100) * a;
            return a - b;
        }
    }
}
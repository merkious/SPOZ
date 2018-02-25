using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Shapes;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.Rendering;
using PdfSharp.Pdf;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace SPOZ.PDF
{
    class Druk_fv
    {
        private string numer_faktury,
            data_wystawienia,
           // kwota_slowna,
            odbiorca_pol_1,
            odbiorca_pol_2,
            odbiorca_pol_3,
            odbiorca_pol_4;
        private Document document;
        private Section section;
        private TextFrame addressFrame;
        private Table table;
        //private Double suma;
        

        public Druk_fv(string data_rozliczenia)
        {
            Metody_bazy.Wyciaganie_nazw_zamowionych_produktow();
            Metody_bazy.Wczytanie_zamowienia_do_edycji();
            odbiorca_pol_1 = Metody_bazy.imie_nazwisko;
            odbiorca_pol_2 = Metody_bazy.ulica_nr;
            odbiorca_pol_3 = Metody_bazy.kod_pocztowy +" " + Metody_bazy.miejscowosc;
            odbiorca_pol_4 = " ";
            String[] rok = data_rozliczenia.Split('-');
            numer_faktury = Metody_bazy.Numer_fv(rok[0]);
            data_wystawienia = data_rozliczenia;
            String[] stringi_podzielone = numer_faktury.Split('/');
            numer_faktury = stringi_podzielone[0] + "/" + Metody_bazy.Krotka_nazwa + "/" + stringi_podzielone[1];
            Sciezki.numer_tworzonej_faktury = numer_faktury;
            CreateDocument();
            
        }
        public Druk_fv(string data_rozliczenia, string nazwa_firmy, string Kod_plus_miejscowosc, string adres, string nip)
        {
            Metody_bazy.Wyciaganie_nazw_zamowionych_produktow();
            Metody_bazy.Wczytanie_zamowienia_do_edycji();
            String[] rok = data_rozliczenia.Split('-');
            numer_faktury = Metody_bazy.Numer_fv(rok[0]);
            data_wystawienia = data_rozliczenia;            
            odbiorca_pol_1 = nazwa_firmy;
            odbiorca_pol_2 = Kod_plus_miejscowosc;
            odbiorca_pol_3 = adres;
            odbiorca_pol_4 = "NIP: "+nip;
            String[] stringi_podzielone = numer_faktury.Split('/');
            numer_faktury = stringi_podzielone[0] + "/" + Metody_bazy.Krotka_nazwa + "/" + stringi_podzielone[1];
            Sciezki.numer_tworzonej_faktury = numer_faktury;
            CreateDocument();            
        }

        public Druk_fv(string numer_FV, string data_rozliczenia, string nazwa_firmy, string Kod_plus_miejscowosc, string adres, string nip)
        {
            Metody_bazy.Wyciaganie_nazw_zamowionych_produktow();
            Metody_bazy.Wczytanie_zamowienia_do_edycji();            
            numer_faktury = numer_FV;

            data_wystawienia = data_rozliczenia;
            odbiorca_pol_1 = nazwa_firmy;
            odbiorca_pol_2 = Kod_plus_miejscowosc;
            odbiorca_pol_3 = adres;
            odbiorca_pol_4 = "NIP: " + nip;
            String[] stringi_podzielone = numer_faktury.Split('/');
            numer_faktury = stringi_podzielone[0] + "/" + Metody_bazy.Krotka_nazwa + "/" + stringi_podzielone[1];
            Sciezki.numer_tworzonej_faktury = numer_faktury;
            CreateDocument();
        }
        public Druk_fv(string numer_FV, string data_rozliczenia)
        {
            Metody_bazy.Wyciaganie_nazw_zamowionych_produktow();
            Metody_bazy.Wczytanie_zamowienia_do_edycji();
            odbiorca_pol_1 = Metody_bazy.imie_nazwisko;
            odbiorca_pol_2 = Metody_bazy.ulica_nr;
            odbiorca_pol_3 = Metody_bazy.kod_pocztowy + " " + Metody_bazy.miejscowosc;
            odbiorca_pol_4 = " ";

            numer_faktury = numer_FV;
            data_wystawienia = data_rozliczenia;
            String[] stringi_podzielone = numer_faktury.Split('/');
            numer_faktury = stringi_podzielone[0] + "/" + Metody_bazy.Krotka_nazwa + "/" + stringi_podzielone[1];
            Sciezki.numer_tworzonej_faktury = numer_faktury;
            CreateDocument();

        }

        public void CreateDocument()
        {
            
           

            // Create a new MigraDoc document
            document = new Document();
            document.Info.Title = "Zamówienie";
            // document.Info.Subject = "Demonstrates how to create an invoice.";
            // document.Info.Author = "Stefan Lange";
            document.DefaultPageSetup.RightMargin = 20;
            document.DefaultPageSetup.LeftMargin = 40;
            document.DefaultPageSetup.TopMargin = 40;

            DefineStyles();
            CreatePage();
            Create_Table();
           // FillContent_table();

            document.UseCmykColor = true;
            const bool unicode = true;
            const PdfFontEmbedding embedding = PdfFontEmbedding.Always;
            PdfDocumentRenderer pdfRenderer = new PdfDocumentRenderer(unicode, embedding)
            {Document = document};
            pdfRenderer.RenderDocument();
            //ścieżka dostępu 
            try
            {
                string filename = Sciezki.faktury + @"\FV-" + numer_faktury.Replace('/', '-') + ".pdf";
                Sciezki.drukowane_zk = filename;
                pdfRenderer.PdfDocument.Save(filename);
                Process.Start(filename);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Należy zamknąć poprzednie zamówienie.");
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

            style = this.document.Styles.AddStyle("TNR9", "Normal");
            style.Font.Name = "Times New Roman";
            style.ParagraphFormat.SpaceAfter = "3";
            style.Font.Color = Colors.Black;
            style.Font.Size = 10;


            style = this.document.Styles.AddStyle("TNR7", "Normal");
            style.Font.Name = "Times New Roman";
            style.ParagraphFormat.SpaceAfter = "2";
            style.Font.Color = Colors.Black;
            style.Font.Size = 7;

            style = this.document.Styles.AddStyle("TNR12B", "Normal");
            style.Font.Name = "Times New Roman";
            style.Font.Color = Colors.Black;
            style.Font.Size = 12;
            style.ParagraphFormat.SpaceAfter = "3";
            style.Font.Bold = true;


            // Create a new style called Reference based on style Normal
            style = this.document.Styles.AddStyle("Reference", "Normal");
            style.Font.Size = 7;
            style.ParagraphFormat.SpaceBefore = "2mm";
            style.ParagraphFormat.SpaceAfter = "2mm";
            style.ParagraphFormat.TabStops.AddTabStop("18cm", MigraDoc.DocumentObjectModel.TabAlignment.Right);
        }


        void CreatePage()
        {
            // Each MigraDoc document needs at least one section.
            section = this.document.AddSection();

            Paragraph paragraph = section.AddParagraph(); //Footers.Primary.AddParagraph();

            paragraph = section.AddParagraph();
            
            paragraph.AddText("FAKTURA VAT");
            paragraph.Format.Alignment = ParagraphAlignment.Center;
            paragraph.Format.Font.Name = "Times New Roman";
            paragraph.Format.Font.Size = 12;
            paragraph.Format.Font.Bold = true;
            paragraph.Format.SpaceBefore = 1;
            paragraph.Format.SpaceAfter = 3;

            paragraph = section.AddParagraph();
            paragraph.AddText(numer_faktury);
            paragraph.Format.Alignment = ParagraphAlignment.Center;
            paragraph.Format.Font.Name = "Times New Roman";
            paragraph.Format.Font.Size = 9;
            paragraph.Format.Font.Bold = true;            
            paragraph.Format.SpaceAfter = 3;

            paragraph = section.AddParagraph();
            paragraph.AddText("KOPIA/ORYGINAŁ");
            paragraph.Format.Alignment = ParagraphAlignment.Center;
            paragraph.Format.Font.Name = "Times New Roman";
            paragraph.Format.Font.Size = 9;
            paragraph.Format.SpaceAfter = 50;



            // Create the text frame for the address
            this.addressFrame = section.AddTextFrame();
            this.addressFrame.Height = "3.0cm";
            this.addressFrame.Width = "5.5cm";
            this.addressFrame.Left = ShapePosition.Right;            
            this.addressFrame.RelativeHorizontal = RelativeHorizontal.Margin;
            this.addressFrame.Top = "2.0cm";
            this.addressFrame.RelativeVertical = RelativeVertical.Page;
            // Put sender in address frame
            paragraph = this.addressFrame.AddParagraph("Miejsce wystawienia: "+Metody_bazy.miejscowosc_s);
            paragraph.Style = "TNR9";
            paragraph = this.addressFrame.AddParagraph("Data wystawienia: "+ data_wystawienia);
            paragraph.Style = "TNR9";
            paragraph = this.addressFrame.AddParagraph("Data spzedaży: "+ data_wystawienia);
            paragraph.Style = "TNR9";
            paragraph = this.addressFrame.AddParagraph(" ");
            paragraph.Style = "TNR9";
            paragraph = this.addressFrame.AddParagraph("Sposób zapłaty: zapłacono gotówką");
            paragraph.Style = "TNR9";
            paragraph = this.addressFrame.AddParagraph("Termin zapłaty: " + data_wystawienia);
            paragraph.Style = "TNR9";




            // Create the item table
            this.table = section.AddTable();
            this.table.Style = "Table";
            this.table.Borders.Width = 0.25;
            this.table.Borders.Left.Width = 0.5;
            this.table.Borders.Right.Width = 0.5;
            this.table.Rows.LeftIndent = 0;


            // Before you can add a row, you must define the columns
            Column column = this.table.AddColumn("7cm");
            column.Format.Alignment = ParagraphAlignment.Left;
            column = this.table.AddColumn("4cm");
            column.Format.Alignment = ParagraphAlignment.Center;
            column = this.table.AddColumn("7cm");
            column.Format.Alignment = ParagraphAlignment.Right;



            // Create the header of the table
            Row row = table.AddRow();
            row.HeadingFormat = true;
            row.Format.Alignment = ParagraphAlignment.Left;
            row.VerticalAlignment = VerticalAlignment.Bottom;
            row.Format.Font.Bold = true;
            row.Borders.Visible = false;
            row.TopPadding = 3.5;
            row.BottomPadding = 10;
            row.Style = "TNR9";
            ////////////////////////////

            row.Cells[0].AddParagraph("Sprzedawca:");
            row.Cells[2].AddParagraph("Nabywca:");

            row = table.AddRow();
            row.TopPadding = 3.5;
            row.Style = "TNR9";
            row.Cells[1].Borders.Visible = false;
            row.Cells[0].AddParagraph("SALON FIRMOWY KOŁO");
            row.Cells[0].AddParagraph(Metody_bazy.adres1);
            row.Cells[0].AddParagraph(Metody_bazy.adres2);
            row.Cells[0].AddParagraph(Metody_bazy.kod_pocztowy_s + " "+ Metody_bazy.miejscowosc_s);
            row.Cells[0].AddParagraph("tel."+Metody_bazy.telefon);
            row.Cells[0].AddParagraph("NIP:841-109-62-30 Regon 301679881");

            row.Cells[2].AddParagraph(odbiorca_pol_1);
            row.Cells[2].AddParagraph(odbiorca_pol_2);
            row.Cells[2].AddParagraph(odbiorca_pol_3);
            row.Cells[2].AddParagraph(odbiorca_pol_4);


            // this.table.SetEdge(0, 0, 3, 2, Edge.Box, MigraDoc.DocumentObjectModel.BorderStyle.Single, 0.75, MigraDoc.DocumentObjectModel.Color.Empty);

        }

        void Create_Table()
        {
            string dec_format = "##,##0.00";
            Paragraph para = section.AddParagraph();
            para.Format.SpaceAfter = 30;

            // Create the item table
            this.table = section.AddTable();
            this.table.Style = "Table";                       
            this.table.Borders.Width = 0.25;
            this.table.Borders.Left.Width = 0.5;
            this.table.Borders.Right.Width = 0.5;
            this.table.Rows.LeftIndent = 0;
            


            // Before you can add a row, you must define the columns
            Column column = this.table.AddColumn("0.8cm");
            column.Format.Alignment = ParagraphAlignment.Left;
            column = this.table.AddColumn("5.8cm");
            column.Format.Alignment = ParagraphAlignment.Center;
            column = this.table.AddColumn("1.9cm");
            column.Format.Alignment = ParagraphAlignment.Right;
            column = this.table.AddColumn("0.8cm");
            column.Format.Alignment = ParagraphAlignment.Right;
            column = this.table.AddColumn("0.8cm");
            column.Format.Alignment = ParagraphAlignment.Right;
            column = this.table.AddColumn("1.9cm");
            column.Format.Alignment = ParagraphAlignment.Right;
            column = this.table.AddColumn("1.6cm");
            column.Format.Alignment = ParagraphAlignment.Right;
            column = this.table.AddColumn("1.2cm");
            column.Format.Alignment = ParagraphAlignment.Right;
            column = this.table.AddColumn("1.6cm");
            column.Format.Alignment = ParagraphAlignment.Right;
            column = this.table.AddColumn("1.6cm");
            column.Format.Alignment = ParagraphAlignment.Right;


            // Create the header of the table
            Row row = table.AddRow();
            row.HeadingFormat = true;
            row.Format.Alignment = ParagraphAlignment.Center;
            row.VerticalAlignment = VerticalAlignment.Top;
            row.Format.Font.Bold = false;
            
            row.TopPadding = 1.5;
            row.BottomPadding = 1;
            row.Style = "TNR9";
            ////////////////////////////

            row.Cells[0].AddParagraph("Lp");            
            row.Cells[1].AddParagraph("Nazwa towaru/usługi");
            row.Cells[2].AddParagraph("Symbol PPKWiU/ PKOB");
            row.Cells[3].AddParagraph("Jm");
            row.Cells[4].AddParagraph("Ilość");
            row.Cells[5].AddParagraph("Cena jednostkowa netto");
            row.Cells[6].AddParagraph("Wartość netto");          
            row.Cells[7].AddParagraph("Stawka VAT [%]");
            row.Cells[8].AddParagraph("Kwota VAT");
            row.Cells[9].AddParagraph("Wartość brutto");

             Double ilosc, kwota; //rabat
            Double[] ilosc_tab = new Double[6] { Convert.ToDouble(Metody_bazy.ilosc_p_1), Convert.ToDouble(Metody_bazy.ilosc_p_2), Convert.ToDouble(Metody_bazy.ilosc_p_3), Convert.ToDouble(Metody_bazy.ilosc_p_4), Convert.ToDouble(Metody_bazy.ilosc_p_5), Convert.ToDouble(Metody_bazy.ilosc_p_6) };
            Double[] rabat_tab = new Double[6] { Convert.ToDouble(Metody_bazy.rabat_p_1), Convert.ToDouble(Metody_bazy.rabat_p_2), Convert.ToDouble(Metody_bazy.rabat_p_3), Convert.ToDouble(Metody_bazy.rabat_p_4), Convert.ToDouble(Metody_bazy.rabat_p_5), Convert.ToDouble(Metody_bazy.rabat_p_6) };
            Double[] kwota_tab = new Double[6] { Convert.ToDouble(Metody_bazy.kwota_p_1), Convert.ToDouble(Metody_bazy.kwota_p_2), Convert.ToDouble(Metody_bazy.kwota_p_3), Convert.ToDouble(Metody_bazy.kwota_p_4), Convert.ToDouble(Metody_bazy.kwota_p_5), Convert.ToDouble(Metody_bazy.kwota_p_6) };
            Double suma_netto, suma_vat, suma_brutto;
            suma_netto = suma_brutto = suma_vat = 0;
            int lp = 0;
            for (int i = 0; i < Convert.ToInt16(Metody_bazy.ilosc_produktow_combo); i++)
            {
                lp = i + 1;
                ilosc = ilosc_tab[i];
               //rabat = rabat_tab[i];
                kwota = kwota_tab[i]-(kwota_tab[i]*(rabat_tab[i]/100));
                row = table.AddRow();                
                row.Format.Alignment = ParagraphAlignment.Center;
                row.VerticalAlignment = VerticalAlignment.Top;
                row.Format.Font.Bold = false;
                row.TopPadding = 6;
                row.BottomPadding = 6;
                row.Style = "TNR9";                
                row.Cells[0].AddParagraph((i+1).ToString());
                row.Cells[1].AddParagraph(Metody_bazy.zamowienia_tablica[i]);
                row.Cells[1].Format.Alignment = ParagraphAlignment.Left;
                row.Cells[2].AddParagraph(" ");
                row.Cells[3].AddParagraph("szt");
                row.Cells[4].AddParagraph(ilosc.ToString());
                row.Cells[5].AddParagraph(((kwota*100)/123).ToString(dec_format));
                row.Cells[5].Format.Alignment = ParagraphAlignment.Right;
                row.Cells[6].AddParagraph((((kwota * 100) / 123)*ilosc).ToString(dec_format));
                suma_netto += ((kwota * 100) / 123) * ilosc;
                row.Cells[6].Format.Alignment = ParagraphAlignment.Right;
                row.Cells[7].AddParagraph("23");
                row.Cells[8].AddParagraph(((kwota * ilosc)- (((kwota * 100) / 123) * ilosc)).ToString(dec_format));
                row.Cells[8].Format.Alignment = ParagraphAlignment.Right;
                suma_vat += (kwota * ilosc) - (((kwota * 100) / 123) * ilosc);
                row.Cells[9].AddParagraph((kwota*ilosc).ToString(dec_format));
                row.Cells[9].Format.Alignment = ParagraphAlignment.Right;
                suma_brutto += kwota * ilosc;
            }

            if (Metody_bazy.gratis  !=0)
            {
                Metody_bazy.Wczytanie_gratisu_o_id(Metody_bazy.gratis);
                ilosc = 1;
                //rabat = rabat_tab[i];
                kwota = 1;
                row = table.AddRow();
                row.Format.Alignment = ParagraphAlignment.Center;
                row.VerticalAlignment = VerticalAlignment.Top;
                row.Format.Font.Bold = false;
                row.TopPadding = 6;
                row.BottomPadding = 6;
                row.Style = "TNR9";
                row.Cells[0].AddParagraph((lp + 1).ToString());
                row.Cells[1].AddParagraph(Metody_bazy.nazwa_gratisu);
                row.Cells[1].Format.Alignment = ParagraphAlignment.Left;
                row.Cells[2].AddParagraph(" ");
                row.Cells[3].AddParagraph("szt");
                row.Cells[4].AddParagraph(ilosc.ToString());
                row.Cells[5].AddParagraph(((kwota * 100) / 123).ToString(dec_format));
                row.Cells[5].Format.Alignment = ParagraphAlignment.Right;
                row.Cells[6].AddParagraph((((kwota * 100) / 123) * ilosc).ToString(dec_format));
                suma_netto += ((kwota * 100) / 123) * ilosc;
                suma_vat += (kwota * ilosc) - (((kwota * 100) / 123) * ilosc);
                suma_brutto += kwota * ilosc;
                row.Cells[6].Format.Alignment = ParagraphAlignment.Right;
                row.Cells[7].AddParagraph("23");
                row.Cells[8].AddParagraph(((kwota * ilosc) - (((kwota * 100) / 123) * ilosc)).ToString(dec_format));
                row.Cells[8].Format.Alignment = ParagraphAlignment.Right;
                row.Cells[9].AddParagraph((kwota * ilosc).ToString(dec_format));
                row.Cells[9].Format.Alignment = ParagraphAlignment.Right;
            }

            row = table.AddRow();
            row.Borders.Visible = false;
            row = table.AddRow();
            row.TopPadding = 4;
            row.BottomPadding = 4;
            row.Cells[0].MergeRight = 5;
            row.Cells[0].Borders.Visible = false;
            row.Cells[0].AddParagraph("Razem przed korektą  ");
            row.Cells[0].Format.Alignment = ParagraphAlignment.Right;
            ////
            row.Cells[6].AddParagraph(suma_netto.ToString(dec_format));
            row.Cells[6].Format.Alignment = ParagraphAlignment.Right;
            row.Cells[7].AddParagraph("X");
            row.Cells[7].Format.Alignment = ParagraphAlignment.Center;
            row.Cells[8].AddParagraph(suma_vat.ToString(dec_format));
            row.Cells[8].Format.Alignment = ParagraphAlignment.Right;
            row.Cells[9].AddParagraph(suma_brutto.ToString(dec_format));
            row.Cells[9].Format.Alignment = ParagraphAlignment.Right;
            //////////////////
            row = table.AddRow();
            row.TopPadding = 4;
            row.Style = "TNR7";
            row.Format.Alignment = ParagraphAlignment.Right;
            row.Cells[0].MergeRight = 5;
            row.Cells[0].Borders.Visible = false;
            row.Cells[0].AddParagraph("w tym  ");
            row.Cells[0].VerticalAlignment = VerticalAlignment.Top;
            //// 23
            row.Cells[6].AddParagraph(suma_netto.ToString(dec_format));            
            row.Cells[7].AddParagraph("23");
            row.Cells[7].Format.Alignment = ParagraphAlignment.Center;
            row.Cells[8].AddParagraph(suma_vat.ToString(dec_format));            
            row.Cells[9].AddParagraph(suma_brutto.ToString(dec_format));
            //// 7
            row.Cells[6].AddParagraph("0.00");
            row.Cells[7].AddParagraph("7");
            row.Cells[7].Format.Alignment = ParagraphAlignment.Center;
            row.Cells[8].AddParagraph("0.00");
            row.Cells[9].AddParagraph("0.00");
            //// 3
            row.Cells[6].AddParagraph("0.00");
            row.Cells[7].AddParagraph("3");
            row.Cells[7].Format.Alignment = ParagraphAlignment.Center;
            row.Cells[8].AddParagraph("0.00");
            row.Cells[9].AddParagraph("0.00");
            //// 0
            row.Cells[6].AddParagraph("0.00");
            row.Cells[7].AddParagraph("0");
            row.Cells[7].Format.Alignment = ParagraphAlignment.Center;
            row.Cells[8].AddParagraph("0.00");
            row.Cells[9].AddParagraph("0.00");
            //// zw
            row.Cells[6].AddParagraph("0.00");
            row.Cells[7].AddParagraph("zw");
            row.Cells[7].Format.Alignment = ParagraphAlignment.Center;
            row.Cells[8].AddParagraph("0.00");
            row.Cells[9].AddParagraph("0.00");

            Paragraph paragraph = section.AddParagraph();
            paragraph.AddText("Razem do zapłaty/do zwrotu*: " + suma_brutto.ToString("##,##0.00") + " zł");
            paragraph.Style = "TNR9";
            paragraph.Format.SpaceBefore = 5;

            paragraph = section.AddParagraph();
            paragraph.AddText("Słownie: " + Konwersja.Kwotana_na_slowa(suma_brutto));
            paragraph.Style = "TNR9";
            paragraph.Format.SpaceAfter = 45;



            paragraph = section.AddParagraph();
            paragraph.AddText(".................................................");            
            paragraph.Style = "Reference";
            paragraph.AddTab();
            paragraph.AddText(".................................................");


            paragraph = section.AddParagraph();
            paragraph.AddText("data i podpis odbiorcy faktury");
            paragraph.Format.SpaceBefore = 0;
            paragraph.Style = "Reference";
            paragraph.AddTab();
            paragraph.AddText("podpis wystawcy faktury");


            paragraph = section.AddParagraph();
            paragraph.AddText("*)  niepotrzebne skreślić");
            paragraph.Style = "TNR9";
            paragraph.Format.SpaceBefore = 8;
            paragraph.Format.SpaceAfter = 35;

        }
    }
}
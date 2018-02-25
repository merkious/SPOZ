using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.Rendering;
using PdfSharp.Pdf;
using System;
using System.Diagnostics;
using System.Windows.Forms;


namespace SPOZ.PDF
{
    class Druk_rap_realizacji
    {

        Document document;
        private Section section;
        private Table table;

        public Druk_rap_realizacji()
        {

            CreateDocument();

        }

        public void CreateDocument()
        {

            // Create a new MigraDoc document
            document = new Document();
            document.Info.Title = "Raport realizacji";

            DefineStyles();
            CreatePage();
            Wszystkie_zamowienia();
            Rozliczone_zamowienia();


            document.UseCmykColor = true;
            const bool unicode = true;
            const PdfFontEmbedding embedding = PdfFontEmbedding.Always;
            PdfDocumentRenderer pdfRenderer = new PdfDocumentRenderer(unicode, embedding)
            { Document = document };
            pdfRenderer.RenderDocument();
            //ścieżka dostępu 
            try
            {
                string filename = Sciezki.moje_dokumnety + @"\SPOZ\Raport realizacji.pdf";
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
            // Each MigraDoc document needs at least one section.
            section = this.document.AddSection();
            Paragraph paragraph = section.Footers.Primary.AddParagraph();


            paragraph = section.AddParagraph();
            paragraph.AddText("Raport z dnia: " + DateTime.Today.ToString("yyyy-MM-dd"));
            paragraph.Style = "TNR12";

            paragraph = section.AddParagraph();
            paragraph.AddText(Properties.Settings.Default.aktualne_miasto_PL);
            paragraph.Style = "TNR12";


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
            Column column = this.table.AddColumn("1.5cm");
            column.Format.Alignment = ParagraphAlignment.Center;
            column = this.table.AddColumn("6cm");
            column.Format.Alignment = ParagraphAlignment.Left;
            column = this.table.AddColumn("2cm");
            column.Format.Alignment = ParagraphAlignment.Center;
            column = this.table.AddColumn("1.7cm");
            column.Format.Alignment = ParagraphAlignment.Right;
            column = this.table.AddColumn("1.7cm");
            column.Format.Alignment = ParagraphAlignment.Right;
            column = this.table.AddColumn("1.7cm");
            column.Format.Alignment = ParagraphAlignment.Right;


            // Create the header of the table
            Row row = table.AddRow();
            row.HeadingFormat = true;
            row.Format.Alignment = ParagraphAlignment.Center;
            row.VerticalAlignment = VerticalAlignment.Top;
            row.Format.Font.Bold = true;
            row.Shading.Color = Colors.Aqua;
            row.TopPadding = 2;
            row.BottomPadding = 2;
            ////////////////////////////
            row.Cells[0].AddParagraph("Numer ZK");
            row.Cells[1].AddParagraph("Towar");
            row.Cells[2].AddParagraph("Data przyjęcia");
            row.Cells[3].AddParagraph("Wartość zamówienia");
            row.Cells[4].AddParagraph("Zadatek");
            row.Cells[5].AddParagraph("Pozostało do zapłaty");


            this.table.SetEdge(0, 0, 6, 1, Edge.Box, MigraDoc.DocumentObjectModel.BorderStyle.Single, 0.75, MigraDoc.DocumentObjectModel.Color.Empty);
            this.table.SetEdge(0, 0, 6, 1, Edge.Box, MigraDoc.DocumentObjectModel.BorderStyle.Single, 0.75);
        }


        private void Wszystkie_zamowienia()
        {
            decimal sum_zk, sum_zal, sum_pozostalo;
            sum_zk = sum_zal = sum_pozostalo = 0;

            String[,] tabela = Metody_bazy.Metoda_Rafal("`towar_na_stanie`=1 AND `rozliczony`=0");
            if (tabela.Length > 6)
            {
                Paragraph paragraph = section.AddParagraph();
                paragraph.AddText("Lista nierozliczonych zamówień dostarczonych do sklepu: ");
                paragraph.Style = "TNR12";

                Tworzenie_tabeli();
                Row row1;
                for (int i = 0; i < tabela.Length / 7; i++)
                {
                    row1 = this.table.AddRow();
                    row1.TopPadding = 3;
                    row1.BottomPadding = 3;
                    row1.Cells[0].AddParagraph(tabela[0, i]);
                    row1.Cells[1].AddParagraph(tabela[5, i]);
                    row1.Cells[2].AddParagraph(tabela[1, i]);
                    row1.Cells[3].AddParagraph(tabela[3, i]);
                    row1.Cells[4].AddParagraph(tabela[2, i]);
                    row1.Cells[5].AddParagraph(tabela[4, i]);
                    sum_zk += Convert.ToDecimal(tabela[3, i]);
                    sum_zal += Convert.ToDecimal(tabela[2, i]);
                    sum_pozostalo += Convert.ToDecimal(tabela[4, i]);
                }

                row1 = this.table.AddRow();
                row1.TopPadding = 9;
                row1.BottomPadding = 3;
                row1.Format.Font.Bold = true;
                row1.Cells[0].AddParagraph("Łącznie:");
                row1.Cells[0].MergeRight = 2;
                row1.Cells[0].Format.Alignment = ParagraphAlignment.Right;
                row1.Cells[0].Borders.Visible = false;

                row1.Cells[3].AddParagraph(sum_zk.ToString("##,##0.00"));
                row1.Cells[4].AddParagraph(sum_zal.ToString("##,##0.00"));
                row1.Cells[5].AddParagraph(sum_pozostalo.ToString("##,##0.00"));
            }
            else
            {
                Paragraph paragraph = section.AddParagraph();
                paragraph.AddText("Brak nierozliczonych zamówień dostarczonych do sklepu.");
                paragraph.Style = "TNR12B";
            }

        }

        private void Rozliczone_zamowienia()
        {
            // section = this.document.AddSection();
            Paragraph paragraph = section.Footers.Primary.AddParagraph();

            decimal sum_zk, sum_zal, sum_pozostalo;
            sum_zk = sum_zal = sum_pozostalo = 0;

            String[,] tabela = Metody_bazy.Metoda_Rafal("`towar_na_stanie`=0");
            if (tabela.Length > 6)
            {
                paragraph = section.AddParagraph();
                paragraph.AddText("Lista niezrealizowanych zamówień: ");
                paragraph.Style = "TNR12";

                Tworzenie_tabeli();
                Row row1;
                for (int i = 0; i < tabela.Length / 7; i++)

                {

                    row1 = this.table.AddRow();
                    row1.TopPadding = 3;
                    row1.BottomPadding = 3;
                    row1.Cells[0].AddParagraph(tabela[0, i]);
                    row1.Cells[1].AddParagraph(tabela[5, i]);
                    row1.Cells[2].AddParagraph(tabela[1, i]);
                    row1.Cells[3].AddParagraph(tabela[3, i]);
                    row1.Cells[4].AddParagraph(tabela[2, i]);
                    if (tabela[6, i] == "False")
                    {
                        row1.Cells[5].AddParagraph(tabela[4, i]);
                        sum_pozostalo += Convert.ToDecimal(tabela[4, i]);
                    }
                    else row1.Cells[5].AddParagraph("RATY");

                    sum_zk += Convert.ToDecimal(tabela[3, i]);
                    sum_zal += Convert.ToDecimal(tabela[2, i]);


                }

                row1 = this.table.AddRow();
                row1.TopPadding = 9;
                row1.BottomPadding = 3;
                row1.Format.Font.Bold = true;
                row1.Cells[0].AddParagraph("Łącznie:");
                row1.Cells[0].MergeRight = 2;
                row1.Cells[0].Format.Alignment = ParagraphAlignment.Right;
                row1.Cells[0].Borders.Visible = false;


                row1.Cells[3].AddParagraph(sum_zk.ToString("##,##0.00"));
                row1.Cells[4].AddParagraph(sum_zal.ToString("##,##0.00"));
                row1.Cells[5].AddParagraph(sum_pozostalo.ToString("##,##0.00"));
            }
            else
            {
                paragraph = section.AddParagraph();
                paragraph.AddText("Brak niezrealizowanych zamówień.");
                paragraph.Style = "TNR12B";

            }
        }
    }
}

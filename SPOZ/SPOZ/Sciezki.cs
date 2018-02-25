using System;

namespace SPOZ
{
    class Sciezki
    {
        public static string 
            sciezka_aplikacji = AppDomain.CurrentDomain.BaseDirectory,
            moje_dokumnety = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
            aktualizacje = moje_dokumnety + @"\SPOZ\Aktualizacja",
            zamowienia = moje_dokumnety + @"\SPOZ\Zamowienia",
            faktury = moje_dokumnety + @"\SPOZ\Faktury",
            raporty = moje_dokumnety + @"\SPOZ\Raporty",
            autostart = Environment.GetFolderPath(Environment.SpecialFolder.Startup) + @"\SPOZ.lnk",
            numer_tworzonej_faktury = null,
            drukowane_zk = null;       
    }
}
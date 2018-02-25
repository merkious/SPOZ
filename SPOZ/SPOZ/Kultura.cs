using System.Globalization;
using System.Threading;

namespace SPOZ
{
    class Kultura
    {
        public static void Kropka()
        {
            string mojaPolska = Thread.CurrentThread.CurrentCulture.Name;
            CultureInfo CI = new CultureInfo(mojaPolska);
            CI.NumberFormat.NumberDecimalSeparator = ".";
            Thread.CurrentThread.CurrentCulture = CI;
        }
        public static void Polska()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("pl-PL");
            Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture("pl-PL");
        }
    }
}
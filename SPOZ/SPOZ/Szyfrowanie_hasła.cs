using System.Security.Cryptography;
using System.Text;

namespace SPOZ
{
    class Szyfrowanie_hasła
    {
        public string Szyfrowaine_hasła(string haslo)
        {
            haslo = SHA256(haslo);
            haslo +="MT666P$";
            haslo = SHA256(haslo);
            return haslo;
        }
        string SHA256(string haslo)
        {
            UTF8Encoding enkoder = new UTF8Encoding();
            SHA256Managed sha256haszer = new SHA256Managed();
            byte[] tablica = sha256haszer.ComputeHash(enkoder.GetBytes(haslo));
            StringBuilder wyjsciowy = new StringBuilder("");
            for (int i = 0; i < tablica.Length; i++)
                wyjsciowy.Append(tablica[i].ToString("X2"));
            return wyjsciowy.ToString();
        }
    }
}
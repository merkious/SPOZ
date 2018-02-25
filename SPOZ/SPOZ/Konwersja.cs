using System;

namespace SPOZ
{
    class Konwersja
    {
        public static string Kwotana_na_slowa(Double kwota)
        {
            string[] kwota_t = Convert.ToDouble(kwota).ToString("0.00").Split('.');
            String slowna_kwota = kwota_t[1] + "//100 gr";
            char[] cyfry = kwota_t[0].ToCharArray();

            if (cyfry.Length == 1)
            {
                switch (cyfry[cyfry.Length - 1])
                {
                    case '0':
                        slowna_kwota = "zero zł " + slowna_kwota;
                        break;
                    case '1':
                        slowna_kwota = "jeden zł " + slowna_kwota;
                        break;
                    case '2':
                        slowna_kwota = "dwa zł " + slowna_kwota;
                        break;
                    case '3':
                        slowna_kwota = "trzy zł " + slowna_kwota;
                        break;
                    case '4':
                        slowna_kwota = "cztery zł " + slowna_kwota;
                        break;
                    case '5':
                        slowna_kwota = "pięć zł " + slowna_kwota;
                        break;
                    case '6':
                        slowna_kwota = "sześć zł " + slowna_kwota;
                        break;
                    case '7':
                        slowna_kwota = "siedem zł " + slowna_kwota;
                        break;
                    case '8':
                        slowna_kwota = "osiem zł " + slowna_kwota;
                        break;
                    case '9':
                        slowna_kwota = "dziewięć zł " + slowna_kwota;
                        break;
                }

            }

            if (cyfry.Length >= 2)
            {
                switch (cyfry[cyfry.Length - 2])
                {
                    case '0':
                        slowna_kwota = Jednosci(cyfry[cyfry.Length-1]) +"zł "+ slowna_kwota;
                         
                        break;
                    case '1':
                        switch (cyfry[cyfry.Length - 1])
                        {
                            case '0':
                                slowna_kwota = "dziesięć zł " + slowna_kwota;
                                break;
                            case '1':
                                slowna_kwota = "jedenaście zł " + slowna_kwota;
                                break;
                            case '2':
                                slowna_kwota = "dwanaście zł " + slowna_kwota;
                                break;
                            case '3':
                                slowna_kwota = "trzynaście zł " + slowna_kwota;
                                break;
                            case '4':
                                slowna_kwota = "czternaście zł " + slowna_kwota;
                                break;
                            case '5':
                                slowna_kwota = "piętnaście zł " + slowna_kwota;
                                break;
                            case '6':
                                slowna_kwota = "szesnaście zł " + slowna_kwota;
                                break;
                            case '7':
                                slowna_kwota = "siedemnaście zł " + slowna_kwota;
                                break;
                            case '8':
                                slowna_kwota = "osiemnaście zł " + slowna_kwota;
                                break;
                            case '9':
                                slowna_kwota = "dziewiętnaście zł " + slowna_kwota;
                                break;
                        }
                        break;
                    case '2':
                        slowna_kwota = "dwadzieścia " + Jednosci(cyfry[cyfry.Length - 1]) + "zł " + slowna_kwota;
                        break;
                    case '3':
                        slowna_kwota = "trzydzieści " +Jednosci(cyfry[cyfry.Length - 1]) + "zł " + slowna_kwota;
                        break;
                    case '4':
                        slowna_kwota = "czterdzieści "+ Jednosci(cyfry[cyfry.Length - 1]) + "zł " + slowna_kwota;
                        break;
                    case '5':
                        slowna_kwota = "pięćdziesiąt " + Jednosci(cyfry[cyfry.Length - 1]) + "zł " + slowna_kwota;
                        break;
                    case '6':
                        slowna_kwota = "sześćdziesiąt " + Jednosci(cyfry[cyfry.Length - 1]) + "zł " + slowna_kwota;
                        break;
                    case '7':
                        slowna_kwota = "siedemdziesiąt " + Jednosci(cyfry[cyfry.Length - 1]) + "zł " + slowna_kwota;
                        break;
                    case '8':
                        slowna_kwota = "osiemdziesiąt " + Jednosci(cyfry[cyfry.Length - 1]) + "zł " + slowna_kwota;
                        break;
                    case '9':
                        slowna_kwota = "dziewięćdziesiąt "+ Jednosci(cyfry[cyfry.Length - 1]) + "zł " + slowna_kwota;
                        break;
                }

            }

            if (cyfry.Length >= 3)
            {
                switch (cyfry[cyfry.Length - 3])
                {
                    case '0':
                        
                        break;
                    case '1':
                        slowna_kwota = "sto " + slowna_kwota;
                        break;
                    case '2':
                        slowna_kwota = "dwieście " + slowna_kwota;
                        break;
                    case '3':
                        slowna_kwota = "trzysta " + slowna_kwota;
                        break;
                    case '4':
                        slowna_kwota = "czterysta " + slowna_kwota;
                        break;
                    case '5':
                        slowna_kwota = "pięćset " + slowna_kwota;
                        break;
                    case '6':
                        slowna_kwota = "sześćset " + slowna_kwota;
                        break;
                    case '7':
                        slowna_kwota = "siedemset " + slowna_kwota;
                        break;
                    case '8':
                        slowna_kwota = "osiemset " + slowna_kwota;
                        break;
                    case '9':
                        slowna_kwota = "dziewięćset " + slowna_kwota;
                        break;
                }

            }

            if (cyfry.Length == 4)
            {
                switch (cyfry[cyfry.Length - 4])
                {
                    case '0':
                        
                        break;
                    case '1':
                        slowna_kwota = "jeden tysiąc " + slowna_kwota;
                        break;
                    case '2':
                        slowna_kwota = "dwa tysiące " + slowna_kwota;
                        break;
                    case '3':
                        slowna_kwota = "trzy tysiące " + slowna_kwota;
                        break;
                    case '4':
                        slowna_kwota = "cztery tysiące " + slowna_kwota;
                        break;
                    case '5':
                        slowna_kwota = "pięć tysięcy " + slowna_kwota;
                        break;
                    case '6':
                        slowna_kwota = "sześć tysięcy " + slowna_kwota;
                        break;
                    case '7':
                        slowna_kwota = "siedem tysięcy " + slowna_kwota;
                        break;
                    case '8':
                        slowna_kwota = "osiem tysięcy " + slowna_kwota;
                        break;
                    case '9':
                        slowna_kwota = "dziewięć tysięcy " + slowna_kwota;
                        break;
                }

            }


            if (cyfry.Length >= 5)
            {
                switch (cyfry[cyfry.Length - 5])
                {
                    case '0':
                        //slowna_kwota = jednosci(cyfry[cyfry.Length - 1]) + "zł " + slowna_kwota;

                        break;
                    case '1':
                        switch (cyfry[cyfry.Length - 4])
                        {
                            case '0':
                                slowna_kwota = "dziesięć tysięcy " + slowna_kwota;
                                break;
                            case '1':
                                slowna_kwota = "jedenaście tysięcy " + slowna_kwota;
                                break;
                            case '2':
                                slowna_kwota = "dwanaście tysięcy " + slowna_kwota;
                                break;
                            case '3':
                                slowna_kwota = "trzynaście tysięcy " + slowna_kwota;
                                break;
                            case '4':
                                slowna_kwota = "czternaście tysięcy " + slowna_kwota;
                                break;
                            case '5':
                                slowna_kwota = "piętnaście tysięcy " + slowna_kwota;
                                break;
                            case '6':
                                slowna_kwota = "szesnaście tysięcy " + slowna_kwota;
                                break;
                            case '7':
                                slowna_kwota = "siedemnaście tysięcy " + slowna_kwota;
                                break;
                            case '8':
                                slowna_kwota = "osiemnaście tysięcy " + slowna_kwota;
                                break;
                            case '9':
                                slowna_kwota = "dziewiętnaście tysięcy " + slowna_kwota;
                                break;
                        }
                        break;
                    case '2':
                        slowna_kwota = "dwadzieścia " + Jednosci(cyfry[cyfry.Length - 1]) + "tysięcy " + slowna_kwota;
                        break;
                    case '3':
                        slowna_kwota = "trzydzieści " + Jednosci(cyfry[cyfry.Length - 1]) + "tysięcy " + slowna_kwota;
                        break;
                    case '4':
                        slowna_kwota = "czterdzieści " + Jednosci(cyfry[cyfry.Length - 1]) + "tysięcy " + slowna_kwota;
                        break;
                    case '5':
                        slowna_kwota = "pięćdziesiąt " + Jednosci(cyfry[cyfry.Length - 1]) + "tysięcy " + slowna_kwota;
                        break;
                    case '6':
                        slowna_kwota = "sześćdziesiąt " + Jednosci(cyfry[cyfry.Length - 1]) + "tysięcy " + slowna_kwota;
                        break;
                    case '7':
                        slowna_kwota = "siedemdziesiąt " + Jednosci(cyfry[cyfry.Length - 1]) + "tysięcy " + slowna_kwota;
                        break;
                    case '8':
                        slowna_kwota = "osiemdziesiąt " + Jednosci(cyfry[cyfry.Length - 1]) + "tysięcy " + slowna_kwota;
                        break;
                    case '9':
                        slowna_kwota = "dziewięćdziesiąt " + Jednosci(cyfry[cyfry.Length - 1]) + "tysięcy " + slowna_kwota;
                        break;
                }

            }


            
            return slowna_kwota;
        }

        private static string Jednosci(char znak)
        {
            string slowna_kwota = null;
            
                switch (znak)
                {
                    case '0':
                    
                        break;
                    case '1':
                    slowna_kwota = "jeden ";
                        break;
                    case '2':
                    slowna_kwota = "dwa ";
                        break;
                    case '3':
                    slowna_kwota = "trzy ";
                        break;
                    case '4':
                    slowna_kwota = "cztery ";
                        break;
                    case '5':
                    slowna_kwota = "pięć ";
                        break;
                    case '6':
                    slowna_kwota = "sześć ";
                        break;
                    case '7':
                    slowna_kwota = "siedem ";
                        break;
                    case '8':
                    slowna_kwota = "osiem ";
                        break;
                    case '9':
                    slowna_kwota = "dziewięć ";
                        break;
                }
            return slowna_kwota;
            
        }

        private static string Jednosci_t(char znak)
        {
            string slowna_kwota = null;

            switch (znak)
            {
                case '0':
                    
                    break;
                case '1':
                    slowna_kwota = "jeden tsiąc ";
                    break;
                case '2':
                    slowna_kwota = "dwa tysiące ";
                    break;
                case '3':
                    slowna_kwota = "trzy tysiące";
                    break;
                case '4':
                    slowna_kwota = "cztery tysiące";
                    break;
                case '5':
                    slowna_kwota = "pięć tysięcy ";
                    break;
                case '6':
                    slowna_kwota = "sześć tysięcy ";
                    break;
                case '7':
                    slowna_kwota = "siedem tysięcy ";
                    break;
                case '8':
                    slowna_kwota = "osiem tysięcy ";
                    break;
                case '9':
                    slowna_kwota = "dziewięć tysięcy ";
                    break;
            }
            return slowna_kwota;

        }
    }
}
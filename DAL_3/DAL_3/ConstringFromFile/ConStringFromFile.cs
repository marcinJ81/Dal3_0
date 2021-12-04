using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_3.ConstringFromFile
{
   public class ConStringFromFile
    {
        /// <summary>
        /// method created in 2015, from project Bike Marthon
        /// get connection string from text file
        /// </summary>
        /// <param name="plik"></param>
        public void getFileExtendet(string plik)
        {
            try
            {
                //wlozenie pliku do strumienia
                Stream inputStream = File.OpenRead(plik);
                byte[] bufor = new byte[400];
                int bytesRead;
                byte[] tab = new byte[400];
                //byte[] tab = new byte[1]; //!!!!!!!!!!!!

                while ((bytesRead = inputStream.Read(bufor, 0, 400)) > 0)
                {
                    tab = bufor;
                }

                //konwersja byte[] to string
                System.Text.Encoding enc = System.Text.Encoding.ASCII;
                string tekst = enc.GetString(tab);
                int j = 0;
                byte[] wynik = new byte[50];
                //wypełnienie tablicy  typu byte spacjami ASCII kod 32
                //dzieki temu trima nie trzeba używać
                int tmp = 0;
                for (int id = 0; id < 50; id++)
                {
                    wynik[id] = 32;
                }
                //z -> zmienna pmocnicza indeks tab
                int z = 0;
                // k -> wartość pobrana z tablicy bajtów
                byte k = 0;
                // g -> licznik pomocniczy d o pętli głównej
                int g = 0;
                //licznik wystapień wartości 34 czli zn ,",
                int licznik = 0;
                //petla pedzi po tablicy
                while (j < tab.Length)
                {
                    //wykrycie znaku o kodzie 34
                    if (tab[j] == 34)
                    {
                        //wpisanie do zmiennej pom indexu j
                        g = j;
                        //zwielszenie licznika wystapien 34
                        licznik++;
                        // jezeli wystapil poraz czwarty to break
                        if (licznik == 10)
                            break;
                        //w przeciwnym razie petla 
                        while (k != 34)
                        {
                            k = tab[++j];
                            //jezeli jest rozne od 34 to wpisuj wartosci do tablicy
                            if (k != 34)
                                wynik[z] = k;
                            z++;
                            //jezeli 34 to
                            if (k == 34)
                            {
                                //licznik = 3 wpisz wynik do ilosci_dni
                                if (licznik == 3)
                                {
                                    //nazwa bazy danych
                                    baza = enc.GetString(wynik);
                                    //zerowanie tempa
                                    tmp = 0;

                                    // = Convert.ToInt32(enc.GetString(wynik));
                                }
                                //licznik = 1 wpisz wynik do katalogu
                                if (licznik == 1)
                                {
                                    //walidacja sciezki do katalogu
                                    zrodlo = enc.GetString(wynik);

                                }
                                //wypelnienie tablicy wynik spacjami
                                if (licznik == 2)
                                {
                                    while (tmp != wynik.Length)
                                        wynik[tmp++] = 32;
                                }
                                if (licznik == 4)
                                {
                                    while (tmp != wynik.Length)
                                        wynik[tmp++] = 32;
                                }
                                if (licznik == 5)
                                {
                                    //persist security info, rodzaj logownia
                                    PersistSecInfo = enc.GetString(wynik);
                                    tmp = 0;
                                }
                                if (licznik == 6)
                                {
                                    while (tmp != wynik.Length)
                                        wynik[tmp++] = 32;
                                }
                                if (licznik == 7)
                                {
                                    //nazwa uzytkownika
                                    userId = enc.GetString(wynik);
                                    tmp = 0;
                                }
                                if (licznik == 8)
                                {
                                    while (tmp != wynik.Length)
                                        wynik[tmp++] = 32;
                                }
                                if (licznik == 9)
                                {
                                    //haslo
                                    pass = enc.GetString(wynik);
                                    tmp = 0;
                                }
                                if (licznik == 10)
                                {
                                    while (tmp != wynik.Length)
                                        wynik[tmp++] = 32;
                                }

                            }
                        }

                        j = g;
                        z = 0;
                        k = 0;
                    }

                    j++;
                }
            }
            catch (Exception ex)
            {
                if (ex != null)
                    pokazBladPliku(ex);
            }
            //konwersja string to byte[]
            //System.Text.Encoding enc2 = System.Text.Encoding.ASCII;
            //tab = enc2.GetBytes(tekst);

            //char tab[i++] = Convert.ToChar(bufor[i]);
        }
    }
}

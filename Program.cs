using System.Collections;

namespace BiletSatis
{
    internal class Program
    {
        static string[] seanslar = 
        {
           "1,1,100,Spider-man",
           "2,1,100,Harry Potter",
           "3,2,50,Yüzüklerin Efendisi",
           "4,2,50,Spider-man",
           "5,3,250,Yüzüklerin Efendisi",
           "6,3,250,Harry Potter",
        }; //"seans no,salon no,kapasite,film" //"1,25,120,Spider-man"
        static ArrayList biletler = new ArrayList(); //"seans no,adet,fiyat" "1,2,250"

        static void Main(string[] args)
        {
            /* 1) Analiz
             * 2) Tasarım
             * 3) Gerçekleşim
             * 4) Test
             * 5) Bakım
             * */

            //seans kontrol(seans no, bilet adedi)
            //biletsat

            string secenek;
            while(true)
            {
                Console.WriteLine("Menü");
                Console.WriteLine("-------------------------------");
                Console.WriteLine("1) Seans görüntüle");
                Console.WriteLine("2) Kalan yer görüntüle");
                Console.WriteLine("3) Bilet sat");
                Console.WriteLine("Diğer: Çıkış");
                Console.Write("Seçiminiz: ");
                secenek = Console.ReadLine();

                if (secenek == "1") //seans görüntülenme işlemi
                {

                }
                else if (secenek == "2") //kalan yer görüntüleme
                {

                }
                else if (secenek == "3") //bilet satış
                {

                }
                else
                    break;
            }
        }
    }
}
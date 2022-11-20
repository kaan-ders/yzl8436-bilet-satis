using System;
using System.Collections;

namespace BiletSatis
{
    internal class Program
    {
        //"seans no,salon no,kapasite,film" //"1,25,120,Spider-man"
        static string[] seanslar; /*= 
        {
           "1,1,100,Spider-man",
           "2,1,100,Harry Potter",
           "3,2,50,Yüzüklerin Efendisi",
           "4,2,50,Spider-man",
           "5,3,250,Yüzüklerin Efendisi",
           "6,3,250,Harry Potter",
        };*/

        static ArrayList biletler = new ArrayList(); //"seans no,adet,fiyat" "1,2,250"

        static void Main(string[] args)
        {
            /* 1) Analiz
             * 2) Tasarım
             * 3) Gerçekleşim
             * 4) Test
             * 5) Bakım
             * */

            //seansları doldur

            SeanslariDoldur();
            BiletleriDoldur();

            string secenek;
            while(true)
            {
                Console.WriteLine("Menü");
                Console.WriteLine("-------------------------------");
                Console.WriteLine("1) Seans görüntüle");
                Console.WriteLine("2) Kalan yer görüntüle");
                Console.WriteLine("3) Satılan biletleri görüntüle");
                Console.WriteLine("4) Bilet sat");
                Console.WriteLine("Diğer: Çıkış");
                Console.Write("Seçiminiz: ");
                secenek = Console.ReadLine();

                Console.WriteLine("-------------------------------");
                Console.WriteLine("   ");

                try
                {
                    if (secenek == "1") //seans görüntülenme işlemi
                    {
                        foreach (var seans in seanslar)
                        {
                            string[] seansBilgisiArray = seans.Split(",");
                            Console.WriteLine("Seans no: " + seansBilgisiArray[0] + ", Salon no: " + seansBilgisiArray[1] + ", Kapasite: " + seansBilgisiArray[2] + ", Film adı: " + seansBilgisiArray[3]);
                        }
                    }
                    else if (secenek == "2") //kalan yer görüntüleme
                    {
                        foreach (var seans in seanslar)
                        {
                            string[] seansBilgisiArray = seans.Split(",");
                            int kalanKoltukSayisi = KalanKoltukSayisiHesapla(seansBilgisiArray[0]);
                            Console.WriteLine("Seans no: " + seansBilgisiArray[0] + ", Film adı: " + seansBilgisiArray[3] + ", Kalan koltuk: " + kalanKoltukSayisi);
                        }
                    }
                    else if(secenek == "3") //satılan biletleri görüntüle
                    {
                        foreach (string bilet in biletler)
                        {
                            var biletBilgisiArray = bilet.Split(",");
                            Console.WriteLine("Seans no: " + biletBilgisiArray[0] +", Koltuk adedi: "+ biletBilgisiArray[1] + ", Satış fiyatı: "+ biletBilgisiArray[2] + "TL");
                        }
                    }
                    else if (secenek == "4") //bilet satış
                    {
                        string seansNo;
                        int adet = 0;

                        Console.Write("Seans no giriniz: ");
                        seansNo = Console.ReadLine();

                        //seans var mı?

                        Console.Write("Koltuk adedi giriniz: ");
                        adet = int.Parse(Console.ReadLine());

                        int kalanKoltukSayisi = KalanKoltukSayisiHesapla(seansNo);

                        //koltuk var mı?
                        if (kalanKoltukSayisi >= adet) //evet
                        {
                            int fiyat = adet * 50;
                            biletler.Add(seansNo + "," + adet + "," + fiyat);

                            BiletleriKaydet();
                            string biletNo = DateTime.Now.ToString("ddMMyyyyhhmm") + "-" + biletler.Count;
                            Console.WriteLine("Bilet satıldı. Bilet No: " + biletNo);
                        }
                        else //hayır
                            Console.WriteLine("Seansta yeterli yer yok. Kalan koltuk: " + kalanKoltukSayisi);
                    }
                    else
                        break;
                }
                catch
                {
                    Console.WriteLine("Hata oluştu");
                }

                Console.WriteLine("   ");
                Console.WriteLine("Devam etmek için bir tuşa basın");
                Console.ReadLine();
                Console.Clear();
            }
        }

        static int KalanKoltukSayisiHesapla(string seansNo)
        {
            //seansın toplam kapasitesini bul
            int kapasite = 0;
            foreach(var seans in seanslar)
            {
                var seansBilgisiArray = seans.Split(",");

                if (seansBilgisiArray[0] == seansNo)
                {
                    kapasite = Convert.ToInt32(seansBilgisiArray[2]);
                    break;
                }
            }

            //ilgili seansa ait toplam satılmış koltuk adedini bul
            int koltukSatisAdedi = 0;
            foreach (string bilet in biletler)
            {
                var biletBilgisiArray = bilet.Split(",");

                if (biletBilgisiArray[0] == seansNo)
                    koltukSatisAdedi += Convert.ToInt32(biletBilgisiArray[1]);
            }

            return kapasite - koltukSatisAdedi;
        }

        static void SeanslariDoldur()
        {
            string dosyaIcerigi = File.ReadAllText(@"C:\biletler\seanslar.txt");
            seanslar = dosyaIcerigi.Split('|');
        }

        static void BiletleriDoldur()
        {
            string dosyaIcerigi = File.ReadAllText(@"C:\biletler\biletler.txt");
            var biletlerArray = dosyaIcerigi.Split('|');

            if (biletlerArray[0] != "")
            {
                foreach (var item in biletlerArray)
                {
                    biletler.Add(item);
                }
            }
        }

        static void BiletleriKaydet()
        {
            string dosyaIcerigi = "";
            foreach (string bilet in biletler)
                dosyaIcerigi += bilet + "|";

            dosyaIcerigi = dosyaIcerigi.TrimEnd('|');
            File.WriteAllText(@"C:\biletler\biletler.txt", dosyaIcerigi);
        }
    }
}
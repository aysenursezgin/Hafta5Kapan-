using System;
using System.Collections.Generic;

class Araba
{
    public DateTime UretimTarihi { get; set; }
    public string SeriNumarasi { get; set; }
    public string Marka { get; set; }
    public string Model { get; set; }
    public string Renk { get; set; }
    public int KapiSayisi { get; set; }
}

class Program
{
    static void Main()
    {
        List<Araba> arabalar = new List<Araba>();
        bool devamEt = true;

        while (devamEt)
        {
            // 1. Kullanıcıdan araba üretmek isteyip istemediği soruluyor
            Console.WriteLine("Araba üretmek istiyor musunuz? (Evet için 'e', Hayır için 'h' tuşlayınız)");
            string cevap = Console.ReadLine().ToLower(); // Küçük harf duyarlılığını ortadan kaldırma

            if (cevap == "h")
            {
                // 2. Kullanıcı 'h' derse program sonlanacak
                devamEt = false;
                break;
            }
            else if (cevap != "e")
            {
                // Geçersiz cevap durumunda tekrar sorulacak
                Console.WriteLine("Geçersiz cevap! Lütfen 'e' (Evet) veya 'h' (Hayır) tuşlayınız.");
                continue;
            }

            // 3. Evet cevabı alındığında araba üretilecek
            Araba yeniAraba = new Araba();
            yeniAraba.UretimTarihi = DateTime.Now; // Üretim tarihi o anki tarih olacak

            // 4. Kullanıcıdan araba özelliklerini alıyoruz
            Console.Write("Seri numarası giriniz: ");
            yeniAraba.SeriNumarasi = Console.ReadLine();

            Console.Write("Marka giriniz: ");
            yeniAraba.Marka = Console.ReadLine();

            Console.Write("Model giriniz: ");
            yeniAraba.Model = Console.ReadLine();

            Console.Write("Renk giriniz: ");
            yeniAraba.Renk = Console.ReadLine();

            // 5. Kapı sayısı için geçerli bir sayı girmesini sağlıyoruz
            int kapiSayisi;
            while (true)
            {
                Console.Write("Kapı sayısını giriniz: ");
                string kapiSayisiStr = Console.ReadLine();

                // Sayıya dönüştürme işlemi yapılır
                if (int.TryParse(kapiSayisiStr, out kapiSayisi))
                {
                    yeniAraba.KapiSayisi = kapiSayisi;
                    break; // Geçerli bir sayı girildiği zaman döngüden çık
                }
                else
                {
                    // Geçersiz giriş yapılırsa uyarı mesajı
                    Console.WriteLine("Geçersiz kapı sayısı! Lütfen geçerli bir sayı giriniz.");
                }
            }

            // 6. Oluşturulan arabayı listeye ekliyoruz
            arabalar.Add(yeniAraba);

            // 7. Kullanıcıya başka araba üretmek isteyip istemediği soruluyor
            Console.WriteLine("Başka bir araba üretmek ister misiniz? (Evet için 'e', Hayır için 'h' tuşlayınız)");
            string devamCevap = Console.ReadLine().ToLower();
            if (devamCevap == "h")
            {
                devamEt = false; // 'h' yanıtı verildiyse program sonlanacak
            }
        }

        // 8. Program sonunda, arabaların seri numaralarını ve markalarını yazdırıyoruz
        Console.WriteLine("\nÜretilen Arabalar:");
        foreach (var araba in arabalar)
        {
            Console.WriteLine($"Seri Numarası: {araba.SeriNumarasi}, Marka: {araba.Marka}");
        }

        Console.WriteLine("Program sonlandırılıyor...");
    }
}

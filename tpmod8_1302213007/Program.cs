using System;
using System.IO;
using Newtonsoft.Json;

class Program
{
    static void Main()
    {
        string json = "{}";
        try
        {
            json = File.ReadAllText("D:\\Dokumen\\Kuliah\\Semester 4\\Konstruksi Perangkat Lunak\\tpmod8_1302213007\\tpmod8_1302213007\\covid_config.json");
        } catch (FileNotFoundException)
        {
            Console.WriteLine("File konfigurasi tidak ditemukan, menggunakan nilai default");
        }
        CovidConfig config = JsonConvert.DeserializeObject<CovidConfig>(json);
        config.UbahSatuan();

        Console.Write($"Berapa suhu badan anda saat ini? Dalam nilai {config.SatuanSuhu}: ");
        double suhu;
        while (!Double.TryParse(Console.ReadLine(), out suhu))
        {
            Console.Write("Masukkan tidak valid, ulangi : ");
        }

        if (config.SatuanSuhu == "fahrenheit")
        {
            suhu = (suhu = 32) * 5 / 9;
        }

        Console.Write("Berapa hari yang lalu (perkiran) anda terakhir memiliki gejala demam? ");
        int hari;
        while (!Int32.TryParse(Console.ReadLine(), out hari))
        {
            Console.Write("Masukkan tidak valid, ulangi : ");
        }

        if (suhu >= 36.5 && suhu <= 37.5 && hari < config.BatasHariDemam)
        {
            Console.WriteLine(config.PesanDiterima);
        } else
        {
            Console.WriteLine(config.PesanDitolak);
        }

        Console.WriteLine($"Satuan suhu : {config.SatuanSuhu}");
        Console.WriteLine($"Batas hari demam : {config.BatasHariDemam}");
    }
}
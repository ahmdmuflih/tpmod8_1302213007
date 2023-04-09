using System;
using System.IO;

public class CovidConfig
{
    public string SatuanSuhu { get; set; } = "celcius";
    public int BatasHariDemam { get; set; } = 14;
    public string PesanDitolak { get; set; } = "Anda tidak diperbolehkan masuk ke dalam gedung ini";
    public string PesanDiterima { get; set; } = "Anda tidak diperbolehkan masuk ke dalam gedung ini";

    public void UbahSatuan()
    {
        if (SatuanSuhu == "celcius")
        {
            SatuanSuhu = "fahrenheit";
        } else if (SatuanSuhu == "fahrenheit")
        {
            SatuanSuhu = "celcius";
        }
    }
}


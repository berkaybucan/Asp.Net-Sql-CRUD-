using System;
using System.Collections.Generic;

namespace SirketProje.Models;

public partial class Personel
{
    public string Tcno { get; set; } = null!;

    public string? PersonelAd { get; set; }

    public string? PersonelSoyad { get; set; }

    public DateTime? PersonelDogumTarihi { get; set; }

    public string? PersonelCinsiyet { get; set; }

    public string? PersonelMaas { get; set; }

    public int? PersonelDepartmanId { get; set; }
    public string? PersonelAdres { get; set; }
}

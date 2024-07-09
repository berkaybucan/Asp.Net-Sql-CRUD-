using System;
using System.Collections.Generic;

namespace SirketProje.Models;

public partial class Yonetir
{
    public int PersonelYonetirId { get; set; }

    public string? Tcno { get; set; }

    public int? DepartmanNo { get; set; }

    public DateTime? YoneticiBaslangicTarihi { get; set; }
}

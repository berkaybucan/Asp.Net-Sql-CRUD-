using System;
using System.Collections.Generic;

namespace SirketProje.Models;

public partial class Istihdam
{
    public int IstihdamNo { get; set; }

    public string? Tcno { get; set; }

    public int? ProjeNo { get; set; }

    public int? CalismaSaati { get; set; }
}

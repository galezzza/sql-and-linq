using System;
using System.Collections.Generic;

namespace EfLinqConsole.Models;

public partial class pc
{
    public int? model { get; set; }

    public decimal? szybkosc { get; set; }

    public int? ram { get; set; }

    public int? dysk { get; set; }

    public int? cena { get; set; }
}

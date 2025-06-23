using System;
using System.Collections.Generic;

namespace EfLinqConsole.Models;

public partial class drukarka
{
    public int? model { get; set; }

    public bool? kolor { get; set; }

    public string? typ { get; set; }

    public int? cena { get; set; }
}

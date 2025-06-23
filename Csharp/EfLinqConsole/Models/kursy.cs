using System;
using System.Collections.Generic;

namespace EfLinqConsole.Models;

public partial class kursy
{
    public int kod { get; set; }

    public string? nazwa { get; set; }

    public int? liczba_dni { get; set; }
}

using System;
using System.Collections.Generic;

namespace EfLinqConsole.Models;

public partial class stanowiska
{
    public string nazwa { get; set; } = null!;

    public decimal? placa_min { get; set; }

    public decimal? placa_max { get; set; }

    public virtual ICollection<pracownicy> pracownicies { get; set; } = new List<pracownicy>();
}

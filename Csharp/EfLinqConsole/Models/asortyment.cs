using System;
using System.Collections.Generic;

namespace EfLinqConsole.Models;

public partial class asortyment
{
    public string id_asortymentu { get; set; } = null!;

    public string? nazwa_asortymentu { get; set; }

    public int? cena_jenostkowa { get; set; }

    public virtual ICollection<transakcje> transakcjes { get; set; } = new List<transakcje>();
}

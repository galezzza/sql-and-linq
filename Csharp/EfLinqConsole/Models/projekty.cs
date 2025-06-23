using System;
using System.Collections.Generic;

namespace EfLinqConsole.Models;

public partial class projekty
{
    public int id { get; set; }

    public string nazwa { get; set; } = null!;

    public DateTime datarozp { get; set; }

    public DateTime datazakonczplan { get; set; }

    public DateTime? datazakonczfakt { get; set; }

    public int? kierownik { get; set; }

    public decimal? stawka { get; set; }

    public virtual pracownicy? kierownikNavigation { get; set; }

    public virtual ICollection<realizacje> realizacjes { get; set; } = new List<realizacje>();
}

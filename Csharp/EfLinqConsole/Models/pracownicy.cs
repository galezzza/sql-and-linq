using System;
using System.Collections.Generic;

namespace EfLinqConsole.Models;

public partial class pracownicy
{
    public int id { get; set; }

    public string nazwisko { get; set; } = null!;

    public int? szef { get; set; }

    public decimal? placa { get; set; }

    public decimal? dod_funkc { get; set; }

    public string? stanowisko { get; set; }

    public DateTime? zatrudniony { get; set; }

    public virtual ICollection<pracownicy> InverseszefNavigation { get; set; } = new List<pracownicy>();

    public virtual ICollection<projekty> projekties { get; set; } = new List<projekty>();

    public virtual ICollection<realizacje> realizacjes { get; set; } = new List<realizacje>();

    public virtual stanowiska? stanowiskoNavigation { get; set; }

    public virtual pracownicy? szefNavigation { get; set; }
}

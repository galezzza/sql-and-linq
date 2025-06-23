using System;
using System.Collections.Generic;

namespace EfLinqConsole.Models;

public partial class klienci_idx
{
    public string? id_klienta { get; set; }

    public string? imie { get; set; }

    public string? nazwisko { get; set; }

    public int? prefix_nip { get; set; }

    public string? nip { get; set; }

    public string? wojewodztwo { get; set; }

    public string? kod { get; set; }

    public string? miejscowosc { get; set; }

    public string? ulica { get; set; }

    public int? nr_domu { get; set; }
}

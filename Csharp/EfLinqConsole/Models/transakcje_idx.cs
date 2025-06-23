using System;
using System.Collections.Generic;

namespace EfLinqConsole.Models;

public partial class transakcje_idx
{
    public string? id_transakcji { get; set; }

    public string? klient { get; set; }

    public string? asortyment { get; set; }

    public decimal? ilosc { get; set; }

    public DateOnly? data_transakcji { get; set; }
}

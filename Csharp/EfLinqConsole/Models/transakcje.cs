using System;
using System.Collections.Generic;

namespace EfLinqConsole.Models;

public partial class transakcje
{
    public string id_transakcji { get; set; } = null!;

    public string? klient { get; set; }

    public string? asortyment { get; set; }

    public decimal? ilosc { get; set; }

    public DateOnly? data_transakcji { get; set; }

    public virtual asortyment? asortymentNavigation { get; set; }

    public virtual klienci? klientNavigation { get; set; }
}

using System;
using System.Collections.Generic;

namespace EfLinqConsole.Models;

public partial class uczestnicyaktualnie
{
    public string pesel { get; set; } = null!;

    public string nazwisko { get; set; } = null!;

    public string? miasto { get; set; }

    public string? email { get; set; }
}

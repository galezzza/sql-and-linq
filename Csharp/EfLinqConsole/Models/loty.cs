using System;
using System.Collections.Generic;

namespace EfLinqConsole.Models;

public partial class loty
{
    public string? linie { get; set; }

    public string? zkad { get; set; }

    public string? dokad { get; set; }

    public TimeOnly? odloty { get; set; }

    public TimeOnly? przyloty { get; set; }
}

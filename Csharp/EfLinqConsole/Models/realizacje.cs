using System;
using System.Collections.Generic;

namespace EfLinqConsole.Models;

public partial class realizacje
{
    public int idproj { get; set; }

    public int idprac { get; set; }

    public float? godzin { get; set; }

    public virtual pracownicy idpracNavigation { get; set; } = null!;

    public virtual projekty idprojNavigation { get; set; } = null!;
}

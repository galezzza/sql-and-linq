using System;
using System.Collections.Generic;

namespace EfLinqConsole.Models;

public partial class psiaki_c_zrecznosci
{
    public int pies_kod { get; set; }

    public int sztuczki_kod { get; set; }

    public int sztuczki_zrecznosc { get; set; }

    public virtual psiaki_c_psy pies_kodNavigation { get; set; } = null!;

    public virtual psiaki_c_sztuczki sztuczki_kodNavigation { get; set; } = null!;
}

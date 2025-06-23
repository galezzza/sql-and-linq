using System;
using System.Collections.Generic;

namespace EfLinqConsole.Models;

public partial class psiaki_c_psy
{
    public int pies_kod { get; set; }

    public string? pies_imie { get; set; }

    public string? buda { get; set; }

    public virtual ICollection<psiaki_c_zrecznosci> psiaki_c_zrecznoscis { get; set; } = new List<psiaki_c_zrecznosci>();
}

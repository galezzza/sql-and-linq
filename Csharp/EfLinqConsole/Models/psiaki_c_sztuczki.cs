using System;
using System.Collections.Generic;

namespace EfLinqConsole.Models;

public partial class psiaki_c_sztuczki
{
    public int sztuczki_kod { get; set; }

    public string? sztuczki_nazwa { get; set; }

    public virtual ICollection<psiaki_c_zrecznosci> psiaki_c_zrecznoscis { get; set; } = new List<psiaki_c_zrecznosci>();
}

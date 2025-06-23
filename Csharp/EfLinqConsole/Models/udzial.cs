using System;
using System.Collections.Generic;

namespace EfLinqConsole.Models;

public partial class udzial
{
    public string? uczestnik { get; set; }

    public int? kurs { get; set; }

    public DateOnly? data_od { get; set; }

    public DateOnly? data_do { get; set; }

    public string? status { get; set; }

    public virtual kursy? kursNavigation { get; set; }

    public virtual uczestnicy? uczestnikNavigation { get; set; }
}

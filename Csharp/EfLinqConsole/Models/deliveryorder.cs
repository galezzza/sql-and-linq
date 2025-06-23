using System;
using System.Collections.Generic;

namespace EfLinqConsole.Models;

public partial class deliveryorder
{
    public int orderid { get; set; }

    public DateTime orderdate { get; set; }

    public string ordernum { get; set; } = null!;

    public string? reference { get; set; }

    public int customerid { get; set; }

    public int pickupaddressid { get; set; }

    public int deliveryaddressid { get; set; }

    public int serviceid { get; set; }

    public int rateplanid { get; set; }

    public int orderstatusid { get; set; }

    public int? driverid { get; set; }

    public short pieces { get; set; }

    public decimal amount { get; set; }

    public DateTime modtime { get; set; }

    public string placeholder { get; set; } = null!;
}

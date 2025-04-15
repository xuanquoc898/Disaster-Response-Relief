using System;
using System.Collections.Generic;

namespace D2R.Models;

public partial class Area
{
    public int AreaId { get; set; }

    public string Name { get; set; } = null!;

    public string? District { get; set; }

    public string? Province { get; set; }

    public virtual ICollection<Campaign> Campaigns { get; set; } = new List<Campaign>();

    public virtual ICollection<DistributionLog> DistributionLogs { get; set; } = new List<DistributionLog>();

    public virtual ICollection<Donation> Donations { get; set; } = new List<Donation>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();

    public virtual ICollection<Warehouse> Warehouses { get; set; } = new List<Warehouse>();
}

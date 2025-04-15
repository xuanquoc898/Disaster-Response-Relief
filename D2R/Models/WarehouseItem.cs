using System;
using System.Collections.Generic;

namespace D2R.Models;

public partial class WarehouseItem
{
    public int ItemId { get; set; }

    public string Name { get; set; } = null!;

    public string? Unit { get; set; }

    public int? CategoryId { get; set; }

    public virtual ICollection<CampaignItem> CampaignItems { get; set; } = new List<CampaignItem>();

    public virtual ItemCategory? Category { get; set; }

    public virtual ICollection<DistributionLog> DistributionLogs { get; set; } = new List<DistributionLog>();

    public virtual ICollection<DonationItem> DonationItems { get; set; } = new List<DonationItem>();

    public virtual ICollection<SyncLogItem> SyncLogItems { get; set; } = new List<SyncLogItem>();

    public virtual ICollection<WarehouseStock> WarehouseStocks { get; set; } = new List<WarehouseStock>();
}

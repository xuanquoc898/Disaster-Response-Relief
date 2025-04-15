using System;
using System.Collections.Generic;

namespace D2R.Models;

public partial class CampaignItem
{
    public int CampaignId { get; set; }

    public int ItemId { get; set; }

    public int? QuantityRequested { get; set; }

    public int? QuantityApproved { get; set; }

    public virtual Campaign Campaign { get; set; } = null!;

    public virtual WarehouseItem Item { get; set; } = null!;
}

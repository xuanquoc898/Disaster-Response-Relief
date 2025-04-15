using System;
using System.Collections.Generic;

namespace D2R.Models;

public partial class SyncLog
{
    public int SyncId { get; set; }

    public int? WarehouseId { get; set; }

    public DateTime? SyncDate { get; set; }

    public string? Status { get; set; }

    public virtual ICollection<SyncLogItem> SyncLogItems { get; set; } = new List<SyncLogItem>();

    public virtual Warehouse? Warehouse { get; set; }
}

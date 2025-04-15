using System;
using System.Collections.Generic;

namespace D2R.Models;

public partial class Warehouse
{
    public int WarehouseId { get; set; }

    public string Type { get; set; } = null!;

    public int? AreaId { get; set; }

    public string Name { get; set; } = null!;

    public virtual Area? Area { get; set; }

    public virtual ICollection<SyncLog> SyncLogs { get; set; } = new List<SyncLog>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();

    public virtual ICollection<WarehouseStock> WarehouseStocks { get; set; } = new List<WarehouseStock>();
}

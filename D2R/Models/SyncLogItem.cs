namespace D2R.Models;

public partial class SyncLogItem
{
    public int SyncLogItemId { get; set; }

    public int? SyncId { get; set; }

    public int? ItemId { get; set; }

    public int? Quantity { get; set; }

    public virtual WarehouseItem? Item { get; set; }

    public virtual SyncLog? Sync { get; set; }
}

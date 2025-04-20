namespace D2R.Models;

public partial class WarehouseStock
{
    public int StockId { get; set; }

    public int? WarehouseId { get; set; }

    public int? ItemId { get; set; }

    public int? Quantity { get; set; }

    public DateTime? LastUpdated { get; set; }

    public virtual WarehouseItem? Item { get; set; }

    public virtual Warehouse? Warehouse { get; set; }
}

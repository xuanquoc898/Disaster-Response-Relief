namespace D2R.Models;

public partial class DonationItem
{
    public int DonationItemId { get; set; }

    public int? DonationId { get; set; }

    public int? ItemId { get; set; }

    public int? Quantity { get; set; }

    public string? Unit { get; set; }

    public virtual Donation? Donation { get; set; }

    public virtual WarehouseItem? Item { get; set; }
}

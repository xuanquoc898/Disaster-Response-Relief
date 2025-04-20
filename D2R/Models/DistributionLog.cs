namespace D2R.Models;

public partial class DistributionLog
{
    public int DistributionId { get; set; }

    public int? CampaignId { get; set; }

    public int? ItemId { get; set; }

    public int? AreaId { get; set; }

    public int? Quantity { get; set; }

    public DateTime? DistributionDate { get; set; }

    public virtual Area? Area { get; set; }

    public virtual Campaign? Campaign { get; set; }

    public virtual WarehouseItem? Item { get; set; }
}

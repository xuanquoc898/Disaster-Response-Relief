namespace D2R.Models;

public partial class Campaign
{
    public int CampaignId { get; set; }

    public int AreaId { get; set; }

    public int? DisasterLevelId { get; set; }

    public string? Status { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? ApprovedAt { get; set; }
    public DateTime? RejectedAt { get; set; }
    public DateTime? CompletedAt { get; set; }

    public string? Note { get; set; }

    public virtual Area Area { get; set; } = null!;

    public virtual ICollection<CampaignItem> CampaignItems { get; set; } = new List<CampaignItem>();

    public virtual DisasterLevel? DisasterLevel { get; set; }

    public virtual ICollection<DistributionLog> DistributionLogs { get; set; } = new List<DistributionLog>();
}

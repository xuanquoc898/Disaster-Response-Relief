using D2R.Models;

public partial class Notification
{
    public int NotificationId { get; set; }
    public int UserId { get; set; }  // ✅ Đổi từ StaffId thành UserId
    public int? CampaignId { get; set; }
    public string Content { get; set; } = null!;
    public bool? IsRead { get; set; }
    public DateTime? CreatedAt { get; set; }

    public virtual User User { get; set; } = null!;
    public virtual Campaign? Campaign { get; set; }
}

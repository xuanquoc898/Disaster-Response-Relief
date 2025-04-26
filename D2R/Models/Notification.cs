namespace D2R.Models
{
    public partial class Notification
    {
        public int NotificationId { get; set; }
        public int StaffId { get; set; }
        public int? CampaignId { get; set; }
        public string Content { get; set; }
        public bool IsRead { get; set; }
        public DateTime CreatedAt { get; set; }

        public virtual Campaign? Campaign { get; set; }
        public virtual User Staff { get; set; }
    }
}

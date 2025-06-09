using D2R.Helpers;
using D2R.Models;
using D2R.Services;

namespace D2R.ViewModels
{
    public class NotificationDetailViewModel
    {
        private readonly SyncOperationService _syncOpService = new();
        private readonly NotificationDetailService _notificationService = new();

        public Notification Notification { get; private set; }
        public Campaign? Campaign { get; private set; }

        public NotificationDetailViewModel(Notification notification)
        {
            Notification = notification;
            LoadCampaign();
        }

        private void LoadCampaign()
        {
            if (Notification.CampaignId.HasValue)
            {
                Campaign = _notificationService.GetByNotiCampaignId(Notification.CampaignId.Value);
            }
        }

        public void MarkNotificationAsRead()
        {
            _notificationService.MarkNotificationAsRead(Notification.NotificationId);
        }

        public bool CanConfirm()
        {
            return Campaign != null && Campaign.Status == "Approved";
        }
        
        // xac nhan nhan hang cua staff sau khi da duoc phan phoi
        public void ConfirmReceived()
        {
            if (Campaign == null) return;

            Campaign.Status = "Completed";
            Campaign.CompletedAt = DateTime.Now;
            _notificationService.UpdateNotification(Campaign);

            _syncOpService.SyncWarehouseFromDistribution(
                Campaign.CampaignId,
                LoginSession.CurrentUser.WarehouseId ?? 0
            );
        }
    }
}

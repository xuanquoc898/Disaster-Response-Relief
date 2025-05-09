using D2R.Models;
using D2R.Repositories;

namespace D2R.Services
{
    public class NotificationDetailService
    {
        private readonly NotificationRepository _notiRepository = new();
        private readonly CampaignRepository _campaignRepository = new();

        public void CreateNotification(int userId, int? campaignId, string content)
        {
            var notification = new Notification
            {
                UserId = userId,
                CampaignId = campaignId,
                Content = content,
                IsRead = false,
                CreatedAt = DateTime.Now
            };

            _notiRepository.Add(notification);
        }
        public Campaign GetByNotiCampaignId(int campaignId)
        {
            return _campaignRepository.GetById(campaignId);
        }
        public void UpdateNotification(Campaign entity)
        {
            _campaignRepository.Update(entity);
        }
        public List<Notification> GetNotificationsByUserId(int userId)
        {
            return _notiRepository.GetByUserId(userId);
        }

        public void MarkNotificationAsRead(int notificationId)
        {
            _notiRepository.MarkAsRead(notificationId);
        }
    }
}

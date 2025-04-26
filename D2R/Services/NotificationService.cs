using D2R.Repositories;

namespace D2R.Services
{
    public class NotificationService
    {
        private readonly NotificationRepository _repository = new();

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

            _repository.Add(notification); // 🔥 Gọi Repository, không tự save
        }

        public List<Notification> GetNotificationsByUserId(int userId)
        {
            return _repository.GetByUserId(userId);
        }

        public void MarkNotificationAsRead(int notificationId)
        {
            _repository.MarkAsRead(notificationId);
        }
    }
}

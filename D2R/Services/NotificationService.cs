using D2R.Models;
using D2R.Repositories;
using System.Collections.Generic;

namespace D2R.Services
{
    public class NotificationService
    {
        private readonly NotificationRepository _repository = new();

        public void CreateNotification(int staffId, int? campaignId, string content)
        {
            var notification = new Notification
            {
                StaffId = staffId,
                CampaignId = campaignId,
                Content = content,
                IsRead = false,
                CreatedAt = DateTime.Now
            };
            _repository.Add(notification);
        }

        public List<Notification> GetNotificationsByStaff(int staffId)
        {
            return _repository.GetByStaffId(staffId);
        }

        public void MarkNotificationAsRead(int notificationId)
        {
            _repository.MarkAsRead(notificationId);
        }
    }
}

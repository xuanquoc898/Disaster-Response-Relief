using D2R.Models;

namespace D2R.Repositories
{
    public class NotificationRepository
    {
        private readonly DisasterReliefContext _context = new();

        public void Add(Notification notification)
        {
            _context.Notifications.Add(notification);
            _context.SaveChanges();
        }

        public List<Notification> GetByUserId(int userId)
        {
            return _context.Notifications
                .Where(n => n.UserId == userId)
                .OrderByDescending(n => n.CreatedAt)
                .ToList();
        }

        public void MarkAsRead(int notificationId)
        {
            var notification = _context.Notifications.FirstOrDefault(n => n.NotificationId == notificationId);
            if (notification != null)
            {
                notification.IsRead = true;
                _context.SaveChanges();
            }
        }
    }
}

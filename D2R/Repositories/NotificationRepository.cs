using D2R.Models;
using System.Collections.Generic;
using System.Linq;

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

        public List<Notification> GetByStaffId(int staffId)
        {
            return _context.Notifications
                .Where(n => n.StaffId == staffId)
                .OrderByDescending(n => n.CreatedAt)
                .ToList();
        }

        public void MarkAsRead(int notificationId)
        {
            var notification = _context.Notifications.Find(notificationId);
            if (notification != null)
            {
                notification.IsRead = true;
                _context.SaveChanges();
            }
        }
    }
}

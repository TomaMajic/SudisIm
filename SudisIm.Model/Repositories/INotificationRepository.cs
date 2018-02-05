using System.Collections.Generic;
using SudisIm.Model.Models;

namespace SudisIm.Model.Repositories
{
    public interface INotificationRepository
    {
        Notification GetNotificationById(long notificationId);
        ICollection<Notification> GetNotifications();
        Notification AddNotification(Notification notification);
    }
}

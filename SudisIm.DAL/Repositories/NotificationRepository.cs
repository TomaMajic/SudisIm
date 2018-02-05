using System.Collections.Generic;
using System.Linq;
using NHibernate;
using SudisIm.DAL.NHibernate;
using SudisIm.Model.Models;
using SudisIm.Model.Repositories;

namespace SudisIm.DAL.Repositories
{
    public class NotificationRepository : INotificationRepository
    {
        private readonly ISession session;

        public NotificationRepository()
            : this(NHibernateHelper.Instance.OpenSession())
        { }

        public NotificationRepository(ISession session)
        {
            this.session = session;
        }

        public Notification GetNotificationById(long notificationId)
        {
            return this.session.Get<Notification>(notificationId);
        }

        public ICollection<Notification> GetNotifications()
        {
            return this.session.Query<Notification>().ToList();
        }

        public Notification AddNotification(Notification notification)
        {
            session.SaveOrUpdate(notification);
            session.Flush();
            return notification;
        }
    }
}
using NHibernate;
using SudisIm.DAL.NHibernate;
using SudisIm.DAL.Repositories;
using SudisIm.Model.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SudisIm.Controllers
{
    public class NotificationController : Controller
    {
        private readonly INotificationRepository notificationsRepository;
        private readonly IRefereeRepository refereeRepository;

        #region Constructors
        public NotificationController()
            : this(NHibernateHelper.Instance.OpenSession())
        { }

        public NotificationController(ISession session)
            : this(new NotificationRepository(session), new RefereeRepository(session))
        { }

        public NotificationController(INotificationRepository notificationRepository, IRefereeRepository refereeRepository)
        {
            this.notificationsRepository = notificationRepository;
            this.refereeRepository = refereeRepository;
        }
        #endregion

        // GET: Notification
        public ActionResult Index()
        {
            var referee = this.refereeRepository.GetRefereeByUser(User.Identity.Name);
            return View(this.notificationsRepository.GetNotificationsForReferee(referee.Id));
        }
    }
}
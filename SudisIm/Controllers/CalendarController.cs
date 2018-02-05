using System.Linq;
using System.Web.Mvc;
using NHibernate;
using SudisIm.DAL.NHibernate;
using SudisIm.DAL.Repositories;
using SudisIm.Model.Repositories;
using SudisIm.Models.Calendar;
using SudisIm.Services.Users;

namespace SudisIm.Controllers
{
    public class CalendarController : Controller
    {
        private readonly IGameRepository gameRepository;
        private readonly IRefereeRepository refereeRepository;
        #region Constructors
        public CalendarController()
            : this(NHibernateHelper.Instance.OpenSession())
        { }

        public CalendarController(ISession session)
            : this(new GameRepository(session), new RefereeRepository(session))
        { }

        public CalendarController(IGameRepository gameRepo, IRefereeRepository refereeRepo)
        {
            this.gameRepository = gameRepo;
            this.refereeRepository = refereeRepo;
        }

        #endregion /Constructors
        [Authorize(Roles = "referee")]
        // GET: Calendar
        public ActionResult Index()
        {
            var referee = this.refereeRepository.GetRefereeByUser(User.Identity.Name);
            var games = this.gameRepository.GetGamesForReferee(referee.Id);
            var calendarEvents = games.Select(g => (CalendarEventDto)g).ToList();
            var absenceEvents = referee.Absences.Select(a => (CalendarEventDto) a);
            calendarEvents.AddRange(absenceEvents);
            var calendarVM = new RefereeCalendarViewModel()
            {
                Events = calendarEvents

            };
            return View(calendarVM);
        }
    }
}
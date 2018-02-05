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
        private readonly IUserService userService;
        private readonly ILicenceRepository licenceRepository;
        private readonly ITeamRepository teamRepository;
        private readonly IRefereeRepository refereeRepository;
        private readonly ICityRepository cityRepository;
        #region Constructors
        public CalendarController()
            : this(NHibernateHelper.Instance.OpenSession())
        { }

        public CalendarController(ISession session)
            : this(new GameRepository(session), new UserService(session), new LicenceRepository(session), new TeamRepository(session), new RefereeRepository(session), new CityRepository(session))
        { }

        public CalendarController(IGameRepository gameRepo, IUserService userService, ILicenceRepository licenceRepo, ITeamRepository teamRepo, IRefereeRepository refereeRepo, ICityRepository cityRepo)
        {
            this.userService = userService;
            this.gameRepository = gameRepo;
            this.licenceRepository = licenceRepo;
            this.teamRepository = teamRepo;
            this.refereeRepository = refereeRepo;
            this.cityRepository = cityRepo;
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
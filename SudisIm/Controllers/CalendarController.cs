using System.Linq;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using NHibernate;
using SudisIm.DAL.NHibernate;
using SudisIm.DAL.Repositories;
using SudisIm.Model.Models;
using SudisIm.Model.Repositories;
using SudisIm.Models.Games;

namespace SudisIm.Controllers
{
    public class CalendarController : Controller
    {
        private readonly IGameRepository gameRepository;
        private readonly ILicenceRepository licenceRepository;
        private readonly ITeamRepository teamRepository;
        private readonly IRefereeRepository refereeRepository;
        private readonly ICityRepository cityRepository;
        #region Constructors
        public CalendarController()
            : this(NHibernateHelper.Instance.OpenSession())
        { }

        public CalendarController(ISession session)
            : this(new GameRepository(session), new LicenceRepository(session), new TeamRepository(session), new RefereeRepository(session), new CityRepository(session) )
        { }

        public CalendarController(IGameRepository gameRepo, ILicenceRepository licenceRepo, ITeamRepository teamRepo, IRefereeRepository refereeRepo, ICityRepository cityRepo)
        {
            this.gameRepository = gameRepo;
            this.licenceRepository = licenceRepo;
            this.teamRepository = teamRepo;
            this.refereeRepository = refereeRepo;
            this.cityRepository = cityRepo;
        }

        #endregion /Constructors
        [Authorize(Roles = "referee")]
        // GET: Games
        public ActionResult Index()
        {
            return View(this.gameRepository.GetGames());
        }
    }
}
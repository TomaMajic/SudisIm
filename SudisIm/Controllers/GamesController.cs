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
    public class GamesController : Controller
    {
        private readonly IGameRepository gameRepository;
        private readonly ILicenceRepository licenceRepository;
        private readonly ITeamRepository teamRepository;
        private readonly IRefereeRepository refereeRepository;
        private readonly ICityRepository cityRepository;
        #region Constructors
        public GamesController()
            : this(NHibernateHelper.Instance.OpenSession())
        { }

        public GamesController(ISession session)
            : this(new GameRepository(session), new LicenceRepository(session), new TeamRepository(session), new RefereeRepository(session), new CityRepository(session) )
        { }

        public GamesController(IGameRepository gameRepo, ILicenceRepository licenceRepo, ITeamRepository teamRepo, IRefereeRepository refereeRepo, ICityRepository cityRepo)
        {
            this.gameRepository = gameRepo;
            this.licenceRepository = licenceRepo;
            this.teamRepository = teamRepo;
            this.refereeRepository = refereeRepo;
            this.cityRepository = cityRepo;
        }

        #endregion /Constructors
        [Authorize(Roles = "admin")]
        // GET: Games
        public ActionResult Index()
        {
            return View(this.gameRepository.GetGames());
        }

        public ActionResult Create()
        {
            return View(GetCreateViewModel());
        }


        private GameCreateViewModel GetCreateViewModel()
        {
            return new GameCreateViewModel()
            {
                Cities = this.cityRepository.GetCities(),
                Licences = this.licenceRepository.GetLicences(),
                Referees = this.refereeRepository.GetReferees(),
                Teams = this.teamRepository.GetTeams(),
                Game = new Game()
            };
        }
    }
}
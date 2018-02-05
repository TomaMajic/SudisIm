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
    public class AbsenceController : Controller
    {
        private readonly IGameRepository gameRepository;
        private readonly IRefereeRepository refereeRepository;

        #region Constructors
        public AbsenceController()
            : this(NHibernateHelper.Instance.OpenSession())
        { }

        public AbsenceController(ISession session)
            : this(new GameRepository(session),  new RefereeRepository(session))
        { }

        public AbsenceController(IGameRepository gameRepo, IRefereeRepository refereeRepo)
        {
            this.gameRepository = gameRepo;
            this.refereeRepository = refereeRepo;
        }

        #endregion /Constructors
        [Authorize(Roles = "referee")]
        // GET: Absence
        public ActionResult Index()
        {
            var referee = this.refereeRepository.GetRefereeByUser(User.Identity.Name);

            return View(referee.Absences);
        }
    }
}
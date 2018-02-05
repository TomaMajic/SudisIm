using System;
using System.Linq;
using System.Web.Mvc;
using NHibernate;
using SudisIm.DAL.NHibernate;
using SudisIm.DAL.Repositories;
using SudisIm.Model.Models;
using SudisIm.Model.Repositories;

namespace SudisIm.Controllers
{
    public class AbsenceController : Controller
    {
        private readonly IRefereeRepository refereeRepository;
        private readonly IAbsenceRepository absenceRepository;

        #region Constructors
        public AbsenceController()
            : this(NHibernateHelper.Instance.OpenSession())
        { }

        public AbsenceController(ISession session)
            : this(new RefereeRepository(session), new AbsenceRepository(session))
        { }

        public AbsenceController(IRefereeRepository refereeRepo, IAbsenceRepository absenceRepository)
        {
            this.refereeRepository = refereeRepo;
            this.absenceRepository = absenceRepository;
        }

        #endregion /Constructors
        [Authorize(Roles = "referee")]
        // GET: Absence
        public ActionResult Index()
        {
            var referee = this.refereeRepository.GetRefereeByUser(User.Identity.Name);

            return View(referee.Absences);
        }

        [Authorize(Roles = "referee")]
        // GET: Absence/Create
        public ActionResult Create()
        {
            var absence = new Absence()
            {
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(1)
            };
            return View(absence);
        }

        [Authorize(Roles = "referee")]
        // GET: Absence/Create

        [HttpPost]
        public ActionResult Create(Absence newAbsence)
        {
            // Assign referee
            var referee = this.refereeRepository.GetRefereeByUser(User.Identity.Name);
            newAbsence.Referee = referee;

            this.absenceRepository.AddAbsence(newAbsence);

            return RedirectToAction("Index");
        }

        [Authorize(Roles = "referee")]
        public ActionResult Delete( int id)
        {
            // Check owner
            var referee = this.refereeRepository.GetRefereeByUser(User.Identity.Name);
            if(!referee.Absences.Any(a => a.Id == id))
                throw new Exception("Ne mozete izbrisati tudje odsustvo");

            this.absenceRepository.RemoveAbsence(id);
            return RedirectToAction("Index");
        }
    }
}
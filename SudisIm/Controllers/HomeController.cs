using System.Security.Claims;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using NHibernate;
using SudisIm.DAL.NHibernate;
using SudisIm.DAL.Repositories;
using SudisIm.Model.Repositories;

namespace SudisIm.Controllers
{
    public class HomeController : Controller
    {
        private readonly IGameRepository gameRepository;

        #region Constructors
        public HomeController()
            : this(NHibernateHelper.Instance.OpenSession())
        { }

        public HomeController(ISession session)
            : this(new GameRepository(session))
        { }

        public HomeController(IGameRepository gameRepository)
        {
            this.gameRepository = gameRepository;
        }

        #endregion /Constructors

        public ActionResult Index()
        {
            return View(this.gameRepository.GetGames());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
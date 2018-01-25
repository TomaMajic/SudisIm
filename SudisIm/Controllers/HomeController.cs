using System;
using System.Collections.Generic;
using System.Web.Mvc;
using NHibernate;
using SudisIm.DAL.NHibernate;
using SudisIm.DAL.Repositories;
using SudisIm.Model.Models;

namespace SudisIm.Controllers
{
    public class HomeController : Controller
    {
        private ISessionFactory _sessionFactory;
        public ActionResult Index()
        {


            var city = new City()
            {
                Name = "Cudni name"
            };
            var session = NHibernateHelper.Instance.OpenSession();
            session.Save(city);
            var team1 = new Team()
            {
                Name = "test tim1",
                City = city
            };
            var team2 = new Team()
            {
                Name = "test tim2",
                City = city
            };
            var licence1 = new Licence()
            {
                Name = "licence1",
                Priority = 1
            };
            session.Save(team1);
            session.Save(team2);
            session.Save(licence1);
            // Test referee repository
            var refRepo = new RefereeRepository();
            var referee = new Referee()
            {
                Address = "ulica bla bla",
                Description = "bla bla opis",
                FirstName = "ime suca 1",
                LastName = "prezime",
                City = city,
                Licence = licence1

            };

            refRepo.AddReferee(referee);
            
            var gameRepo = new GameRepository(session);
            var game = new Game()
            {
                Address = "adresa",
                City = city,
                AwayTeam = team1,
                HomeTeam = team2,
                StartTime = DateTime.Now,
                Referees =  new List<Referee>() { referee}
            };

            gameRepo.AddGame(game);
            var notification = new Notification()
            {
                Referee = referee,
                Game = game,
                Text = "text notifikacije"
            };
            session.Save(notification);
            return View();
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
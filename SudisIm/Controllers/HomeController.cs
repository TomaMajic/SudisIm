using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using SudisIm.DAL.NHibernate;
using SudisIm.DAL.Repositories;
using SudisIm.Model.Models;
using SudisIm.Models;

namespace SudisIm.Controllers
{
    public class HomeController : Controller
    {
        private ISessionFactory _sessionFactory;
        public ActionResult Index()
        {

            // Test referee repository
            var refRepo = new RefereeRepository();
            var city = new City()
            {
                Name = "Cudni name"
            };
            var session = NHibernateHelper.Instance.OpenSession();
            session.Save(city);

            var referee = new Referee()
            {
                Address = "ulica bla bla",
                Description = "bla bla opis",
                FirstName = "ime",
                LastName = "prezime",
                City = city

            };
            refRepo.AddReferee(referee);
            return View();
        }

        void CreateDatabase(string connectionString)
        {
            var configuration = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012.ConnectionString(connectionString).ShowSql)
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<CustomerMap>())
                .BuildConfiguration();

            var exporter = new SchemaExport(configuration);
            exporter.Execute(true, true, false);

            _sessionFactory = configuration.BuildSessionFactory();
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
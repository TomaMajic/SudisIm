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
using SudisIm.Models;

namespace SudisIm.Controllers
{
    public class HomeController : Controller
    {
        private ISessionFactory _sessionFactory;
        public ActionResult Index()
        {
            ////creating database 
            ////string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            ////CreateDatabase(connectionString);
            ////Console.WriteLine("Database Created sucessfully");

            ////creating a object of customer
            //Customer customer = new Customer
            //{
            //    CustomerId = 2,
            //    FirstName = "Jalpesh2",
            //    LastName = "Vadgama2"
            //};

            ////saving customer in database.
            //using (ISession session = NHibernateHelper.Instance.OpenSession())
            //    session.Save(customer);

            //Console.WriteLine("Customer Saved");
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
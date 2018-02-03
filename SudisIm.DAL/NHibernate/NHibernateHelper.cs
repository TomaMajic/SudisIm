using System.Configuration;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Microsoft.AspNet.Identity;
using NHibernate;
using NHibernate.AspNet.Identity;
using NHibernate.AspNet.Identity.Helpers;
using NHibernate.Tool.hbm2ddl;
using SudisIm.DAL.Mappings;
using SudisIm.Model.Models;

namespace SudisIm.DAL.NHibernate
{
    public sealed class NHibernateHelper
    {
        private static readonly ISessionFactory _instance = CreateSessionFactory();
        public static  UserManager<ApplicationUser> userManager;
        
        public static ISessionFactory Instance
        {
            get { return _instance; }
        }

        private static ISessionFactory CreateSessionFactory()
        {
            // this assumes you are using the default Identity model of "ApplicationUser"
            var myEntities = new[] {
                typeof(ApplicationUser)
            };

            //creating database 
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            //string connectionString = "Data Source = (localhost)\\MSSQLSERVER2016; Initial Catalog = SudisImTest; Integrated Security = True";

            var sessionFactory = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012.ConnectionString(connectionString).ShowSql)
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<CityMap>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<LicenceMap>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<RefereeMap>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<TeamMap>())               
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<GameMap>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<NotificationMap>())
                .ExposeConfiguration(cfg =>
                {

                    cfg.AddDeserializedMapping(MappingHelper.GetIdentityMappings(myEntities), null);
                    new SchemaUpdate(cfg).Execute(false, true);
                })
                .BuildSessionFactory();
            
            userManager = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(sessionFactory.OpenSession()));
           
            return sessionFactory;
        }
    }
}
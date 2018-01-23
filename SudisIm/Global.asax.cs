using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using System.Web.Optimization;
using System.Web.Routing;
using NHibernate.Tool.hbm2ddl;

namespace SudisIm
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //var configuration = Fluently.Configure()
            //    .Database(MsSqlConfiguration.MsSql2012.ConnectionString(connectionString).ShowSql)
            //    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<CustomerMap>())
            //    .BuildConfiguration();

            //var sessionFactory = configuration.BuildSessionFactory();
            //ISession sess = sessionFactory.OpenSession();

        }
    }
}

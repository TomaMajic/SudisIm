﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using NHibernate;
using NHibernate.AspNet.Identity;
using NHibernate.AspNet.Identity.Helpers;
using NHibernate.Tool.hbm2ddl;
using SudisIm.Model.Models;
using SudisIm.Models;

namespace SudisIm
{
    public sealed class NHibernateHelper
    {
        private static readonly ISessionFactory _instance = CreateSessionFactory();
        public static  UserManager<ApplicationUser> userManager;
        public static SignInManager<ApplicationUser, string> signInManager;
        
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

            var sessionFactory = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012.ConnectionString(connectionString).ShowSql)
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<CustomerMap>())
                .ExposeConfiguration(cfg =>
                {

                    cfg.AddDeserializedMapping(MappingHelper.GetIdentityMappings(myEntities), null);
                    new SchemaUpdate(cfg).Execute(false, true);
                })
                //.ExposeConfiguration(cfg => new SchemaUpdate(cfg).Execute(false, true))
                .BuildSessionFactory();


            //var exporter = new SchemaExport(configuration);
            //exporter.Execute(true, true, false);
            userManager = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(sessionFactory.OpenSession()));
           
            return sessionFactory;
        }
    }
}
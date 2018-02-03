using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NHibernate;
using SudisIm.DAL.NHibernate;
using SudisIm.Model.Models;

namespace SudisIm.Tests.Repositories
{
    [TestClass]
    public class RefereeRepositoryTests
    {
        private ISession session = NHibernateHelper.Instance.OpenSession();
        public void TestInit()
        {
            
        }
        [TestMethod]
        public void AddRefereeTest()
        {

            var referee = new Referee();
        }
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using SudisIm.Model.Models;

namespace SudisIm.Tests.Models
{
    [TestClass]
    public class TeamTests
    {
        [TestMethod]
        public void CreateTeamTest()
        {
            var name = "Test Team";

            var city = new City("Split", 21000);

            var team = new Team(name, city);
            Assert.AreEqual(team.Name, name);
            Assert.AreEqual(team.City, city);
        }
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using SudisIm.Model.Models;

namespace SudisIm.Tests.Models
{
    [TestClass]
    public class RefereeTests
    {
        [TestMethod]
        public void CreateRefereeTest()
        {
            var firstName = "Nomen";
            var lastName = "Nescio";
            var licence = new Licence();

            var referee = new Referee(firstName,lastName, licence);

            Assert.AreEqual(referee.FirstName, firstName);
            Assert.AreEqual(referee.LastName, lastName);
            Assert.AreEqual(referee.Licence, licence);
        }
    }
}

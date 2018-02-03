using Microsoft.VisualStudio.TestTools.UnitTesting;
using SudisIm.Model.Models;

namespace SudisIm.Tests.Models
{
    [TestClass]
    public class LicenceTests
    {
        [TestMethod]
        public void CreateLicenceTest()
        {
            var licenceName = "Gradska";
            var priority = 1;

            var licence = new Licence(licenceName, priority);

            Assert.IsTrue(licence.Name == licenceName, "licence.Name == licenceName");
            Assert.IsTrue(licence.Priority == priority, "licence.Priority == priority");
        }
    }
}

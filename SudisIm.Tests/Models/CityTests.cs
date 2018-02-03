using Microsoft.VisualStudio.TestTools.UnitTesting;
using SudisIm.Model.Models;

namespace SudisIm.Tests.Models
{
    [TestClass]
    public class CityTests
    {
        [TestMethod]
        public void CreateCityTest()
        {
            var cityName = "Split";
            var postalCode = 21000;

            var city = new City(cityName, postalCode);

            Assert.IsTrue(city.Name == cityName, "city.Name == cityName");
            Assert.IsTrue(city.PostalCode == postalCode, "city.PostalCode == postalCode");
        }
    }
}

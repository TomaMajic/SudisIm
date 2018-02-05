using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SudisIm.Model.Models;

namespace SudisIm.Tests.Models
{
    [TestClass]
    public class NotificiationTests
    {
        private Game game;
        private Referee referee;

        [TestInitialize]
        public void TestInit()
        {
            var city = new City("Zagreb", 21000);
            var adresa = "Jarunska 2";
            var startTime = new DateTime(2018, 1, 1);

            game = new Game()
            {
                City = city,
                Address = adresa,
                StartTime = startTime
            };
            referee = new Referee();
        }
        [TestMethod]
        public void CreateNotificiationTest()
        {
            var notification = new Notification(game,referee);

            Assert.IsTrue(notification.Game == game, "notification.Game == game");
            Assert.IsTrue(notification.Referee == referee, "notification.Referee == referee");
        }

        [TestMethod]
        public void NotificationDefaultTextTest()
        {
            var expectedText = $"Dodijeljeni ste utakmici u {game.City.Name} - {game.Address} u {game.GetFormatedStartTime()}";
            var notification =new Notification(game, referee);
            Assert.IsTrue(notification.Text == expectedText,"notification.Text == expectedText");
        }
    }
}

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SudisIm.Model.Models;

namespace SudisIm.Tests.Models
{
    [TestClass]
    public class GameTests
    {
        private Game testGame;

        [TestInitialize]
        public void Init()
        {
            testGame = new Game();
        }

        [TestMethod]
        public void GetRefCount()
        {
            var expectedCount = 1;
            // Create ref
            var referee = new Referee();
            // Add to game
            testGame.Referees.Add(referee);

            // Check count
            var count = testGame.GetRefereeCount();
            Assert.IsTrue(count == expectedCount,"count == expectedCount");
        }

        [TestMethod]
        public void GetFormatedStartTime()
        {
            var testStartTime = new DateTime(2018,1,1);
            var expectedText = "ponedjeljak, 01.01.2018";

            // Add start time
            testGame.StartTime = testStartTime;
           
            // Check count
            var formatedStartTime = testGame.GetFormatedStartTime();
            Assert.IsTrue(formatedStartTime == expectedText, "formatedStartTime == expectedText");
        }
    }
}

using Interfaces.RequestBody;
using Logic.Container;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Mock;

namespace Test
{
    [TestClass]
    public class SpeedrunTest
    {
        private SpeedrunMock speedrunMock;
        private SpeedrunContainer speedrunContainer;

        [TestInitialize]
        public void Init()
        {
            speedrunMock = new SpeedrunMock();
            speedrunContainer = new SpeedrunContainer(speedrunMock);
        }

        [TestMethod]
        public void TestGetSpeedruns()
        {
            var speedruns = speedrunContainer.GetSpeedruns().Result;
            Assert.AreEqual(2, speedruns.Count);
            Assert.AreEqual("Test", speedruns[0].SpeedrunName);
        }

        [TestMethod]
        public void TestGetSpeedrun()
        {
            var speedrun = speedrunContainer.GetSpeedrun(2).Result;
            Assert.AreEqual("Test2", speedrun.SpeedrunName);
        }

        [TestMethod]
        public void TestGetSpeedrunsByCategory()
        {
            var speedruns = speedrunContainer.GetSpeedrunsByCategory(1).Result;
            Assert.AreEqual(2, speedruns.Count);
            Assert.AreEqual("Test", speedruns[0].SpeedrunName);
        }

        [TestMethod]
        public void TestCreateSpeedrun()
        {
            SpeedrunBody speedrunBody = new SpeedrunBody
            {
                SpeedrunName = "Speedrun 3",
                Time = new DateTime(1900, 1, 1, 2, 00, 00, 573),
                PlatformId = 1,
                CategoryId = 1,
                Date = DateTime.Now,
                SpeedrunDescription= "",
                Status = 1,
                VideoLink = "aaaa.nl",
                UserId = 1
            };
            speedrunContainer.Createspeedrun(speedrunBody).Wait();
            var speedrun = speedrunContainer.GetSpeedrun(3).Result;
            Assert.AreEqual("Speedrun 3", speedrun.SpeedrunName);
        }

        [TestMethod]
        public void TestUpdateSpeedrun()
        {
            SpeedrunBody speedrunBody = new SpeedrunBody
            {
                SpeedrunName = "Speedrun 3",
                Time = new DateTime(1900, 1, 1, 2, 00, 00, 573),
                PlatformId = 1,
                CategoryId = 1,
                Date = DateTime.Now,
                SpeedrunDescription = "",
                Status = 1,
                VideoLink = "aaaa.nl",
                UserId = 1
            };
            speedrunContainer.Updatespeedrun(2, speedrunBody).Wait();
            var speedrun = speedrunContainer.GetSpeedrun(2).Result;
            Assert.AreEqual("Speedrun 3", speedrun.SpeedrunName);
        }

        [TestMethod]
        public void TestDeleteSpeedrun()
        {
            speedrunContainer.Deletespeedrun(2).Wait();
            var speedruns = speedrunContainer.GetSpeedruns().Result;
            Assert.AreEqual(1, speedruns.Count);
        }

        [TestMethod]
        public void TestGetSpeedrunsByUser()
        {
            var speedruns = speedrunContainer.GetLatestRuns().Result;
            Assert.AreEqual(2, speedruns.Count);
            Assert.AreEqual("Test", speedruns[0].SpeedrunName);
        }
    }
}

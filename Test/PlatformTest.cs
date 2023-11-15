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
    public class PlatformTest
    {
        private PlatformMock platformMock;
        private PlatformContainer platformContainer;

        [TestInitialize] 
        public void Init()
        {
            platformMock = new PlatformMock();
            platformContainer = new PlatformContainer(platformMock);
        }

        [TestMethod]
        public void TestGetPlatforms()
        {
            var platforms = platformContainer.GetPlatforms().Result;
            Assert.AreEqual(3, platforms.Count);
            Assert.AreEqual("Platform 1", platforms[0].PlatformName);
        }

        [TestMethod]
        public void TestGetPlatform()
        {
            var platform = platformContainer.GetPlatform(2).Result;
            Assert.AreEqual("Platform 2", platform.PlatformName);
        }

        [TestMethod]
        public void TestCreatePlatform()
        {
            PlatformBody platformBody = new PlatformBody
            {
                PlatformName = "Platform 4"
            };
            platformContainer.CreatePlatform(platformBody).Wait();
            var platform = platformContainer.GetPlatform(4).Result;
            Assert.AreEqual("Platform 4", platform.PlatformName);
        }

        [TestMethod]
        public void TestUpdatePlatform()
        {
            PlatformBody platformBody = new PlatformBody
            {
                PlatformName = "Platform 4"
            };
            platformContainer.UpdatePlatform(3, platformBody).Wait();

            var platform = platformContainer.GetPlatform(3).Result;
            Assert.AreEqual("Platform 4", platform.PlatformName);
        }

        [TestMethod]
        public void TestDeletePlatform()
        {
            platformContainer.DeletePlatform(3).Wait();
            var platforms = platformContainer.GetPlatforms().Result;
            Assert.AreEqual(2, platforms.Count);
        }
    }
}

using Interfaces.DTO;
using Interfaces.RequestBody;
using Logic.Container;
using Test.Mock;

namespace Test
{
    [TestClass]
    public class GameTest
    {
        private GameMock mock;
        private GameContainer gameContainer;

        [TestInitialize]
        public void Init()
        {
            mock = new GameMock();
            gameContainer = new GameContainer(mock);
        }

        [TestMethod]
        public void TestGetGames()
        {
            var games = gameContainer.GetGames().Result;
            Assert.AreEqual(2, games.Count);
            Assert.AreEqual("Game1", games[0].GameName);
        }

        [TestMethod]
        public void TestGetGame()
        {
            var game = gameContainer.GetGame(2).Result;
            Assert.AreEqual("Game2", game.GameName);
        }

        [TestMethod]
        public void TestGetGameByName()
        {
            var game = gameContainer.GetGameByName("Game1").Result;
            Assert.AreEqual(1, game.Id);
        }

        [TestMethod]
        public void TestCreateGame()
        {
            GameBody gameBody = new GameBody
            {
                GameName = "Game3",
                GameImage = "Image3",
                GameDescription = "Description3",
                Developer = "Developer3",
                Publisher = "Publisher3",
                ReleaseDate = DateTime.Now,
                Platforms = new List<PlatformDTO> { new PlatformDTO() { Id = 1, Manufacturer = "Manu1", PlatformName = "platform1", ReleaseDate = DateTime.Now } }
            };
            gameContainer.CreateGame(gameBody).Wait();
            var game = gameContainer.GetGame(3).Result;
            Assert.AreEqual("Game3", game.GameName);
        }

        [TestMethod]
        public void TestUpdateGame()
        {
            GameBody gameBody = new GameBody
            {
                GameName = "Game3",
                GameImage = "Image3",
                GameDescription = "Description3",
                Developer = "Developer3",
                Publisher = "Publisher3",
                ReleaseDate = DateTime.Now,
                Platforms = new List<PlatformDTO> { new PlatformDTO() { Id = 1, Manufacturer = "Manu1", PlatformName = "platform1", ReleaseDate = DateTime.Now } }
            };
            gameContainer.UpdateGame(2, gameBody).Wait();
            var game = gameContainer.GetGameByName("Game3").Result;
            Assert.AreEqual(2, game.Id);
        }

        [TestMethod]
        public void TestDeleteGame()
        {
            gameContainer.DeleteGame(3).Wait();
            var games = gameContainer.GetGames().Result;
            Assert.AreEqual(2, games.Count);
        }
    }
}
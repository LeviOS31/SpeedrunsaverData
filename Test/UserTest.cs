
using Interfaces.DTO;
using Interfaces.RequestBody;
using Logic.Container;
using Test.Mock;

namespace Test
{
    [TestClass]
    public class UserTest
    {
        private UserMock usermock;
        private UserTokenMock userTokenMock;
        private UserContainer userContainer;

        [TestInitialize]
        public void Init()
        {
            usermock = new UserMock();
            userTokenMock = new UserTokenMock();
            userContainer = new UserContainer(usermock, userTokenMock);
        }

        [TestMethod]
        public void TestGetUsers()
        {
            var users = userContainer.GetUsers().Result;
            Assert.AreEqual(2, users.Count);
            Assert.AreEqual("User1", users[0].Username);
        }

        [TestMethod]
        public void TestGetUser()
        {
            var user = userContainer.GetUser(2).Result;
            Assert.AreEqual("User2", user.Username);
        }

        [TestMethod]
        public void TestCreateUser()
        {
            UserBody userBody = new UserBody
            {
                Username = "User3",
                Password = "Password3",
                Email = "Email3",
                Admin = false
            };
            userContainer.CreateUser(userBody).Wait();
            var user = userContainer.GetUser(3).Result;
            Assert.AreEqual("User3", user.Username);
        }

        [TestMethod]
        public void TestUpdateUser()
        {
            UserBody userBody = new UserBody
            {
                Username = "User3",
                Password = "Password3",
                Email = "Email3",
                Admin = false
            };
            userContainer.UpdateUser(2, userBody).Wait();
            var user = userContainer.GetUser(2).Result;
            Assert.AreEqual("User3", user.Username);
        }

        [TestMethod]
        public void TestDeleteUser()
        {
            userContainer.DeleteUser(2).Wait();
            var users = userContainer.GetUsers().Result;
            Assert.AreEqual(1, users.Count);
        }

        [TestMethod]
        public void TestValidateUser()
        {
            UserBody userBody = new UserBody
            {
                Username = "User1",
                Password = "Password1",
                Email = "Email1",
                Admin = false
            };
            UserTokenDTO user = userContainer.ValidateUser(userBody).Result;
            Assert.AreEqual(1, user.userId);
        }

        [TestMethod]
        public void TestCheckUser()
        {
            TokenBody token = new TokenBody
            {
                userID = 1,
                Token = "aaa123213453"
            };

            int user = userContainer.CheckifCorrect(token).Result;
            Assert.AreEqual(1, user);
        }

        [TestMethod]
        public void TestCheckUserWrong()
        {
            TokenBody token = new TokenBody
            {
                userID = 1,
                Token = "bbbbbbbbb"
            };

            int user = userContainer.CheckifCorrect(token).Result;
            Assert.AreNotEqual(1, user);
        }
    }
}

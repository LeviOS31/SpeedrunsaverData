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
    public class CommentTest
    {
        private SpeedrunMock speedrunMock;
        private UserMock userMock;
        private CommentMock commentMock;

        private CommentContainer commentContainer;

        [TestInitialize]
        public void init()
        {
            speedrunMock = new SpeedrunMock();
            userMock = new UserMock();
            commentMock = new CommentMock();

            commentContainer = new CommentContainer(commentMock);
        }

        [TestMethod]
        public void TestGetComments()
        {
            var comments = commentContainer.GetComments().Result;

            Assert.AreEqual(2, comments.Count);
            Assert.AreEqual("Comment 1", comments[0].CommentText);
        }

        [TestMethod]
        public void TestGetComment()
        {
            var comment = commentContainer.GetComment(2).Result;

            Assert.AreEqual("Comment 2", comment.CommentText);
        }

        [TestMethod]
        public void TestCreateComment()
        {
            var commentBody = new CommentBody
            {
                CommentText = "Comment 3",
                SpeedrunId = 1,
                UserId = 1
            };

            commentContainer.CreateComment(commentBody).Wait();

            var comment = commentContainer.GetComment(3).Result;

            Assert.AreEqual("Comment 3", comment.CommentText);
            Assert.AreEqual(1, comment.SpeedrunId);
            Assert.AreEqual(1, comment.UserId);
        }

        [TestMethod]
        public void TestUpdateComment()
        {
            var commentBody = new CommentBody
            {
                CommentText = "Comment 3",
                SpeedrunId = 1,
                UserId = 1
            };

            commentContainer.UpdateComment(1, commentBody).Wait();

            var comment = commentContainer.GetComment(1).Result;

            Assert.AreEqual("Comment 3", comment.CommentText);
        }

        [TestMethod]
        public void TestDeleteComment()
        {
            commentContainer.DeleteComment(1).Wait();
            var comments = commentContainer.GetComments().Result;

            Assert.AreEqual(1, comments.Count);
            Assert.AreEqual("Comment 2", comments[0].CommentText);
        }
    }
}

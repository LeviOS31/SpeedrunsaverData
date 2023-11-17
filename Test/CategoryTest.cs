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
    public class CategoryTest
    {
        private CategoryMock categoryMock;
        private GameMock gameMock;
        private CategoryContainer categoryContainer;

        [TestInitialize]
        public void Init()
        {
            categoryMock = new CategoryMock();
            gameMock = new GameMock();
            categoryContainer = new CategoryContainer(categoryMock);
        }

        [TestMethod]
        public void TestGetCategories()
        {
            var categories = categoryContainer.GetCategories().Result;

            Assert.AreEqual(3, categories.Count);
            Assert.AreEqual("Category 1", categories[0].CategoryName);
        }

        [TestMethod]
        public void TestGetCategory()
        {
            var category = categoryContainer.GetCategory(2).Result;
            Assert.AreEqual("Category 2", category.CategoryName);
        }

        [TestMethod]
        public void TestGetCaregoriesByGameId()
        {
            var categories = categoryContainer.GetCategoriesByGameId(1).Result;
            Assert.AreEqual(2, categories.Count);

            Assert.AreEqual("Category 2", categories[0].CategoryName);
        }

        [TestMethod]
        public void TestCreateCategory()
        {
            CategoryBody categoryBody = new CategoryBody
            {
                CategoryName = "Category 4",
                gameId = 3
            };
            categoryContainer.CreateCategory(categoryBody).Wait();
            var category = categoryContainer.GetCategory(4).Result;

            Assert.AreEqual("Category 4", category.CategoryName);

            Assert.AreEqual(3, category.gameId);
        }

        [TestMethod]
        public void TestUpdateCategory()
        {
            CategoryBody categoryBody = new CategoryBody
            {
                CategoryName = "Category3",
                gameId = 3
            };
            categoryContainer.UpdateCategory(1, categoryBody).Wait();

            var category = categoryContainer.GetCategory(1).Result;
            Assert.AreEqual("Category3", category.CategoryName);
            Assert.AreEqual(3, category.gameId);
        }

        [TestMethod]
        public void TestDeleteCategory()
        {
            categoryContainer.DeleteCategory(1).Wait();
            var categories = categoryContainer.GetCategories().Result;

            Assert.AreEqual(2, categories.Count);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;
using TCG_CollectionGame.Business.Services;
using TCG_CollectionGame.Data.Services;
using TCG_CollectionGame.DataContext;
using TCG_CollectionGame.Enities.Models;

namespace TCG_CollectionGame.Test
{
    [TestClass]
    public class UserTest
    {
        public Mock<TCG_CollectionGameContext> MockData()
        {
            var data = new List<User>
            {
                new User {ID=1, Username="testUser1", Password="", Coin=100},
                new User {ID=2, Username="testUser2", Password="", Coin=0},
            }.AsQueryable();

            var mockset = new Mock<DbSet<User>>();

            mockset.As<IQueryable<User>>().Setup(m => m.Provider).Returns(data.Provider);
            mockset.As<IQueryable<User>>().Setup(m => m.Expression).Returns(data.Expression);
            mockset.As<IQueryable<User>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockset.As<IQueryable<User>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<TCG_CollectionGameContext>();
            mockContext.Setup(c => c.User).Returns(mockset.Object);

            return mockContext;
        }

        [TestMethod]
        public void GetUserTest()
        {
            //Arrange
            var mockContext = MockData();

            //Act
            var DataService = new DataUserService(mockContext.Object);
            var service = new BusinessUserService(DataService);
            var user = service.GetUser("testUser1");
            var ExpectedUser = new User { ID = 1, Username = "testUser1", Password = "", Coin = 100 };

            //Assert
            Assert.AreEqual(ExpectedUser.ID, user.ID);
            Assert.AreEqual(ExpectedUser.Username, user.Username);
            Assert.AreEqual(ExpectedUser.Password, user.Password);
            Assert.AreEqual(ExpectedUser.Coin, user.Coin);
        }

        [TestMethod]
        public void UserExistsTest()
        {
            //Arrange
            var mockContext = MockData();

            //Act
            var DataService = new DataUserService(mockContext.Object);
            var service = new BusinessUserService(DataService);

            bool test1 = service.UserExists("testUser1");
            bool test2 = service.UserExists("testUser3");

            //Assert
            Assert.AreEqual(true, test1);
            Assert.AreEqual(false, test2);
        }

        [TestMethod]
        public void CheckCoinsTest()
        {
            //Arrange
            var mockContext = MockData();

            //Act
            var DataService = new DataUserService(mockContext.Object);
            var service = new BusinessUserService(DataService);

            bool test1 = service.CheckCoins("testUser1");
            bool test2 = service.CheckCoins("testUser2");

            //Assert
            Assert.AreEqual(true, test1);
            Assert.AreEqual(false, test2);
        }
    }
}

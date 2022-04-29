using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;
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
                new User {ID=2, Username="testUser2", Password="", Coin=100},
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

            //Act

            //Assert
        }

        [TestMethod]
        public void UpdateUserTest()
        {
            //Arrange

            //Act

            //Assert
        }

        [TestMethod]
        public void UserExistsTest()
        {
            //Arrange

            //Act

            //Assert
        }

        [TestMethod]
        public void AddUserTest()
        {
            //Arrange

            //Act

            //Assert
        }

        [TestMethod]
        public void CheckCoinsTest()
        {
            //Arrange

            //Act

            //Assert
        }
    }
}

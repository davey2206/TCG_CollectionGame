using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;
using TCG_CollectionGame.Business.Services;
using TCG_CollectionGame.Data.Services;
using TCG_CollectionGame.DataContext;
using TCG_CollectionGame.Entities.Models;

namespace TCG_CollectionGame.Test
{
    [TestClass]
    public class SetTest
    {
        public Mock<TCG_CollectionGameContext> MockData()
        {
            var data = new List<Pokeset>
            {
                new Pokeset {SetName="testSet1", SetCode="testCode1"},
                new Pokeset {SetName="testSet2", SetCode="testCode2"},
                new Pokeset {SetName="testSet3", SetCode="testCode3"}
            }.AsQueryable();

            var mockset = new Mock<DbSet<Pokeset>>();

            mockset.As<IQueryable<Pokeset>>().Setup(m => m.Provider).Returns(data.Provider);
            mockset.As<IQueryable<Pokeset>>().Setup(m => m.Expression).Returns(data.Expression);
            mockset.As<IQueryable<Pokeset>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockset.As<IQueryable<Pokeset>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<TCG_CollectionGameContext>();
            mockContext.Setup(c => c.Pokeset).Returns(mockset.Object);

            return mockContext;
        }

        [TestMethod]
        public void GetAllSetsTest()
        {
            //Arrange
            var mockContext = MockData();

            //Act
            var DataService = new DataSetService(mockContext.Object);
            var service = new BusinessSetService(DataService);
            var sets = service.GetAllSets();

            //Assert
            Assert.AreEqual(3, sets.Count);
            Assert.AreEqual("testSet1", sets[0].SetName);
            Assert.AreEqual("testCode1", sets[0].SetCode);
            Assert.AreEqual("testSet2", sets[1].SetName);
            Assert.AreEqual("testCode2", sets[1].SetCode);
            Assert.AreEqual("testSet3", sets[2].SetName);
            Assert.AreEqual("testCode3", sets[2].SetCode);
        }
    }
}

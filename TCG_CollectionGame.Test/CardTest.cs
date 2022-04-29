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
    public class CardTest
    {
        public Mock<TCG_CollectionGameContext> MockData()
        {
            var data = new List<Pokecard>
            {
                new Pokecard {UserId=1, SetCode="swsh3", CardCode="swsh3-3", CardImg="https://images.pokemontcg.io/swsh3/3.png"},
                new Pokecard {UserId=2, SetCode="swsh3", CardCode="swsh3-26", CardImg="https://images.pokemontcg.io/swsh3/26.png"},
            }.AsQueryable();

            var mockset = new Mock<DbSet<Pokecard>>();

            mockset.As<IQueryable<Pokecard>>().Setup(m => m.Provider).Returns(data.Provider);
            mockset.As<IQueryable<Pokecard>>().Setup(m => m.Expression).Returns(data.Expression);
            mockset.As<IQueryable<Pokecard>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockset.As<IQueryable<Pokecard>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<TCG_CollectionGameContext>();
            mockContext.Setup(c => c.Pokecard).Returns(mockset.Object);

            return mockContext;
        }
        [TestMethod]
        public void GetAllCardsTest()
        {
            //Arrange
            var mockContext = MockData();

            //Act
            var DataService = new DataCardService(mockContext.Object);
            var service = new BusinessCardService(DataService);
            var cards = service.GetAllCards(1, "swsh3");

            //Assert
            Assert.AreEqual(1, cards.Count);
            Assert.AreEqual("https://images.pokemontcg.io/swsh3/3.png", cards[0]);
        }
    }
}
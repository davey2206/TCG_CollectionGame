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
                new Pokecard {User= new User{ ID=1 }, Pokeset=new Pokeset{ ID=1, SetCode="swsh3" }, CardCode="swsh3-3", CardImg="https://images.pokemontcg.io/swsh3/3.png"},
                new Pokecard {User= new User{ ID=2 }, Pokeset=new Pokeset{ ID=1, SetCode="swsh3" }, CardCode="swsh3-26", CardImg="https://images.pokemontcg.io/swsh3/26.png"},
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
            var data = new List<User>
            {
                new User { ID = 1, Cards=new List<Pokecard> { new Pokecard{ User = new User { ID = 1 }, Pokeset = new Pokeset { ID = 1, SetCode = "swsh3" }, CardCode = "swsh3-3", CardImg = "https://images.pokemontcg.io/swsh3/3.png" } } },
                new User { ID = 2, Cards = new List<Pokecard> { new Pokecard { User = new User { ID = 1 }, Pokeset = new Pokeset { ID = 1, SetCode = "swsh3" }, CardCode = "swsh3-3", CardImg = "https://images.pokemontcg.io/swsh3/3.png" } } }
            };
            var mockContext = MockData();

            //Act
            var DataService = new DataCardService(mockContext.Object);
            var DataSetService = new DataSetService(mockContext.Object);
            var service = new BusinessCardService(DataService, DataSetService);
            var cards = service.GetAllCards(data.Find(u => u.ID == 1), "swsh3");

            //assert
            Assert.AreEqual(1, cards.Count);
            Assert.AreEqual("https://images.pokemontcg.io/swsh3/3.png", cards[0]);
        }
    }
}
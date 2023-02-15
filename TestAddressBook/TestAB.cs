using AddressBook.Controllers;
using AddressBook.Models;
using Moq;
using AutoFixture;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Linq;
using AddressBook.Services;
using System.Web.Http;

namespace TestAddressBook
{
    public class TestAB : IClassFixture<ItemSeedDataFixture>
    {
        ItemSeedDataFixture fixture;
        private readonly Mock<IItemService> itemService;

        public TestAB(ItemSeedDataFixture fixture)
        {
            this.fixture = fixture;
            itemService = new Mock<IItemService>();
        }

        [Fact]
        public void AddItem_ShouldAddItem()
        {
            //arrange
            var testItems = (from i in fixture.itemContext.Items
                             select i).ToList();
            itemService.Setup(x => x.PostItem(testItems[1]))
                .Returns(testItems[1]);
            var itemController = new ItemsController(itemService.Object);
            //act
            var itemResult = itemController.PostItem(testItems[1]);
            //assert
            Assert.NotNull(itemResult);
            Assert.Equal(testItems[1].Name, itemResult.Name);
            Assert.True(testItems[1].Name == itemResult.Name);
        }


        [Fact]
        public void GetItemList_ShouldReturnList()
        {
            //arrange
            var testItems = (from i in fixture.itemContext.Items
                             select i).ToList();
            itemService.Setup(x => x.GetItems())
                .Returns(testItems);
            var itemController = new ItemsController(itemService.Object);
            //act
            var itemResult = itemController.GetItems();
            //assert
            Assert.NotNull(itemResult);
            Assert.Equal(testItems.Count(), itemResult.Count());
            Assert.Equal(testItems.ToString(), itemResult.ToString());
            Assert.True(testItems.Equals(itemResult));
        }


        [Fact]
        public void GetItemByName_ShouldReturnCorrectItem()
        {
            //arrange
            var testItems = (from i in fixture.itemContext.Items
                             select i).ToList();
            itemService.Setup(x => x.GetItem("Phil"))
                .Returns(testItems[0]);
            var itemController = new ItemsController(itemService.Object);
            //act
            var itemResult = itemController.GetItem("Phil");
            //assert
            Assert.NotNull(itemResult);
            Assert.Equal(testItems[0].Name, itemResult.Name);
            Assert.True(testItems[0].Name == itemResult.Name);
        }

        [Fact]
        public void PutItemByName_ShouldUpdateItem()
        {
            //arrange
            var testItems = (from i in fixture.itemContext.Items
                             select i).ToList();
            itemService.Setup(x => x.PutItem(testItems[0]))
                .Returns(testItems[0]);
            var itemController = new ItemsController(itemService.Object);
            //act
            var itemResult = itemController.PutItem(testItems[0]);
            //assert
            Assert.NotNull(itemResult);
            Assert.Equal(testItems[0].Name, itemResult.Name);
            Assert.Equal(testItems[0].Street1, itemResult.Street1);
            Assert.Equal(testItems[0].Street2, itemResult.Street2);
            Assert.Equal(testItems[0].City, itemResult.City);
            Assert.Equal(testItems[0].State, itemResult.State);
            Assert.Equal(testItems[0].ZipCode, itemResult.ZipCode);

            Assert.True(testItems[0].Name == itemResult.Name);
            Assert.True(testItems[0].Street1 == itemResult.Street1);
            Assert.True(testItems[0].Street2 == itemResult.Street2);
            Assert.True(testItems[0].City == itemResult.City);
            Assert.True(testItems[0].State == itemResult.State);
            Assert.True(testItems[0].ZipCode == itemResult.ZipCode);
        }

        [Fact]
        public void DeleteReturnsTrue()
        {
            //arrange
            var testItems = (from i in fixture.itemContext.Items
                             select i).ToList();
            itemService.Setup(x => x.DeleteItem("Phil"))
                .Returns(true);
            var itemController = new ItemsController(itemService.Object);

            //act
            bool itemResult = itemController.DeleteItem("Phil");

            //assert
            Assert.True(itemResult == true);
        }
    }
}
using AddressBook.Controllers;
using AddressBook.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;



namespace TestAB
{
    [TestClass]
    public class ItemTests
    {
        
        [TestMethod]
        public void GetAllItems_ShouldReturnItems()
        {
            var testItems = GetTestItems();
           var controller = new ItemsController(testItems);
            var result = controller.GetItems() as IEnumerable<Item>;
            
            List<Item> newList = result.ToList();
            Assert.AreEqual(testItems.Count, newList.Count);
        }

        private List<Item> GetTestItems()
        {
            var testItems = new List<Item>();
            testItems.Add(new Item { Name = "Demo1", });
            testItems.Add(new Item { Name = "Demo2", });
            testItems.Add(new Item { Name = "Demo3", });
            testItems.Add(new Item { Name = "Demo4", });

            return testItems;
        }
    }
}
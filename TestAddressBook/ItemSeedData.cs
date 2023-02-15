using AddressBook.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Moq;

namespace TestAddressBook
{
    public class ItemSeedDataFixture : IDisposable
    {
        //public ItemContext itemContext { get; private set; } = new ItemContext()
        public ItemContext itemContext { get; private set; }
        public ItemSeedDataFixture()
        {
            var options = new DbContextOptionsBuilder<ItemContext>()
            .UseInMemoryDatabase("ItemList")
            .Options;

            

            itemContext = new ItemContext(options);
            itemContext.Items.Add(new Item
            {
                Name = "Phil",
                Street1 = "123 Main St",
                Street2 = "",
                City = "Asheville",
                State = "NC",
                ZipCode = "28806"
            });
            itemContext.Items.Add(new Item
            {
                Name = "Laurie",
                Street1 = "123 Main St",
                Street2 = "",
                City = "Asheville",
                State = "NC",
                ZipCode = "28806"
            });
            itemContext.SaveChanges();
        }
            

        public void Dispose()
        {
            itemContext.Dispose();
        }
    }
}

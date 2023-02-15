using AddressBook.Models;

namespace AddressBook.Services
{
    public interface IItemService
    {
        public IEnumerable<Item> GetItems();
        public Item GetItem(string id);
        public Item PostItem(Item item);
        public Item PutItem( Item item);
        public bool DeleteItem(string id);
    }
}

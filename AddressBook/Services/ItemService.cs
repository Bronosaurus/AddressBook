using AddressBook.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace AddressBook.Services
{
    public class ItemService : IItemService
    {
        private ItemContext _context;
        private IMemoryCache _cache;
        
        public ItemService(ItemContext context, IMemoryCache cache)
        {
            _context = context;
            _cache = cache;
        }
        public IEnumerable<Item> GetItems()
        {
            if (!_cache.TryGetValue(CacheKeys.Items, out List<Item> items))
            {
                items = _context.Items.ToList();// Get the data from database
                var cacheEntryOptions = new MemoryCacheEntryOptions
                {
                    AbsoluteExpiration = DateTime.Now.AddMinutes(5),
                    SlidingExpiration = TimeSpan.FromMinutes(2),
                    Size = 1024,
                };
                _cache.Set(CacheKeys.Items, items, cacheEntryOptions);
            }

            return _context.Items.ToList();
        }

        public Item GetItem(string id)
        {
            var item =  _context.Items.Find(id);

            return item;
        }

        public Item PostItem(Item item)
        {
            var result =_context.Items.Add(item);
            
                 _context.SaveChanges();
            

            return result.Entity;
        }

        public Item PutItem( Item item)
        {
             _context.Entry(item).State = EntityState.Modified;
            var result = _context.Items.Update(item);
            _context.SaveChanges();

            return result.Entity;
        }

        public bool DeleteItem(string id)
        {
            var filteredData = _context.Items.Where(x => x.Name == id).FirstOrDefault();
            var result = _context.Remove(filteredData);
            _context.SaveChanges();

            return result != null ? true : false;
        }
    }
}

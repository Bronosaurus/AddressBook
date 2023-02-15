using Microsoft.Extensions.Caching.Memory;
using AddressBook.Models;

namespace AddressBook.Services
{
   
    

    namespace In_Memory_Caching.Services
    {
        public class CachedItemService : IItemService
        {
            private const string ItemListCacheKey = "ItemList";
            private readonly IMemoryCache _memoryCache;
            private readonly IItemService _ItemService;

            public CachedItemService(
                IItemService ItemService,
                IMemoryCache memoryCache)
            {
                _ItemService = ItemService;
                _memoryCache = memoryCache;
            }

            public IEnumerable<Item> GetItems()
            {
                var cacheOptions = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromSeconds(10))
                    .SetAbsoluteExpiration(TimeSpan.FromSeconds(30));

                if (_memoryCache.TryGetValue(ItemListCacheKey, out List<Item> query))
                    return query;

                query = _ItemService.GetItems().ToList();

                _memoryCache.Set(ItemListCacheKey, query, cacheOptions);

                return query;

            }

            bool IItemService.DeleteItem(string id)
            {
                return true;
            }

            Item IItemService.GetItem(string id)
            {
                return new Item();
            }

            Item IItemService.PostItem(Item item)
            {
                //throw new NotImplementedException();
                return item;
            }

            Item IItemService.PutItem(Item item)
            {
                return item;
            }

            //public Item GetItem(string id)
            //{
            //    var cacheOptions = new MemoryCacheEntryOptions()
            //        .SetSlidingExpiration(TimeSpan.FromSeconds(10))
            //        .SetAbsoluteExpiration(TimeSpan.FromSeconds(30));

            //    if (_memoryCache.TryGetValue(ItemListCacheKey, out List<Item> query))
            //        return query.First();

            //    query = _ItemService.GetItems().ToList();

            //    _memoryCache.Set(ItemListCacheKey, query, cacheOptions);

            //    return query;
            //}
        }
    }

}

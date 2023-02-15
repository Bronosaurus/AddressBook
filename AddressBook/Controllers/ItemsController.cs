using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AddressBook.Models;
using Microsoft.Extensions.Caching.Memory;
using AddressBook.Services;

namespace AddressBook.Controllers
{
    [Route("api/Items")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        
        private readonly IItemService _itemService;
        private IMemoryCache _cache;
        

        [ActivatorUtilitiesConstructor]
        public ItemsController(IItemService itemService)
        {
            _itemService = itemService;
        }
        
        // GET: api/Items
        [HttpGet]
        public IEnumerable<Item> GetItems()
        {
            var itemList = _itemService.GetItems();
            return itemList;
        }

        // GET: api/Items/5
        [HttpGet("{id}")]
        public Item GetItem(string id)
        {
            return _itemService.GetItem(id);

            
        }

        // PUT: api/Items/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public Item PutItem(Item item)
        {
            return _itemService.PutItem(item);
        }

        // POST: api/Items
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public Item PostItem(Item item)
        {          
           return _itemService.PostItem(item);
        }

        // DELETE: api/Items/5
        [HttpDelete("{id}")]
        public bool DeleteItem(string id)
        {
            return _itemService.DeleteItem(id);
        }
    }
}

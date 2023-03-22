using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TutorialNET5WebAPI.Models;
using TutorialNET5WebAPI.Repositories.interfaces;

namespace TutorialNET5WebAPI.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly List<Item> items = new()
        {
            new Item {Id = Guid.NewGuid(), Name = "Potion", Price = 9, CreatedDate = DateTimeOffset.UtcNow},
            new Item {Id = Guid.NewGuid(), Name = "Iron Sword", Price = 32, CreatedDate = DateTimeOffset.UtcNow},
            new Item {Id = Guid.NewGuid(), Name = "Bronze Shield", Price = 18, CreatedDate = DateTimeOffset.UtcNow},
            new Item {Id = Guid.NewGuid(), Name = "Red Shield", Price = 39, CreatedDate = DateTimeOffset.UtcNow},
            new Item {Id = Guid.NewGuid(), Name = "White Shield", Price = 11, CreatedDate = DateTimeOffset.UtcNow},
        };

        public async Task<IEnumerable<Item>> GetItemsAsync()
        {
            return await Task.FromResult(items);
        }
        public async Task<Item> GetItemAsync(Guid id)
        {
            return await Task.FromResult(items.SingleOrDefault(item => item.Id == id));
        }
        public async Task AddItemAsync(Item item)
        {
            items.Add(item);
            await Task.CompletedTask;
        }

        public async Task UpdateItemAsync(Item item)
        {
            var index = items.FindIndex(i => i.Id == item.Id);
            items[index] = item;
            await Task.CompletedTask;
        }

        public async Task RemoveItemAsync(Guid id)
        {
            var index = items.FindIndex(i => i.Id == id);
            items.RemoveAt(index);
            await Task.CompletedTask;
        }
    }
}

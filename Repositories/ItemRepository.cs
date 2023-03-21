using System;
using System.Collections.Generic;
using System.Linq;
using TutorialNET5WebAPI.Models;
using TutorialNET5WebAPI.Repositories.interfaces;

namespace TutorialNET5WebAPI.Repositories
{
    //public class ItemRepository : IItemRepository
    //{
    //    private readonly List<Item> items = new()
    //    {
    //        new Item {Id = Guid.NewGuid(), Name = "Potion", Price = 9, CreatedDate = DateTimeOffset.UtcNow},
    //        new Item {Id = Guid.NewGuid(), Name = "Iron Sword", Price = 32, CreatedDate = DateTimeOffset.UtcNow},
    //        new Item {Id = Guid.NewGuid(), Name = "Bronze Shield", Price = 18, CreatedDate = DateTimeOffset.UtcNow},
    //        new Item {Id = Guid.NewGuid(), Name = "Red Shield", Price = 39, CreatedDate = DateTimeOffset.UtcNow},
    //        new Item {Id = Guid.NewGuid(), Name = "White Shield", Price = 11, CreatedDate = DateTimeOffset.UtcNow},
    //    };

    //    public IEnumerable<Item> GetItemsAsync()
    //    {
    //        return items;
    //    }
    //    public Item GetItemAsync(Guid id)
    //    {
    //        return items.SingleOrDefault(item => item.Id == id);
    //    }
    //    public void AddItemAsync(Item item)
    //    {
    //        items.Add(item);
    //    }

    //    public void UpdateItemAsync(Item item)
    //    {
    //        var index = items.FindIndex(i => i.Id == item.Id);
    //        items[index] = item;
    //    }

    //    public void RemoveItemAsync(Guid id)
    //    {
    //        var index = items.FindIndex(i => i.Id == id);
    //        items.RemoveAt(index);
    //    }
    //}
}

using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using TutorialNET5WebAPI.Models;

namespace TutorialNET5WebAPI.Repositories.interfaces
{
    public interface IItemRepository
    {
        Task<Item> GetItemAsync(Guid id);
        Task<IEnumerable<Item>> GetItemsAsync();
        Task AddItemAsync(Item item);
        Task UpdateItemAsync(Item item);
        Task RemoveItemAsync(Guid id);
    }
}

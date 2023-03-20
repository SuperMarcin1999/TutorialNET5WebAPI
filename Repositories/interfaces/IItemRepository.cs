using System.Collections.Generic;
using System;
using TutorialNET5WebAPI.Models;

namespace TutorialNET5WebAPI.Repositories.interfaces
{
    public interface IItemRepository
    {
        Item GetItem(Guid id);
        IEnumerable<Item> GetItems();
        void AddItem(Item item);
        void UpdateItem(Item item, Guid id);
        void RemoveItem(Guid id);
    }
}

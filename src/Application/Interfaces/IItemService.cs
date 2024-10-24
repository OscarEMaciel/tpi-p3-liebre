using Domain.Entities;
using System.Collections.Generic;

namespace Application.Interfaces
{
    public interface IItemService
    {
        List<Item> GetItems();
        Item GetItemById(int id);
        void AddItem(Item item);
        void UpdateItem(int id, Item item);
        void DeleteItem(int id);
    }
}

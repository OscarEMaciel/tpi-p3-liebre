using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using System.Collections.Generic;

namespace Application.Services
{
    public class ItemService : IItemService
    {
        private readonly IItemRepository _itemRepository;

        public ItemService(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public List<Item> GetItems()
        {
            return _itemRepository.GetAll();
        }

        public Item GetItemById(int id)
        {
            return _itemRepository.GetById(id);
        }

        public void AddItem(Item item)
        {
            _itemRepository.Add(item);
        }

        public void UpdateItem(int id, Item item)
        {
            var existingItem = _itemRepository.GetById(id);
            if (existingItem != null)
            {
                existingItem.Name = item.Name;
                existingItem.Description = item.Description;
                existingItem.Price = item.Price;
                existingItem.CurrentStock = item.CurrentStock;

                _itemRepository.Update(existingItem);
            }
        }

        public void DeleteItem(int id)
        {
            var item = _itemRepository.GetById(id);
            if (item != null)
            {
                _itemRepository.Delete(item);
            }
        }
    }
}

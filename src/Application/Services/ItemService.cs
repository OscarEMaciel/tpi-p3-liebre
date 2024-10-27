using Application.Interfaces;
using Application.Models;
using Application.Models.Request;
using Domain;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Interfaces;

namespace Application.Services
{
    public class ItemService : IItemService
    {
        private readonly IItemRepository _itemRepository;

        public ItemService(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public IEnumerable<ItemDTO> GetAllItems()
        {
            var objs = _itemRepository.GetAll();
            return ItemDTO.CreateList(objs);
        }

        public ItemDTO GetItemById(int id)
        {
            var obj = _itemRepository.GetById(id)
                ?? throw new NotFoundException(nameof(Item), id);
            return ItemDTO.Create(obj);
        }

        public void CreateItem(ItemCreateRequest itemCreteRequest)
        {
            var item = new Item(itemCreteRequest.Name, itemCreteRequest.Price, itemCreteRequest.StockAvailable);
            _itemRepository.Add(item);
        }

        public void UpdateItem(int id, ItemUpdateRequest itemUpdateRequest)
        {
            var item = _itemRepository.GetById(id)
                ?? throw new NotFoundException(nameof(Item), id);

            if (itemUpdateRequest.Name != string.Empty) item.Name = itemUpdateRequest.Name;

            if (itemUpdateRequest.Price != null) item.Price = itemUpdateRequest.Price;

            if (itemUpdateRequest.StockAvailable != null) item.StockAvailable = itemUpdateRequest.StockAvailable;

            _itemRepository.Update(item);
        }

        public void DeleteItem(int id)
        {
            var item = _itemRepository.GetById(id);
            if (item == null)
            {
                throw new NotFoundException(nameof(Item), id);
            }
            _itemRepository.Delete(item);
        }
    }
}

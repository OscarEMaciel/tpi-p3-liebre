using Application.Models.Request;
using Application.Models;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IItemService
    {
        IEnumerable<ItemDTO> GetAllItems();
        ItemDTO GetItemById(int id);
        void CreateItem(ItemCreateRequest ItemCreateRequest);
        void UpdateItem(int id, ItemUpdateRequest ItemUpdateRequest);
        void DeleteItem(int id);
    }
}
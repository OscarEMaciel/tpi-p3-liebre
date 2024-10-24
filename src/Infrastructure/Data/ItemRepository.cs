using Domain.Entities;
using Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Data
{
    public class ItemRepository : BaseRepository<Item>, IItemRepository
    {
        private readonly List<Item> _items = new List<Item>(); // Simulacion de una base de datos en memoria

        public override Item Add(Item entity)
        {
            _items.Add(entity);
            return entity;
        }

        public override List<Item> GetAll()
        {
            return _items;
        }

        public override Item GetById<TId>(TId id)
        {
            return _items.FirstOrDefault(i => i.Id.Equals(id));
        }

        public override void Delete(Item entity)
        {
            _items.Remove(entity);
        }

        public override Item Update(Item entity)
        {
            var item = _items.FirstOrDefault(i => i.Id == entity.Id);
            if (item != null)
            {
                item.Name = entity.Name;
                item.Description = entity.Description;
                item.Price = entity.Price;
                item.CurrentStock = entity.CurrentStock;
            }
            return item;
        }
    }
}


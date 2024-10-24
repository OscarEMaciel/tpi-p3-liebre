﻿using Domain.Entities;

namespace Application.Models
{
    public class ItemDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int StockAvailable { get; set; }

        public static ItemDTO Create(Item item)
        {
            return new ItemDTO
            {
                Id = Item.Id,
                Name = Item.Name,
                Price = Item.Price,
                StockAvailable = Item.StockAvailable
            };
        }

        public static List<ItemDTO> CreateList(IEnumerable<Item> items)
        {
            List<ItemDTO> listDto = new List<ItemDTO>();
            foreach (var product in items)
            {
                listDto.Add(Create(item));
            }
            return listDto;
        }
    }
}
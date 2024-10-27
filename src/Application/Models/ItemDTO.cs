
using Domain.Entities;

namespace Application.Models
{
    public class ItemDTO
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public decimal Price { get; set; }
        public int StockAvailable { get; set; }

        public static ItemDTO Create(Item item)
        {
            return new ItemDTO
            {
                Id = item.Id,
                Name = item.Name,
                Price = item.Price,
                StockAvailable = item.StockAvailable
            };
        }

        public static List<ItemDTO> CreateList(IEnumerable<Item> items)
        {
            List<ItemDTO> listDto = new List<ItemDTO>();
            foreach (var item in items)
            {
                listDto.Add(Create(item));
            }
            return listDto;
        }
    }
}
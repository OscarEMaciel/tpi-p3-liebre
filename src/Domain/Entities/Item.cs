using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Item
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int StockAvailable { get; set; }

        public Item() { }
        public Item(string name, decimal price, int stockAvailable)
        {
            Name = name;
            Price = price;
            StockAvailable = stockAvailable;
        }
    }
}



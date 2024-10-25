
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Xml.Linq;

namespace Domain.Entities
{
    public class TransactionDetail
    {
        public int Id { get; set; }
        public int TransactionId { get; set; }

        [Required]
        public Transaction Transaction { get; set; }
        public int ItemId { get; set; }

        [Required]
        public Item Item { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        
        public TransactionDetail() {
            
            Transaction = new Transaction();
             Item = new Item();

         }
        public TransactionDetail(Transaction transaction, Item item, int quantity, decimal unitPrice)
        {
            Transaction = transaction;
            Item = item;
            Quantity = quantity;
            UnitPrice = unitPrice;
        }
    }
}
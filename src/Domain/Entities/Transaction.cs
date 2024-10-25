using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Xml.Linq;

namespace Domain.Entities
{
    public class Transaction
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }

        [Required]
        public ICollection<TransactionDetail>? TransactionDetails { get; set; }

        public decimal Total { get; set; }

        public Transaction() { }
        public Transaction(DateTime date, ICollection<TransactionDetail> transactionDetail, decimal total)
        {
            Date = date;
            TransactionDetails = transactionDetail;
            Total = total;
        }
    }
}

using Domain.Entities;

namespace Application.Models
{
    internal class TransactionDTO
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public decimal Total { get; set; }
        public ICollection<TransactionDetailDTO> TransactionDetails { get; set; }

        public static TransactionDTO Create(Transaction transaction)
        {
            return new TransactionDTO
            {
                Id = transaction.Id,
                Date = transaction.Date,
                Total = transaction.Total,
                TransactionDetails = transaction.TransactionDetails != null ? TransactionDetailDTO.CreateList(transaction.TransactionDetails) : null
            };
        }

        public static List<TransactionDTO> CreateList(IEnumerable<Transaction> transactions)
        {
            List <TransactionDTO> listDto = new List<TransactionDTO>();
            foreach (var transaction in transactions)
            {
                listDto.Add(Create(transaction));
            }
            return listDto;
        }
    }
}

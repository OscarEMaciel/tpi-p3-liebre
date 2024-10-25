using Domain.Entities;
using Application.Models;
using Application.Models.Request;

namespace Application.Interfaces
{
    public interface ITransactionService
    {
        IEnumerable<TransactionDTO> GetAllTransaction(); 
        TransactionDTO GetTransactionById(int id);
        void CreateTransaction(TransactionCreateRequest transactionCreateRequest);
        void UpdateTransaction(int id, TransactionUpdateRequest transactionUpdateRequest);
        void DeleteTransaction(int id);
    }
}

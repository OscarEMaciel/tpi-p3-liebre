using Application.Interfaces;
using Application.Models.Request;
using Application.Models;
using Domain;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Exceptions;

namespace Application.Services
{
    public class TransactionServices: ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly ITransactionDetailsRepository _transactiondetailsRepository;

        public TransactionService(ITransactionRepository transactionRepository, ITransactionDetailsRepository transactiondetailsRepository)
        {
            _transactionRepository = transactionRepository;
            _transactiondetailsRepository = transactiondetailsRepository;
        }


        public IEnumerable<TransactionDTO> GetAllTransactions()
        {
            var objs = _transactionRepository.GetAll();
            return TransactionDTO.CreateList(objs);
        }

        public TransactionDTO GetTransactionById(int id)
        {
            var obj = _transactionRepository.GetById(id)
                ?? throw new NotFoundException(nameof(Transaction), id);
            return TransactionDTO.Create(obj);
        }

        public void CreateTransaction(TransactionCreateRequest transactionCreteRequest)
        {

            var transactiondetails = new List<TransactionDetail>();
            foreach (var transactiondetailId in transactionCreteRequest.TransactionDetailIds)
            {
                var Transactiondetail = _TransactiondetailsRepository.GetById(TransactiondetailId);
                if (Transactiondetail != null)
                {
                    transactiondetails.Add(transactiondetail);
                }
            }
            var transaction = new Transaction(transactionCreteRequest.Date, transactiondetails, transactionCreteRequest.Total);
            _transactionRepository.Add(transaction);
        }

        public void UpdateTransaction(int id, TransactionUpdateRequest transactionUpdateRequest)
        {
            var transaction = _transactionRepository.GetById(id)
                ?? throw new NotFoundException(nameof(Transaction), id);

            if (transactionUpdateRequest.Total != null) transaction.Total = transactionUpdateRequest.Total;

            _transactionRepository.Update(transaction);
        }

        public void DeleteTransaction(int id)
        {
            var transaction = _transactionRepository.GetById(id);
            if (transaction == null)
            {
                throw new NotFoundException(nameof(Transaction), id);
            }
            _transactionRepository.Delete(transaction);
        }
    }
}

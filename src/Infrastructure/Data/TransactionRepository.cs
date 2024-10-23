using Domain;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class TransactionRepository : EfRepository<Transaction>, ITransactionRepository 
{
    public TransactionRepository(ApplicationContext context) : base(context)
    {
    }
    // Método para obtener todas las transacciones incluyendo los detalles
    public List<Transaction> GetAll()
    {
        return _context.Set<Transaction>().Include(s => s.TransactionDetails).ToList();
    }
    // Método para obtener todas las transacciones incluyendo los detalles
    public Transaction? GetById<TId>(TId id)
    {
        return _context.Set<Transaction>().Include(s => s.TransactionDetails).FirstOrDefault(e => e.Id.Equals(id));
    }
}
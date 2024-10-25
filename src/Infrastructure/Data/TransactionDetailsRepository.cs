using Domain;
using Domain.Entities;

namespace Infrastructure.Data;

public class TransactionDetailsRepository : EfRepository<TransactionDetail>, ITransactionDetailsRepository
{
    public TransactionDetailsRepository(ApplicationContext context) : base(context)
    {
    }
}

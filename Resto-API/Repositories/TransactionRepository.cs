using Resto_API.Contracts;
using Resto_API.Data;
using Resto_API.Models;

namespace Resto_API.Repositories
{
    public class TransactionRepository : GeneralRepository<Transaction> , ITransactionRepository
    {
        public TransactionRepository(RestoAppDbContext context) : base(context)
        {
        }
    }
}

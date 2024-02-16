using Resto_API.Models;
using Resto_API.Utilities.Enums;

namespace Resto_API.DTOs.Transactions
{
    public class TransactionDto
    {
        public Guid Guid { get; set; }
        public Guid CustomerGuid { get; set; }
        public StatusLevel Status { get; set; }
        public string Remarks { get; set; }

        public static Transaction ConvertToTransaction(Transaction transaction, TransactionDto transactionDto)
        {
            transaction.Status = transactionDto.Status;
            transaction.ModifiedDate = DateTime.Now;
            return transaction;
        }
    }
}

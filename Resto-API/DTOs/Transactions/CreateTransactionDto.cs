using Resto_API.Models;
using Resto_API.Utilities.Enums;

namespace Resto_API.DTOs.Transactions
{
    public class CreateTransactionDto
    {
        public Guid CustomerGuid { get; set; }
        public int PriceTransaction { get; set; }
        public StatusLevel Status { get; set; }
        public string Invoice { get; set; }
        public string Remarks { get; set; }

        public static implicit operator Transaction (CreateTransactionDto dto)
        {
            return new Transaction {
                Guid = Guid.NewGuid(),
                PriceTransaction = dto.PriceTransaction,
                Status = StatusLevel.OnProgress,
                Invoice = dto.Invoice,
                Remarks = "",
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
            };
        }

        public static Transaction CreateTransaction(int priceTransaction, string invoice)
        {
            return new Transaction
            {
                Guid = Guid.NewGuid(),
                PriceTransaction = priceTransaction,
                Status = StatusLevel.OnProgress,
                Invoice = invoice,
                Remarks = "",
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
            };
        }
    }


}

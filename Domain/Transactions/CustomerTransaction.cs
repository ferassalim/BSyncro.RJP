using Domain.Common;
using Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.Transactions
{
    public class CustomerTransaction : BaseEntity, IAggregateRoot
    {
        public Guid CustomerId { get; private set; }
        public Customer Customer { get; private set; }
        public string TransactionNumber { get; private set; }
        public DateTime TransactionDate { get; private set; }
        public decimal Amount { get; private set; }
        public CustomerTransaction()
        {
        }

        public CustomerTransaction(Guid customerId, decimal amount)
        {
            CustomerId = customerId;
            Amount = amount;
            TransactionDate = DateTime.UtcNow;
            TransactionNumber = "";
        }
        public CustomerTransaction Update(decimal amount)
        {
            Amount = amount;
            return this;
        }

    }
}

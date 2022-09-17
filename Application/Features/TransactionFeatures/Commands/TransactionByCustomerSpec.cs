using Ardalis.Specification;
using Domain.Entities.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.TransactionFeatures.Commands
{
    public class TransactionByCustomerSpec : Specification<CustomerTransaction,TransactionDto>
    {
        public TransactionByCustomerSpec(Guid customerId) =>
            Query.Where(p => p.CustomerId == customerId);
    }
}

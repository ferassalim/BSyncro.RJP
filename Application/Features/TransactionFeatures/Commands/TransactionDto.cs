using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.TransactionFeatures.Commands
{
    public class TransactionDto
    {
        public Guid Id { get; set; }
        public string TransactionNumber { get;  set; }
        public DateTime TransactionDate { get;  set; }
        public decimal Amount { get;  set; }
    }
}

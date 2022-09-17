using Application.Features.TransactionFeatures.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CustomerFeatures.Commands
{
    public class CustomerDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } 
        public string SureName { get; set; }
        public decimal Balance { get { return Transactions?.Sum(x => x.Amount) ?? 0; } }
        public List<TransactionDto> Transactions { get; set; }
    }
}

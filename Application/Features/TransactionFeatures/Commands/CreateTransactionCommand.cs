using MediatR;
using Domain.Entities.Transactions;
using Domain.Interfaces;

namespace Application.Features.TransactionFeatures.Commands
{
    public class CreateTransactionCommand : IRequest<Guid>
    {
        public Guid CustomerId { get; set; }
        public decimal Amount { get;  set; }

    }
    public class CreateTransactionCommandHandler : IRequestHandler<CreateTransactionCommand, Guid>
    {
        private readonly IRepository<CustomerTransaction> _repository;

        public CreateTransactionCommandHandler(IRepository<CustomerTransaction> repository) =>
            (_repository) = (repository);

        public async Task<Guid> Handle(CreateTransactionCommand request, CancellationToken cancellationToken)
        {
            var transaction = new CustomerTransaction(request.CustomerId, request.Amount);

            
            await _repository.AddAsync(transaction, cancellationToken);

            return transaction.Id;
        }
    }
}
